using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Utils
{
    public class Update
    {

        public static string versaoAtualObject = Utils.versaoSistema;
        public static string urlAPI = "http://www.qualitysys.com.br/webservice/";

        public static string sendRequest(string url, string parametros = null, string method = "POST", List<string> headers = null, int timeOut = 2000, string ContentType = null, bool throwException = false)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
                ServicePointManager.Expect100Continue = false;

                String postData = parametros;

                if (!String.IsNullOrEmpty(ContentType) && !ContentType.Contains("json"))
                    parametros = parametros + (!String.IsNullOrEmpty(parametros) ? @"&" : null) + @"cache=" + DateTime.Now.Ticks.ToString();

                Boolean verificaConexao = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                if (method == "GET")
                    url += "?" + postData;
                else { }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UseDefaultCredentials = true; 
                IWebProxy defaultProxy = WebRequest.DefaultWebProxy;
                if (defaultProxy != null)
                {
                    defaultProxy.Credentials = CredentialCache.DefaultCredentials;
                    request.Proxy = defaultProxy;
                }
                request.Timeout = System.Threading.Timeout.Infinite;
                if (timeOut > 0)
                    request.Timeout = timeOut;
                request.Method = method;
                if (headers != null)
                    foreach (string item in headers)
                        request.Headers.Add(item);
                else { }

                request.ServicePoint.Expect100Continue = false;
                request.ProtocolVersion = HttpVersion.Version10;

                if (method == "POST")
                {
                    var data = Encoding.ASCII.GetBytes(postData);
                    if (String.IsNullOrEmpty(ContentType))
                        request.ContentType = "application/x-www-form-urlencoded";
                    else
                        request.ContentType = ContentType;

                    request.ContentLength = data.Length;
                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                else { }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                return responseString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (throwException)
                    throw e;

                return "";
            }
        }

        public static bool checkWebsiteIsUp(string Url)
        {
            string Message = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
            request.Timeout = 2000;

            // Set the credentials to the current user account
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.Method = "GET";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                }
            }
            catch (WebException ex)
            {
                Message += ((Message.Length > 0) ? "\n" : "") + ex.Message;
            }

            return (Message.Length == 0);
        }

        public static bool checarUpdate(bool force = false)
        {
            try
            {
                /* Buscar no banco a data da última verificação de update */
                string retornoDataUpdate = getConfiguracoesGlobais("dataUltimaChecagemUpdate");
                atualizaConfiguracao("versao", Utils.versaoSistema);

                //Licenca.verificaLicenca();

                DateTime dataUltimaChecagem = DateTime.Now;
                if (!String.IsNullOrEmpty(retornoDataUpdate))
                    dataUltimaChecagem = System.Convert.ToDateTime(retornoDataUpdate);

                if (
                        (String.IsNullOrEmpty(retornoDataUpdate)) ||
                        ((!String.IsNullOrEmpty(retornoDataUpdate)) && ((DateTime.Now - dataUltimaChecagem).TotalHours >= 24) && (!upgradeInProgress())) ||
                        force
                    )
                {

                    string versaoServidorQuality = getLastVersionRemote(),
                           versaoAtual = Update.versaoAtualObject;

                    var versaoAtualObject = new Version(versaoAtual);
                    var versaoServidorQualityObject = new Version(versaoServidorQuality);

                    var update = versaoAtualObject.CompareTo(versaoServidorQualityObject);

                    if (update < 0)
                    {
                        atualizaConfiguracao("inUpdateProgress", "s");
                        string tmpDir = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 20);
                        string newDir = System.AppDomain.CurrentDomain.BaseDirectory + tmpDir;
                        Directory.CreateDirectory(newDir);
                        string newFile = downloadNovaVersao(newDir);
                        try
                        {
                            Directory.Move(System.AppDomain.CurrentDomain.BaseDirectory + @"bin", System.AppDomain.CurrentDomain.BaseDirectory + @"binOld");
                            Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"bin");
                            extractArchive(System.AppDomain.CurrentDomain.BaseDirectory, newFile);
                            finalizaUpdate(newDir);
                        }
                        catch (Exception ex)
                        {
                            Utils.WriteLog("Extração -> " + ex.ToString());
                        }
                    }
                    atualizaConfiguracao("dataUltimaChecagemUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string getConfiguracoesGlobais(string nmConfiguracao)
        {
            string query = "SELECT * FROM configuracoesGlobais WHERE LOWER(nmConfiguracao) = LOWER('" + nmConfiguracao + "')";
            System.Data.DataTable result = Utils.em.executeData(query, null);
            if (result.Rows.Count == 0)
            {
                return String.Empty;
            }
            else { }


            if (String.IsNullOrEmpty(result.Rows[0][2].ToString()))
            {
                Utils.em.executeData("DELETE FROM configuracoesGlobais WHERE LOWER(nmConfiguracao) = LOWER('" + nmConfiguracao + "')", null);
                return String.Empty;
            }
            else { }

            string decrypt = Security.DecryptRijndael(result.Rows[0][2].ToString(), Security.Inputkey);
            if ((result.Rows[0][0].ToString() + @";" + result.Rows[0][1].ToString()) != decrypt)
            {
                Utils.em.executeData("DELETE FROM configuracoesGlobais WHERE LOWER(nmConfiguracao) = LOWER('" + nmConfiguracao + "')", null);
                return String.Empty;
            }
            else { }

            return result.Rows[0][1].ToString();
        }

        public static void atualizaConfiguracao(string configuracao, string novoValor)
        {
            string query = "SELECT * FROM configuracoesGlobais WHERE LOWER(nmConfiguracao) = LOWER('" + configuracao + "')";

            System.Data.DataTable verificaProgresso = Utils.em.executeData(query, null);
            if (verificaProgresso.Rows.Count == 0)
            {
                Utils.em.executeData("INSERT INTO configuracoesGlobais (nmConfiguracao, valorConfiguracao, assinatura) VALUES ('" + configuracao + "', '" + novoValor + "', '" + Security.EncryptRijndael(configuracao + @";" + novoValor, Security.Inputkey) + "');", null);
            }
            else
            {
                Utils.em.executeData("UPDATE configuracoesGlobais SET valorConfiguracao = '" + novoValor + "', assinatura = '" + Security.EncryptRijndael(configuracao + @";" + novoValor, Security.Inputkey) + "' WHERE LOWER(nmConfiguracao) = LOWER('" + configuracao + "');", null);
            }
            return;
        }

        public static void finalizaUpdate(string tmpDir = null)
        {
            atualizaConfiguracao("inUpdateProgress", "n");

            if (Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"binOld"))
                Directory.Delete(System.AppDomain.CurrentDomain.BaseDirectory + @"binOld", true);
            else { }

            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"triggersBanco\\Triggers.sql"))
            {
                string sql = File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"triggersBanco\\Triggers.sql");
                IEnumerable<string> commandStrings = Regex.Split(sql, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (string commandString in commandStrings)
                    if (!String.IsNullOrEmpty(commandString.Trim()))
                        Utils.em.executeData(commandString.Trim(), null);
            }
            else { }

            atualizaConfiguracao("versao", getLastVersionRemote());

            if (Directory.Exists(tmpDir) && tmpDir != null)
                Directory.Delete(tmpDir, true);
            else { }
            return;
        }

        public static bool upgradeInProgress()
        {
            string query = "SELECT * FROM configuracoesGlobais WHERE nmConfiguracao = 'inUpdateProgress'";
            System.Data.DataTable verificaProgresso = Utils.em.executeData(query, null);
            if (verificaProgresso.Rows.Count == 0)
                return false;
            else { }

            string valorConfiguracao = verificaProgresso.Rows[0][1].ToString();
            if (valorConfiguracao.Contains('n'))
                return false;
            else { }

            return true;
        }

        public static void extractArchive(string dir, string file)
        {
            var compressed = ArchiveFactory.Open(@file);
            foreach (var entry in compressed.Entries)
                if (!entry.IsDirectory)
                    entry.WriteToDirectory(@dir, new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                else { }
            compressed.Dispose();
        }

        public static string downloadNovaVersao(string dir)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(urlAPI + @"sistema_quality.rar", dir + @"\\sistema_quality.rar");
            }
            return dir + @"\\sistema_quality.rar";
        }

        public static string getLastVersionRemote()
        {
            try
            {
                string url = urlAPI + @"api.php";
                //string url = "http://www.qualitysysss.com.br/api.php";
                string versaoServidorQuality = Update.sendRequest(url, "action=getLastVersion&cache=" + DateTime.Now.Ticks.ToString());
                string changeLog = versaoServidorQuality.Split(new Char[] { ';' })[1];
                if (String.IsNullOrEmpty(changeLog))
                    changeLog = "Sem informações.<br />";
                else { }
                atualizaConfiguracao("changeLog", changeLog);
                return versaoServidorQuality.Split(new Char[] { ';' })[0];
            }
            catch
            {
                return Utils.versaoSistema;
            }
        }

    }
}