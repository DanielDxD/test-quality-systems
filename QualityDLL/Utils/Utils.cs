using System;
using System.Collections.Generic;
using System.Web;
using Utils.Pagina.Attributes;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using SharpCompress.Common;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.UI;
using System.Xml;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net.Mail;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Ionic.Zip;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Reflection;
using System.Management;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using EJB.EntityManager;

namespace Utils
{

    public class Utils
    {
        private static System.Xml.XmlNode FieldAttributes;
        public static string versaoSistema = "1.2.00";
        public static int decimalPlaces = 2;
        public static int decimalPlacesQtd = 4;

        public static bool primeiraLetraMaiuscula
        {
            get
            {
                string value = Update.getConfiguracoesGlobais("primeiraLetraMaiuscula");
                if (String.IsNullOrEmpty(value) || value == "n")
                    return false;
                else
                    return true;

            }
        }

        private static System.Reflection.Assembly m_QualityDLL = null;
        public static System.Reflection.Assembly QualityDLL
        {
            get
            {
                if (m_QualityDLL == null)
                {
                    if (!IsdotnetCore())
                        m_QualityDLL = System.Reflection.Assembly.LoadFrom(HttpContext.Current.Request.PhysicalApplicationPath + "bin\\QualityDLL.dll");
                    else
                        m_QualityDLL = System.Reflection.Assembly.LoadFrom(System.IO.Directory.GetCurrentDirectory() + "\\QualityDLL.dll");
                }
                else { }
                return m_QualityDLL;
            }
            set
            {
                if (value == null)
                    if (!IsdotnetCore())
                        m_QualityDLL = System.Reflection.Assembly.LoadFrom(HttpContext.Current.Request.PhysicalApplicationPath + "bin\\QualityDLL.dll");
                    else
                        m_QualityDLL = System.Reflection.Assembly.LoadFrom(System.IO.Directory.GetCurrentDirectory() + "\\QualityDLL.dll");
                else
                    m_QualityDLL = value;
            }
        }

        private static Service m_Sr = null;
        public static Service sr(long idEmpresa, bool reload = false)
        {
            if (!reload)
            {
                if (m_Sr == null)
                    m_Sr = new Service(idEmpresa, getSqlConfigs());
                else
                    m_Sr.setIdEmpresaCorrente(idEmpresa);
            }
            else
                m_Sr = new Service(idEmpresa, getSqlConfigs());

            return m_Sr;
        }

        public static bool IsdotnetCore()
        {
            var runtimeVer = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            return runtimeVer.ToLower().Contains("core");
        }

        public static Service sr(long idEmpresa, string host, string db, string user, string pass)
        {
            string conString = String.Format("workstation id=WorkingStation;packet size=4096;user id={2};data source={0};persist security info=False;initial catalog={1};password={3};MultipleActiveResultSets=True", host, db, user, pass);
            return new Service(idEmpresa, conString);
        }

        public static String[] classMask = {
            "ProdutoServico",
            "RequisicaoCompraProduto",
            "RequisicaoCompraProdutoServico",
            "EntradaMercadoriaItem",
            "RequisicaoCotacaoProduto",
            "RequisicaoInternaProdutoServico",
            "PedidoCompraProdutoServico",
            "RequisicaoCotacaoProdutoServico",
            "NotaFiscalEItem",
        };
        public static string hashTags = "##";

        private static EJB.EntityManager.EntityManager m_Em = null;
        public static EJB.EntityManager.EntityManager em
        {
            get
            {
                if (m_Em == null)
                    m_Em = new EJB.EntityManager.EntityManager(getSqlConfigs());
                else { }
                return m_Em;
            }
            set
            {
                if (value == null)
                    m_Em = new EJB.EntityManager.EntityManager(getSqlConfigs());
                else
                    m_Em = value;
            }
        }
        public static string SerializeComplete(object obj)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static bool internetStatus = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

        public static string GetServerIP()
        {
            Hashtable config = getSqlConfigs("");
            IPAddress ip = null;
            try
            {
                ip = IPAddress.Parse(config["servidor"].ToString());
            }
            catch
            {
                ip = null;
            }

            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

            //foreach (IPAddress address in ipHostInfo.AddressList)
            //{
            //    if (address.AddressFamily == AddressFamily.InterNetwork)
            //        return address.ToString();
            //}

            return ip == null ? "localhost" : ip.ToString();
        }

        public static int GetPortQualityServer()
        {
            int porta = 1567;
            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"config.qlt"))
            {
                string encoded = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"config.qlt");
                string decoded = Security.DecryptRijndael(Security.Base64Decode(encoded), Security.getInputKey());
                try
                {
                    porta = ToInt(decoded.Split(';')[4]);
                }
                catch
                {
                    porta = 1567;
                }
            }
            else { }
            porta += 1;

            return porta;
        }
        public static string serialize(object obj)
        {
            try
            {
                string json = Extentions.SerializeToJson(obj, true);
                return json;

            }
            catch (Exception e)
            {
                WriteLog("ERRO: " + e.Message);
                throw e;
            }
        }

        public static T deserialize<T>(string json)
        {
            JavaScriptSerializer sr = new JavaScriptSerializer();
            object obj = sr.Deserialize<T>(json);
            return (T)obj;
        }

        public static string GetMac()
        {
            string Mac = string.Empty;
            ManagementClass MC = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection MOCol = MC.GetInstances();
            foreach (ManagementObject MO in MOCol)
                if (MO != null)
                {
                    if (MO["MacAddress"] != null)
                    {
                        Mac = MO["MACAddress"].ToString();
                        if (Mac != string.Empty)
                            break;
                    }
                }
            return Mac;
        }

        public static double RoundDown(double i, double decimalPlaces)
        {
            var power = Convert.ToDouble(Math.Pow(10, decimalPlaces));
            return Math.Floor(i * power) / power;
        }

        public static double GetTaxaServico(int idPdvCompra, double valorAPagar)
        {
            string qr = String.Format(@"DECLARE
	@idPdvCompra INT = {0},
	@valorAPagar DECIMAL(18, 2) = {1}

SELECT
	qr.*,
	CAST(( ((@valorAPagar / qr.totalVenda) * qr.totalVendaComTaxa) * 0.1) AS DECIMAL(15, 2)) taxa
FROM
(
	SELECT 
		pcc.idPdvCompra,
		CAST
		(
			SUM
			(
				CASE
					WHEN pse.aplicarTaxaServico = 1
						THEN ((IsNull(pcci.valor, 0) * IsNull(pcci.quantidade, 0)) - IsNull(pcci.desconto, 0))
						ELSE 0
				END
			) 
			AS DECIMAL(15, 2)
		) totalVendaComTaxa,
		CAST
		(
			SUM
			(
				((IsNull(pcci.valor, 0) * IsNull(pcci.quantidade, 0)) - IsNull(pcci.desconto, 0))
			) 
			AS DECIMAL(15, 2)
		) totalVenda
	FROM 
		pdvCompraCupomItem pcci
	INNER JOIN pdvCompraCupom pcc ON pcc.idPdvCompraCupom = pcci.idPdvCompraCupom
	INNER JOIN produtoServicoEmpresa pse ON pse.idProdutoServico = pcci.idProdutoServico AND pse.idEmpresa = 1
	WHERE
		pcc.idPdvCompra = @idPdvCompra
	GROUP BY
		pcc.idPdvCompra
) qr", idPdvCompra, valorAPagar.ToString("n2").Replace(".", "").Replace(",", "."));
            DataTable result = em.executeData(qr, null);
            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToDouble(result.Rows[0][3]);
            }

            return 0;
        }

        public static object getJsonValue(Dictionary<string, object> json, string key, int level = 0)
        {
            if (json != null)
                foreach (KeyValuePair<string, object> item in json)
                {
                    bool keyIsArray = key.Contains(".");
                    string _key = key.Split('.')[level];

                    var list = new List<KeyValuePair<string, object>>();
                    list.Add(new KeyValuePair<string, object>(item.Key, item.Value));
                    if (list.ToDictionary(x => x.Key, x => x.Value).ContainsKey(_key) && item.Value.GetType().Name.Contains("Dictionary"))
                    {
                        var dictionary = MyMethod<string, object>(item.Value);
                        return getJsonValue(dictionary, key, level + 1);
                    }
                    else
                    {
                        if (item.Key == _key)
                            return item.Value.ToString();
                        else { }
                    }
                }
            return null;
        }

        public static Dictionary<TKey, TValue> MyMethod<TKey, TValue>(object obj)
        {
            if (obj is Dictionary<TKey, TValue> stringDictionary)
            {
                return stringDictionary;
            }

            if (obj is IDictionary baseDictionary)
            {
                var dictionary = new Dictionary<TKey, TValue>();
                foreach (DictionaryEntry keyValue in baseDictionary)
                {
                    if (!(keyValue.Value is TValue))
                    {
                        // value is not TKey. perhaps throw an exception
                        return null;
                    }
                    if (!(keyValue.Key is TKey))
                    {
                        // value is not TValue. perhaps throw an exception
                        return null;
                    }

                    dictionary.Add((TKey)keyValue.Key, (TValue)keyValue.Value);
                }
                return dictionary;
            }
            // object is not a dictionary. perhaps throw an exception
            return null;
        }

        public static void ExecuteCMD(string file, string argument = null, bool showWindow = false, bool adminMode = true)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo = new ProcessStartInfo
                    {
                        FileName = file,
                        Arguments = argument,
                        CreateNoWindow = showWindow,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    if (adminMode)
                        proc.StartInfo.Verb = "runas";
                    else { }
                    proc.Start();
                };
                System.Threading.Thread.Sleep(2500);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static Data.Base instanceDataClass(string className, string property = null, object propertyValue = null)
        {
            string typeName = "Data." + className;
            Type typeArgument = Type.GetType(typeName);
            object created = Activator.CreateInstance(typeArgument);

            if (!String.IsNullOrEmpty(property) && propertyValue != null)
            {
                PropertyInfo prop = typeArgument.GetProperty(property);
                prop.SetValue(created, propertyValue, null);
            }

            Data.Base final = (Data.Base)Convert.ChangeType(created, typeArgument);
            return final;
        }

        public static void redirectError(string msg)
        {
            if (IsWebServer())
                HttpContext.Current.Response.Redirect("~/erro.aspx?error=" + Convert.ToBase64String(Encoding.ASCII.GetBytes(Security.EncryptRijndael(msg, Security.getInputKey()))));
            else { }
        }

        public static SizeF MeasureString(string s, Font font, int maxWidth = 0)
        {
            SizeF result;
            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    if (maxWidth == 0)
                        result = g.MeasureString(s, font);
                    else
                        result = g.MeasureString(s, font, maxWidth);
                }
            }

            return result;
        }

        public static string download(string _file, string _from)
        {
            try
            {
                string dir = HttpContext.Current.Server.MapPath(_from);
                ZipFile zip = new ZipFile();
                zip.AddFile(_file, "/");

                zip.Name = dir + System.IO.Path.GetFileNameWithoutExtension(_file) + ".zip";
                zip.Save();

                System.IO.FileInfo file = new System.IO.FileInfo(zip.Name);
                if (file.Exists)
                {
                    string script = String.Format("window.open('{0}','_blank')", ResolveUrl("../../" + _from + System.IO.Path.GetFileNameWithoutExtension(_file) + ".zip"));
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "newPage" + UniqueID, script, true);
                    return script;
                }
                else
                    throw new Exception("Não foi possível encontrar o arquivo de exportação!");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static long GetTimesTamp()
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long unixTime = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
            return unixTime;
        }

        public static string geraCodigoPatrimonial(string codigoPatrimonial, int idEmpresa, int idProdutoServicoPatrimonio)
        {
            Data.ProdutoServicoPatrimonio psp = new Data.ProdutoServicoPatrimonio
            {
                codigoPatrimonial = codigoPatrimonial,
                produtoServicoEmpresa = new Data.ProdutoServicoEmpresa
                {
                    idEmpresa = idEmpresa
                }
            };

            try
            {
                psp = (Data.ProdutoServicoPatrimonio)listaDados(idEmpresa, psp, 1, null)[0];
            }
            catch
            {
                psp = null;
            }

            if (psp == null || (psp != null && psp.idProdutoServicoPatrimonio == idProdutoServicoPatrimonio))
                return codigoPatrimonial;
            else { }

            return geraCodigoPatrimonial((ToUInt64(codigoPatrimonial) + 1).ToString(), idEmpresa, idProdutoServicoPatrimonio);
        }


        public static string getIdMenu(string pagina)
        {

            if (!String.IsNullOrEmpty(pagina))
            {
                Data.Menu m = new Data.Menu();
                m.pagina = new Data.Pagina { pagina = pagina };
                try
                {
                    m = (Data.Menu)listaDados(0, m, 1, null)[0]; //verificar
                }
                catch
                {
                    m = null;
                }
                if (m == null)
                    return null;
                else { }
                return m.idMenu.ToString();
            }
            else { }

            return null;
        }

        public static string GetPublicDir()
        {
#if DEBUG
            string dir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + "\\ClientApp\\public\\data\\";
#else
            string dir = AppDomain.CurrentDomain.BaseDirectory + "\\ClientApp\\build\\data\\";
#endif

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        public static string GetPublicDir(string rest)
        {
#if DEBUG
            string dir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)))) + "\\ClientApp\\public\\data\\" + rest + "\\";
#else
            string dir = AppDomain.CurrentDomain.BaseDirectory + "ClientApp\\build\\data\\" + rest + "\\";
#endif

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return dir;
        }

        public static CancellationTokenSource SetTimeout(Action action, int millis)
        {

            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            _ = Task.Run(() =>
            {
                Thread.Sleep(millis);
                if (!ct.IsCancellationRequested)
                    action();
            }, ct);

            return cts;
        }

        public static string getSqlConfigs()
        {
            string retorno = "workstation id=WorkingStation;packet size=4096;user id=hlc;data source=sqlserver.qualitysys.com.br;persist security info=False;initial catalog=taquaritinga;password=hlc;MultipleActiveResultSets=True";
            return retorno;
        }

        public static string getPixConfigs()
        {
            string retorno = "",
                   dir = AppDomain.CurrentDomain.BaseDirectory;


            if (!dir.Contains("bin") && !dir.Contains("api"))
                dir = dir + "bin\\";
            else if (dir.Contains("api"))
                dir = Path.GetDirectoryName(Path.GetDirectoryName(dir)) + "\\bin\\";

            if (File.Exists(dir + @"config.qlt"))
            {
                string encoded = File.ReadAllText(dir + @"config.qlt");
                string decoded = Security.DecryptRijndael(Security.Base64Decode(encoded), Security.getInputKey());
                try
                {
                    retorno = String.Format("{0};{1};{2};{3};{4}",
                        decoded.Split(';')[5].Trim(),
                        decoded.Split(';')[6].Trim(),
                        decoded.Split(';')[7].Trim(),
                        decoded.Split(';')[8].Trim(),
                        decoded.Split(';')[9].Trim());
                }
                catch (Exception e)
                {

                }
            }
            else { }
            return retorno;
        }

        public static System.Collections.Hashtable getSqlConfigs(string password)
        {
            if (password != "")
                return null;
            else { }

            System.Collections.Hashtable retorno = new System.Collections.Hashtable();
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            if (!dir.Contains("bin"))
                dir = dir + "bin\\";
            else { }

            if (File.Exists(dir + @"config.qlt"))
            {
                string encoded = File.ReadAllText(dir + @"config.qlt");
                string decoded = Security.DecryptRijndael(Security.Base64Decode(encoded), Security.getInputKey());
                retorno["usuario"] = decoded.Split(';')[1].Trim();
                retorno["servidor"] = decoded.Split(';')[0].Trim();
                retorno["database"] = decoded.Split(';')[3].Trim();
                retorno["senha"] = decoded.Split(';')[2].Trim();
            }
            else
            {
                criarConfigSql();
                retorno = getSqlConfigs("");
            }

            return retorno;
        }

        private static void criarConfigSql()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory,
                   _connectionString = "";

            if (!dir.Contains("bin"))
                dir = dir + "bin\\";
            else { }

            if (!File.Exists(dir + @"config.qlt"))
            {
                try
                {
                    string dirWebConfig = dir;
                    if (dirWebConfig.Contains("bin"))
                        dirWebConfig = Path.GetDirectoryName(Path.GetDirectoryName(dirWebConfig));
                    else { }

                    XmlDocument doc = new XmlDocument();
                    string currentAssemblyDirectoryName = dirWebConfig;
                    string filename = dirWebConfig + "\\Web.config";
                    doc.Load(filename);
                    XmlNode connectionStrings = doc.SelectSingleNode("/configuration/connectionStrings");

                    for (int i = 0; i < connectionStrings.ChildNodes[0].Attributes.Count; i++)
                    {
                        if (connectionStrings.ChildNodes[0].Attributes[i].Name == "connectionString")
                        {
                            _connectionString = connectionStrings.ChildNodes[0].Attributes[i].Value;
                            break;
                        }
                        else { }
                    }

                    string[] _cfg = _connectionString.Split(';');
                    if (_cfg != null && _cfg.Length > 0)
                    {
                        string _ds = _cfg[3].Split('=')[1],
                               _user = _cfg[2].Split('=')[1],
                               _senha = _cfg[6].Split('=')[1],
                               _db = _cfg[5].Split('=')[1];

                        string cfg = _ds + ";" + _user + ";" + _senha + ";" + _db;
                        string lines = Security.Base64Encode(Security.EncryptRijndael(cfg, Security.getInputKey()));
                        System.IO.StreamWriter file = new System.IO.StreamWriter(dir + @"config.qlt");
                        file.WriteLine(lines);
                        file.Close();

                        if (connectionStrings != null)
                        {
                            connectionStrings.ParentNode.RemoveChild(connectionStrings);
                            doc.Save(filename);
                        }
                        else { }
                    }
                    else { }
                }
                catch
                {
                    if (!IsdotnetCore())
                        redirectError("O arquivo de configuração do banco de dados não foi encontrado!<br />Entre em contato com o suporte da Quality Systems.");
                }
            }
            else { }
        }

        public static string abreviar(string word, int length = 10, bool abreviarPrimeiraPalavra = false)
        {
            string retorno = String.Empty;
            if (abreviarPrimeiraPalavra)
            {
                if (word.Contains(" "))
                    retorno += word.Split(' ')[0][0] + ". ";
                else { }
                if (word.Split(' ').Length > 1)
                    retorno += word.Split(' ')[1].Substring(0, (word.Split(' ')[1].Length > length ? length : word.Split(' ').Length));
                else { }
            }
            else
            {
                retorno += word.Substring(0, (word.Length > length ? length : word.Length));
            }

            return retorno;
        }

        public static void mudarEmpresa()
        {

            System.Web.SessionState.HttpSessionState session = System.Web.HttpContext.Current.Session;

            bool isMultiEmpresa = false;
            string li = "<div class='navbar-custom-menu'>";
            li += "<ul class='nav navbar-nav'>";
            li += "<li class='dropdown notifications-menu'>";
            li += "<a href= '#' class='dropdown-toggle' data-toggle='dropdown'>" + ((Data.Empresa)session["currentBusiness"]).pessoa.nomeRazaoSocial;
            li += " <span class='pull-right-container'><i class='fa fa-angle-down'></i></span>";
            li += "</a>";
            li += "        <ul class='dropdown-menu'>";
            li += "          <li>";
            li += "            <ul class='menu'>";
            if (((Data.Usuario)session["currentUser"]).usuarioEmpresas != null)
            {
                foreach (Data.UsuarioEmpresa _empresa in ((Data.Usuario)session["currentUser"]).usuarioEmpresas.Where(X => X.idEmpresa.idEmpresa != ((Data.Empresa)session["currentBusiness"]).idEmpresa))
                {
                    li += "<li><a href='#' class='mudarEmpresa' id='empresa_" + _empresa.idEmpresa.idEmpresa.ToString() + "'>" + _empresa.idEmpresa.pessoa.nomeRazaoSocial + "</a></li>";
                    isMultiEmpresa = true;
                }
            }
            else { }
            li += "            </ul>";
            li += "          </li>";
            li += "        </ul>";
            li += "      </li>";
            li += "    </ul>";
            li += "  </div>";

            if (isMultiEmpresa)
                session["empresasDiv"] = li;
            else
                session["empresasDiv"] = null;
        }

        public static Data.PerfilMenu perfilMenu(String idMenu, Object currentUser)
        {

            Data.PerfilMenu result = null;
            string casasDecimais = Update.getConfiguracoesGlobais("casasDecimaisMonetario");
            if (!String.IsNullOrEmpty(casasDecimais))
                if (ToInt(casasDecimais) != decimalPlaces)
                    decimalPlaces = ToInt(casasDecimais);
                else { }
            else { }

            string casasDecimaisQtd = Update.getConfiguracoesGlobais("casasDecimaisQuantidade");
            if (!String.IsNullOrEmpty(casasDecimaisQtd))
                if (ToInt(casasDecimaisQtd) != decimalPlacesQtd)
                    decimalPlacesQtd = ToInt(casasDecimaisQtd);
                else { }
            else { }

            string _hashTags = "";
            for (int i = 1; i <= decimalPlaces - 2; i++)
                _hashTags += "#";
            hashTags = _hashTags;
            if ((Data.Usuario)currentUser != null)
                foreach (Data.Perfil _perfil in ((Data.Usuario)currentUser).perfils)
                {
                    foreach (Data.PerfilMenu _perfilMenu in _perfil.perfilMenus)
                    {
                        if (_perfilMenu.idMenu == ToInt(idMenu))
                        {
                            if (result == null)
                                result = _perfilMenu;
                            else
                            {
                                result.alterar |= _perfilMenu.alterar;
                                result.consultar |= _perfilMenu.consultar;
                                result.excluir |= _perfilMenu.excluir;
                                result.incluir |= _perfilMenu.incluir;
                            }
                        }
                        else { }
                    }
                }

            return result;
        }

        public static void registryScript(System.Web.UI.Page page, String[] scriptsFilename)
        {
            String scriptBody = "";
            WebConfig.fixRelatoriosContasAPagar();

            foreach (String scriptFilename in scriptsFilename)
            {
                try
                {
                    System.IO.FileStream fs = new System.IO.FileStream
                    (
                        page.Request.PhysicalApplicationPath + "scripts\\" + scriptFilename + ".js",
                        System.IO.FileMode.Open
                    );

                    byte[] buffer = new byte[fs.Length];

                    fs.Read(buffer, 0, (int)fs.Length);
                    fs.Close();

                    scriptBody +=
                    (
                        ((scriptFilename != "XMLHttpSyncExecutor") && (scriptFilename != "MicrosoftAjax")) ?
                        normalizeScript(System.Text.ASCIIEncoding.UTF8.GetString(buffer)) :
                        System.Text.ASCIIEncoding.UTF8.GetString(buffer)
                    );
                }
                catch (Exception ex)
                {
                    scriptBody += "function " + scriptFilename + "(){/*" + page.Request.PhysicalApplicationPath + " -- " + ex.ToString() + "*/}";
                }
            }

            if (scriptBody.Length > 0)
            {
                scriptBody = ("<script type=\"text/javascript\">" + scriptBody + "</script>");

                page.ClientScript.RegisterClientScriptBlock(page.GetType(), scriptBody.GetHashCode().ToString(), scriptBody);
            }
            else { }
        }

        public static String normalizeScript(String buffer)
        {
            String result = "";

            Char
                _LiteralBlock = '\0';
            Boolean
                ignoreLine = false,
                ignoreBlock = false;

            for (int iChar = 0; iChar < buffer.Length; iChar++)
            {
                switch (buffer[iChar])
                {
                    case '/':
                        if (buffer[iChar + 1] == '/')
                        {
                            if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            {
                                ignoreLine = true;
                                iChar++;
                            }
                            else { }
                        }
                        else
                            if (buffer[iChar + 1] == '*')
                        {
                            ignoreBlock = true;
                            iChar++;
                        }
                        else
                                if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            result += buffer[iChar];
                        else { }
                        break;
                    case ';':
                        if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            result += buffer[iChar];
                        else { }
                        break;
                    case '*':
                        if (ignoreBlock)
                            if (buffer[iChar + 1] == '/')
                            {
                                ignoreBlock = false;
                                iChar++;
                            }
                            else { }
                        else
                            if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            result += buffer[iChar];
                        else { }
                        break;
                    case ' ':
                        if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                        {
                            if (_LiteralBlock != '\0')
                                result += buffer[iChar];
                            else
                            {
                                if (result.Length > 0)
                                    if ("aãâáàäbcçdeêéèëfghiîíìïjklmnñoõôóòöpqrstuûúùüvxwyz1234567890_".IndexOf(result.ToLower()[(result.Length - 1)]) >= 0)
                                        if ("aãâáàäbcçdeêéèëfghiîíìïjklmnñoõôóòöpqrstuûúùüvxwyz1234567890_".IndexOf(buffer.ToLower()[iChar + 1]) >= 0)
                                            result += " ";
                                        else { }
                                    else { }
                                else { }
                            }
                        }
                        else { }
                        break;
                    case '\t':
                    case '\r':
                    case '\n':
                    case '\a':
                        if (((buffer[iChar] == '\n') || (buffer[iChar] == '\r') || (buffer[iChar] == '\a')) && ignoreLine)
                            ignoreLine = false;
                        else
                        {
                            if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            {
                                if (_LiteralBlock != '\0')
                                    result += buffer[iChar];
                                else
                                {
                                    if (result.Length > 0)
                                        if ("aãâáàäbcçdeêéèëfghiîíìïjklmnñoõôóòöpqrstuûúùüvxwyz1234567890_".IndexOf(result.ToLower()[(result.Length - 1)]) >= 0)
                                            if ("aãâáàäbcçdeêéèëfghiîíìïjklmnñoõôóòöpqrstuûúùüvxwyz1234567890_".IndexOf(buffer.ToLower()[iChar + 1]) >= 0)
                                                result += " ";
                                            else { }
                                        else { }
                                    else { }
                                }
                            }
                            else { }
                        }
                        break;
                    case '\'':
                    case '\"':
                        if (_LiteralBlock == '\0')
                            _LiteralBlock = buffer[iChar];
                        else
                        {
                            if (_LiteralBlock == buffer[iChar])
                                _LiteralBlock = '\0';
                            else { }
                        }
                        if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            result += buffer[iChar];
                        else { }
                        break;
                    default:
                        if ((buffer[iChar] < 256) && (!(ignoreBlock || ignoreLine)))
                            result += buffer[iChar];
                        else { }
                        break;
                }
            }

            return result;
        }

        public static Object getValue(Object obj, String fieldName)
        {
            Object result = null;

            if (obj != null)
            {
                String
                    mFieldName = "m_" + fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1),
                    mIdFieldName = "m_Id" + fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);

                String[] _fields = null;

                foreach (TClassAttributeFields fa in obj.GetType().GetCustomAttributes(typeof(TClassAttributeFields), false))
                    _fields = fa.fields;

                if (_fields != null)
                {
                    String __fieldName = "";

                    foreach (String _fieldName in _fields)
                    {
                        if (_fieldName.StartsWith("."))
                        {
                            Type _objClass = obj.GetType();
                            __fieldName = _fieldName;

                            while (__fieldName.StartsWith("."))
                            {
                                _objClass = _objClass.BaseType;
                                __fieldName = __fieldName.Substring(1);
                            }

                            if
                            (
                                (__fieldName == mFieldName) ||
                                (__fieldName == mIdFieldName)
                            )
                            {
                                System.Reflection.FieldInfo _fi = _objClass.GetField
                                (
                                    __fieldName,
                                    (
                                        System.Reflection.BindingFlags.Instance |
                                        System.Reflection.BindingFlags.NonPublic |
                                        System.Reflection.BindingFlags.Public
                                    )
                                );

                                result = _fi.GetValue(obj);
                                break;
                            }
                            else { }
                        }
                        else
                            __fieldName = _fieldName;

                        if
                            (
                                (__fieldName == mFieldName) ||
                                (__fieldName == mIdFieldName)
                            )
                        {
                            System.Reflection.FieldInfo _fi = obj.GetType().GetField
                            (
                                __fieldName,
                                (
                                    System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Public
                                )
                            );

                            result = _fi.GetValue(obj);
                            break;
                        }
                        else { }
                    }
                }
                else
                {
                    System.Collections.Generic.List<Object> subFields = new List<Object>();

                    foreach (System.Reflection.PropertyInfo pi in obj.GetType().GetProperties())
                    {
                        if (pi.Name == fieldName)
                            result = pi.GetValue(obj, new Object[0]);
                        else
                        {
                            Object _obj = pi.GetValue(obj, new Object[0]);

                            if ((_obj != null) && (_obj.GetType().IsSubclassOf(typeof(Data.Base))))
                                subFields.Add(subFields); //result = getValue(_obj, fieldName);
                            else { }
                        }

                        if (result != null)
                            break;
                        else { }
                    }

                    if (result == null)
                    {
                        foreach (Object item in subFields)
                        {
                            result = getValue(item, fieldName);

                            if (result != null)
                                break;
                            else { }
                        }
                    }
                    else { }

                    subFields.Clear();
                    subFields = null;
                }
            }
            else { }

            return result;
        }

        public static String formataMascara(String mascara, Char sep = ',', bool useDecimalPlaces = false)
        {
            if (useDecimalPlaces)
            {
                int pos = mascara.IndexOf(sep);
                string first = mascara.Substring(0, pos) + sep.ToString().PadRight((decimalPlaces + 1), (sep == '.' ? '0' : '9'));
                return first;
            }
            else { }
            return mascara;
        }

        public static System.Collections.Generic.List<System.Reflection.PropertyInfo> retrieveProperties(Type objClass)
        {
            System.Collections.Generic.List<System.Reflection.PropertyInfo> result = null;

            if (objClass.Name != "Base")
            {
                result = retrieveProperties(objClass.BaseType);

                foreach
                (
                    System.Reflection.PropertyInfo _pi in objClass.GetProperties
                    (
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Public
                    )
                )
                {
                    if (result == null)
                        result = new List<System.Reflection.PropertyInfo>();
                    else { }

                    result.Add(_pi);
                }
            }
            else { }

            return result;
        }

        public static String retrieveFieldsValue(Object input, int level)
        {
            String Result = "";

            if (level > 0)
            {
                foreach (System.Reflection.FieldInfo fi in Utils.retrieveFields(input.GetType()))
                {
                    Object obj = fi.GetValue(input);

                    if (obj != null)
                    {
                        if (obj.GetType().IsSubclassOf(typeof(Data.Base)))
                        {
                            if
                            (
                                (obj.GetType().Name == "Pessoa") ||
                                (obj.GetType().Name == "PessoaFisica") ||
                                (obj.GetType().Name == "PessoaJuridica")
                            )
                                Result += (Result.Length > 0 ? ";" : "") + Utils.retrieveFieldsValue(obj, level - 1);
                            else
                                Result += (Result.Length > 0 ? ";" : "");
                        }
                        else
                            if (!obj.GetType().IsArray && (fi.Name != "m_Senha"))
                            Result += (Result.Length > 0 ? ";" : "") + obj.ToString();
                        else
                            Result += (Result.Length > 0 ? ";" : "");
                    }
                    else
                        Result += (Result.Length > 0 ? ";" : "");
                }
            }
            else { }

            return Result;
        }

        static int fieldInfoCompare(System.Reflection.FieldInfo a, System.Reflection.FieldInfo b)
        {
            return a.Name.CompareTo(b.Name);
        }

        public static System.Collections.Generic.List<System.Reflection.FieldInfo> retrieveFields(Type objClass)
        {
            System.Collections.Generic.List<System.Reflection.FieldInfo> result = null;

            if (objClass == null)
                return new List<System.Reflection.FieldInfo>();
            else { }

            if (objClass.Name != "Base")
            {
                result = retrieveFields(objClass.BaseType);

                foreach
                (
                    System.Reflection.FieldInfo _fi in objClass.GetFields
                    (
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Public
                    )
                )
                {
                    if (result == null)
                        result = new List<System.Reflection.FieldInfo>();
                    else { }

                    result.Add(_fi);
                }
            }
            else { }

            if (result != null)
                result.Sort(fieldInfoCompare);
            else { }

            return result;
        }

        public static Boolean setIdEmpresaField(Object obj, int idEmpresa)
        {
            String field = "";

            foreach (TClassAttributeBusinessIdField fa in obj.GetType().GetCustomAttributes(typeof(TClassAttributeBusinessIdField), false))
                field = fa.field;

            field = (String.IsNullOrEmpty(field) ? "m_IdEmpresa" : field);

            System.Reflection.FieldInfo fieldInfo = null;

            bool valueSetted = false;

            foreach (String token in field.Split('.'))
            {
                Type objType = obj.GetType();

                while (!valueSetted && (objType.Name != "Base"))
                {
                    if
                    (
                        (
                            fieldInfo = objType.GetField
                            (
                                token,
                                (
                                    System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Public
                                )
                            )
                        ) != null
                    )
                    {
                        if ((field == fieldInfo.Name) || field.EndsWith("." + fieldInfo.Name))
                        {
                            fieldInfo.SetValue(obj, idEmpresa);
                            valueSetted = true;
                            break;
                        }
                        else
                        {
                            if (fieldInfo.GetValue(obj) == null)
                            {
                                fieldInfo.SetValue
                                (
                                    obj,
                                    fieldInfo.FieldType.GetConstructor(new Type[0]).Invoke(new Object[0])
                                );
                            }
                            else { }

                            obj = fieldInfo.GetValue(obj);
                            break;
                        }
                    }
                    else
                        objType = objType.BaseType;
                }

                if (valueSetted)
                    break;
                else { }
            }

            return valueSetted;
        }

        public static System.Reflection.FieldInfo retrieveFieldInfo(Type objClass, String fieldName, System.Collections.ArrayList visitedObjClasses = null)
        {
            System.Reflection.FieldInfo result = null;

            Boolean firstEntry = (visitedObjClasses == null);

            if (objClass.Name != "Base")
            {
                String[] _fields = null;

                if (visitedObjClasses == null)
                    visitedObjClasses = new System.Collections.ArrayList();
                else { }

                if (!visitedObjClasses.Contains(objClass))
                {
                    visitedObjClasses.Add(objClass);

                    foreach (TClassAttributeFields fa in objClass.GetCustomAttributes(typeof(TClassAttributeFields), false))
                        _fields = fa.fields;

                    if (_fields != null)
                    {
                        String __fieldName = "";

                        foreach (String _fieldName in _fields)
                        {
                            if (_fieldName.StartsWith("."))
                            {
                                Type _objClass = objClass;
                                __fieldName = _fieldName;

                                while (__fieldName.StartsWith("."))
                                {
                                    _objClass = _objClass.BaseType;
                                    __fieldName = __fieldName.Substring(1);
                                }

                                if (__fieldName == fieldName)
                                {
                                    result = _objClass.GetField
                                    (
                                        fieldName,
                                        (
                                            System.Reflection.BindingFlags.Instance |
                                            System.Reflection.BindingFlags.NonPublic |
                                            System.Reflection.BindingFlags.Public
                                        )
                                    );
                                    break;
                                }
                                else { }
                            }
                            else
                            {
                                if (_fieldName == fieldName)
                                {
                                    result = objClass.GetField
                                    (
                                        fieldName,
                                        (
                                            System.Reflection.BindingFlags.Instance |
                                            System.Reflection.BindingFlags.NonPublic |
                                            System.Reflection.BindingFlags.Public
                                        )
                                    );
                                    break;
                                }
                                else { }
                            }
                        }
                    }
                    else
                    {
                        result = retrieveFieldInfo(objClass.BaseType, fieldName);

                        System.Collections.ArrayList objClasses = new System.Collections.ArrayList();

                        if (result == null)
                        {
                            foreach
                            (
                                System.Reflection.FieldInfo fi in objClass.GetFields
                                (
                                    System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Public
                                )
                            )
                            {
                                if (fi.Name == fieldName)
                                    result = fi;
                                else
                                    if (fi.FieldType.IsSubclassOf(typeof(Data.Base)) && (fi.FieldType.Name != objClass.Name))
                                    //result = retrieveFieldInfo(fi.FieldType, fieldName);
                                    objClasses.Add(fi.FieldType);
                                else { }

                                if (result != null)
                                    break;
                                else { }
                            }

                            if (result == null)
                            {
                                for (int i = 0; i < objClasses.Count; i++)
                                {
                                    result = retrieveFieldInfo((System.Type)objClasses[i], fieldName, visitedObjClasses);

                                    if (result != null)
                                        break;
                                    else { }
                                }
                            }
                            else { }
                        }
                        else { }
                    }
                }
            }
            else { }

            if (firstEntry && (visitedObjClasses != null))
            {
                visitedObjClasses.Clear();
                visitedObjClasses = null;
            }
            else { }

            return result;
        }

        public static Dictionary<string, object> loadJson(string jsonFilePath)
        {
            try
            {
                string json = jsonFilePath;
                Dictionary<string, object> json_Dictionary = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(json);
                return json_Dictionary;
            }
            catch
            {
                return null;
            }
        }
        public static String RetrieveClassDefaultOrderBy(Type objClass, int idReport)
        {
            String result = "";

            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
                Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");

                System.Xml.XmlNode _filter = Utils.FieldAttributes[objClass.Name + "_" + idReport.ToString()] ?? Utils.FieldAttributes[objClass.Name];

                if
                (
                    (objClass != null) &&
                    (_filter != null) &&
                    (_filter.Attributes != null) &&
                    (_filter.Attributes["value"] != null)
                )
                {
                    result = _filter.Attributes["value"].Value;

                    if (result.ToLower().StartsWith("sql:"))
                        result = result.Substring(4);
                    else
                        if (!result.Contains("."))
                        result = objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + result;
                    else { }


                    if ((_filter.Attributes["forceOrder"] != null))
                        result = "ForceOrder:" + result;
                    else { }
                }
                else { }
            }
            catch { }

            return result;
        }

        public static String RetrieveClassDefaultCondition(Type objClass, int idReport)
        {
            String result = "";

            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
                Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");

                System.Xml.XmlNode _filter = Utils.FieldAttributes[objClass.Name + "_" + idReport.ToString()] ?? Utils.FieldAttributes[objClass.Name];

                if
                (
                    (objClass != null) &&
                    (_filter != null) &&
                    (_filter.Attributes != null) &&
                    (_filter.Attributes["condition"] != null)
                )
                    result = _filter.Attributes["condition"].Value;
                else { }
            }
            catch { }

            return result;
        }

        public static String RetrieveClassDefaultAttribute(Type objClass, int idReport, String attributeName)
        {
            String result = "";

            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
                Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");

                System.Xml.XmlNode _filter = Utils.FieldAttributes[objClass.Name + "_" + idReport.ToString()] ?? Utils.FieldAttributes[objClass.Name];

                if
                (
                    (objClass != null) &&
                    (_filter != null) &&
                    (_filter.Attributes != null) &&
                    (_filter.Attributes[attributeName] != null)
                )
                    result = _filter.Attributes[attributeName].Value;
                else { }
            }
            catch { }

            return result;
        }

        public static String[] RetrieveFilters(Type objClass, int idReport)
        {
            String[] result = null;


            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
            Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");


            System.Xml.XmlNode _filter = Utils.FieldAttributes[objClass.Name + "_" + idReport.ToString()] ?? Utils.FieldAttributes[objClass.Name];

            if (_filter != null)
            {
                if (_filter.Attributes["filters"] != null)
                    result = _filter.Attributes["filters"].Value.Replace(", ", ",").Split(',');
                else
                {
                    String _result = "";

                    foreach (System.Xml.XmlNode child in _filter.ChildNodes)
                        _result += (_result.Length == 0 ? "" : ",") + child.Name;

                    result = _result.Split(',');
                }
            }
            else { }

            return result;
        }

        public static Field RetrieveFieldFilterAttributes(Type objClass, String fieldName, int idReport)
        {
            Field result = null;

            String
                //fieldName = field.Name.Substring(2, 1).ToLower() + field.Name.Substring(3),
                fieldGridDisplayText = "",
                fieldEditDisplayText = "",
                fieldSubFieldName = "",
                fieldViewFormat = "",
                fieldEditFormat = "",
                fieldReportFilterName = "",
                fieldReportFilterMask = "",
                fieldReportFilterEntryFormat = "",
                fieldReportFilterValueFormat = "",
                fieldReportFilterValues = "",
                fieldReportFilterWhereColumn = "";

            int
                fieldGridDisplaySize = 0,
                fieldEditDisplaySize = 0,
                fieldLength = 0,
                fieldReportFieldSize = 0;

            bool
                fieldKey = false,
                fieldRequired = false,
                fieldEnabled = false,
                fieldOboutDropBox = false,
                fieldAutogenerated = false,
                anyAttribute = false,
                fieldReportAllowInterval = false,
                fieldCargaParcial = false,
                fielduseDecimalPlaces = true,
                fieldShow = true;


            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
            Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");


            System.Xml.XmlNode _filter = Utils.FieldAttributes[objClass.Name + "_" + idReport.ToString()] ?? Utils.FieldAttributes[objClass.Name];

            if
                (
                    (objClass != null) &&
                    (_filter != null) &&
                    (_filter[fieldName] != null)
                )
            {
                anyAttribute = true;

                if (_filter[fieldName].Attributes != null)
                {
                    if (_filter[fieldName].Attributes["label"] != null)
                        fieldReportFilterName = _filter[fieldName].Attributes["label"].Value;
                    else { }
                    if (_filter[fieldName].Attributes["mask"] != null)
                        fieldReportFilterMask = _filter[fieldName].Attributes["mask"].Value;
                    else { }
                    if (_filter[fieldName].Attributes["entryFormat"] != null)
                        fieldReportFilterEntryFormat = _filter[fieldName].Attributes["entryFormat"].Value;
                    else { }
                    if (_filter[fieldName].Attributes["valueFormat"] != null)
                        fieldReportFilterValueFormat = _filter[fieldName].Attributes["valueFormat"].Value;
                    else { }
                    if (_filter[fieldName].Attributes["size"] != null)
                        fieldReportFieldSize = Utils.ToInt(_filter[fieldName].Attributes["size"].Value);
                    else { }
                    if (_filter[fieldName].Attributes["allowMultiValue"] != null)
                        fieldReportAllowInterval = Utils.ToBoolean(_filter[fieldName].Attributes["allowMultiValue"].Value);
                    else { }
                    if (_filter[fieldName].Attributes["options"] != null)
                        fieldReportFilterValues = _filter[fieldName].Attributes["options"].Value;
                    else { }
                    if (_filter[fieldName].Attributes["SQL"] != null)
                    {
                        fieldReportFilterWhereColumn = _filter[fieldName].Attributes["SQL"].Value;

                        if (!fieldReportFilterWhereColumn.Contains("."))
                            fieldReportFilterWhereColumn = objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + fieldReportFilterWhereColumn;
                        else { }
                    }
                    else { }
                }
                else { }

                if (anyAttribute)
                    result = new Field
                    (
                        fieldKey,
                        fieldName, //.Substring(2, 1).ToLower() + fieldName.Substring(3),
                        fieldGridDisplayText,
                        fieldGridDisplaySize,
                        fieldEditDisplayText,
                        fieldEditDisplaySize,
                        fieldLength,
                        fieldRequired,
                        fieldEnabled,
                        fieldOboutDropBox,
                        fieldAutogenerated,
                        fieldSubFieldName,
                        fieldCargaParcial,
                        fieldViewFormat,
                        fieldEditFormat,
                        fielduseDecimalPlaces,
                        fieldShow,
                        fieldReportFilterName,
                        fieldReportFilterMask,
                        fieldReportFilterEntryFormat,
                        fieldReportFilterValueFormat,
                        fieldReportFieldSize,
                        fieldReportAllowInterval,
                        fieldReportFilterValues,
                        fieldReportFilterWhereColumn
                    );
                else { }
            }
            else { }

            return result;
        }

        public static Field RetrieveFieldAttributes(System.Reflection.FieldInfo field, Type objClass = null, int? id = null)
        {
            Field result = null;

            if (field != null)
            {
                try
                {
                    String
                        fieldName = field.Name.Substring(2, 1).ToLower() + field.Name.Substring(3),
                        fieldGridDisplayText = "",
                        fieldEditDisplayText = "",
                        fieldSubFieldName = "",
                        fieldViewFormat = "",
                        fieldEditFormat = "",
                        fieldReportFilterName = "",
                        fieldReportFilterMask = "",
                        fieldReportFilterEntryFormat = "",
                        fieldReportFilterValueFormat = "",
                        fieldReportFilterValues = "",
                        fieldReportFilterWhereColumn = "";

                    int
                        fieldGridDisplaySize = 0,
                        fieldEditDisplaySize = 0,
                        fieldLength = 0,
                        fieldReportFieldSize = 0;

                    bool
                        fieldKey = false,
                        fieldRequired = false,
                        fieldEnabled = false,
                        fieldOboutDropBox = false,
                        fieldAutogenerated = false,
                        fieldReportAllowInterval = false,
                        fieldCargaParcial = false,
                        fielduseDecimalPlaces = true,
                        fieldShow = true;

                    if (objClass != null)
                    {

                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
                        Utils.FieldAttributes = doc.SelectSingleNode("/FieldAttributes");


                        String objClassName = objClass.Name;

                        if
                        (
                            (objClass != null) &&
                            (Utils.FieldAttributes[objClass.Name + (id != null ? ("_" + id.Value.ToString()) : "")] != null)
                        )
                            objClassName = objClass.Name + (id != null ? ("_" + id.Value.ToString()) : "");
                        else { }

                        if
                            (
                                (objClass != null) &&
                                (Utils.FieldAttributes[objClassName] != null) &&
                                (Utils.FieldAttributes[objClassName][field.Name] != null)
                            )
                        {

                            if (Utils.FieldAttributes[objClassName][field.Name].Attributes != null)
                            {
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["label"] != null)
                                    fieldReportFilterName = Utils.FieldAttributes[objClassName][field.Name].Attributes["label"].Value;
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["mask"] != null)
                                    fieldReportFilterMask = Utils.FieldAttributes[objClassName][field.Name].Attributes["mask"].Value;
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["entryFormat"] != null)
                                    fieldReportFilterEntryFormat = Utils.FieldAttributes[objClassName][field.Name].Attributes["entryFormat"].Value;
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["valueFormat"] != null)
                                    fieldReportFilterValueFormat = Utils.FieldAttributes[objClassName][field.Name].Attributes["valueFormat"].Value;
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["size"] != null)
                                    fieldReportFieldSize = Utils.ToInt(Utils.FieldAttributes[objClassName][field.Name].Attributes["size"].Value);
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["allowMultiValue"] != null)
                                    fieldReportAllowInterval = Utils.ToBoolean(Utils.FieldAttributes[objClassName][field.Name].Attributes["allowMultiValue"].Value);
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["options"] != null)
                                    fieldReportFilterValues = Utils.FieldAttributes[objClassName][field.Name].Attributes["options"].Value;
                                else { }
                                if (Utils.FieldAttributes[objClassName][field.Name].Attributes["SQL"] != null)
                                {
                                    fieldReportFilterWhereColumn = Utils.FieldAttributes[objClassName][field.Name].Attributes["SQL"].Value;

                                    if (!fieldReportFilterWhereColumn.Contains("."))
                                        fieldReportFilterWhereColumn = objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + fieldReportFilterWhereColumn;
                                    else { }
                                }
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }

                    foreach (Object fa in field.GetCustomAttributes(typeof(System.Attribute), false))
                    {
                        if (fa is TFieldAttributeData)
                        {
                            fieldLength = ((TFieldAttributeData)fa).length;
                            fieldRequired = ((TFieldAttributeData)fa).required;
                            fieldEnabled = ((TFieldAttributeData)fa).enabled;
                            fieldOboutDropBox = ((TFieldAttributeData)fa).oboutDropBox;
                        }
                        else
                        {
                            if (fa is TFieldAttributeGridDisplay)
                            {
                                fieldGridDisplayText = ((TFieldAttributeGridDisplay)fa).displayText;
                                fieldGridDisplaySize = ((TFieldAttributeGridDisplay)fa).displaySize;
                            }
                            else
                            {
                                if (fa is TFieldAttributeEditDisplay)
                                {
                                    fieldEditDisplayText = ((TFieldAttributeEditDisplay)fa).displayText;
                                    fieldEditDisplaySize = ((TFieldAttributeEditDisplay)fa).displaySize;
                                }
                                else
                                {
                                    if (fa is TFieldAttributeKey)
                                    {
                                        fieldKey = ((TFieldAttributeKey)fa).key;
                                        fieldAutogenerated = ((TFieldAttributeKey)fa).autogenerated;
                                    }
                                    else
                                    {
                                        if (fa is TFieldAttributeSubfield)
                                        {
                                            fieldSubFieldName = ((TFieldAttributeSubfield)fa).subFieldName;
                                            fieldCargaParcial = ((TFieldAttributeSubfield)fa).cargaParcial;

                                            if
                                            (
                                                (fieldSubFieldName.Length > 0) &&
                                                (
                                                    (!fieldSubFieldName.StartsWith("ItemGenerico")) &&
                                                    (!fieldSubFieldName.Contains(":@"))
                                                ) &&
                                                fieldName.ToLower().StartsWith("id")
                                            )
                                                fieldName = fieldName.Substring(2, 1).ToLower() + fieldName.Substring(3);
                                            else { }
                                        }
                                        else
                                        {
                                            if (fa is TFieldAttributeFormat)
                                            {
                                                fieldViewFormat = ((TFieldAttributeFormat)fa).viewFormat;
                                                fieldEditFormat = ((TFieldAttributeFormat)fa).editFormat;
                                                fielduseDecimalPlaces = ((TFieldAttributeFormat)fa).useDecimalPlaces;
                                                fieldShow = ((TFieldAttributeFormat)fa).showField;
                                            }
                                            else { }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    result = new Field
                    (
                        fieldKey,
                        fieldName,
                        fieldGridDisplayText,
                        fieldGridDisplaySize,
                        fieldEditDisplayText,
                        fieldEditDisplaySize,
                        fieldLength,
                        fieldRequired,
                        fieldEnabled,
                        fieldOboutDropBox,
                        fieldAutogenerated,
                        fieldSubFieldName,
                        fieldCargaParcial,
                        fieldViewFormat,
                        fieldEditFormat,
                        fielduseDecimalPlaces,
                        fieldShow,
                        fieldReportFilterName,
                        fieldReportFilterMask,
                        fieldReportFilterEntryFormat,
                        fieldReportFilterValueFormat,
                        fieldReportFieldSize,
                        fieldReportAllowInterval,
                        fieldReportFilterValues,
                        ((String.IsNullOrWhiteSpace(fieldReportFilterWhereColumn) && (objClass != null)) ? (objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + fieldName) : fieldReportFilterWhereColumn)
                    );
                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.ToString());
                }
            }
            else { }

            return result;
        }

        public static int ToInt(String value)
        {
            int result = 0;

            if (!String.IsNullOrEmpty(value))
                int.TryParse((value == null ? "0" : value.Trim().Replace("*", "").Replace("/", "")), out result);
            else { }

            return result;
        }

        public static System.UInt64 ToUInt64(String value)
        {
            System.UInt64 result = 0;

            if (!String.IsNullOrEmpty(value))
                System.UInt64.TryParse((value == null ? "0" : value.Trim().Replace("*", "").Replace("/", "")), out result);
            else { }

            return result;
        }

        public static Boolean ToBoolean(String value)
        {
            Boolean result = false;

            if (!String.IsNullOrEmpty(value))
                Boolean.TryParse((value == null ? "false" : value.Trim().ToLower().Replace("*", "").Replace("/", "")), out result);
            else { }

            return result;
        }

        public static long ToLong(String value)
        {
            long result = 0;

            if (!String.IsNullOrEmpty(value))
                long.TryParse((value == null ? "0" : value.Trim().Replace("*", "").Replace("/", "")), out result);
            else { }

            return result;
        }

        public static Double ToDouble(String value)
        {
            Double result = 0;

            if (!String.IsNullOrEmpty(value))
                Double.TryParse((value == null ? "0" : value.Trim().Replace("*", "").Replace("/", "")), out result);
            else { }

            return result;
        }

        public static DateTime ToDate(String value)
        {
            DateTime result;

            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace('-', '/').Trim();
                try
                {
                    if (value.Substring(value.LastIndexOf('/') + 1).Length == 4)
                        result = DateTime.ParseExact(value.Trim(), "dd/MM/yyyy", new System.Globalization.CultureInfo("pt-BR", true));
                    else
                        result = DateTime.ParseExact(value.Trim(), "yyyy/MM/dd", new System.Globalization.CultureInfo("en-US", true));
                }
                catch
                {
                    result = new DateTime(0);
                }
            }
            else
                result = new DateTime(0);

            return result;
        }


        public static Object GetPropValue(Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                System.Reflection.PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }
            return (T)retval;
        }

        public static DateTime ToDateTime(String value)
        {
            DateTime result;

            if (!String.IsNullOrEmpty(value))
            {
                value = value.Replace('-', '/').Trim();
                try
                {
                    if ((value.Substring(2, 1) == "/") && (value.Substring(5, 1) == "/"))
                        result = DateTime.ParseExact(value.Trim(), "dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("pt-BR", true));
                    else
                        result = DateTime.ParseExact(value.Trim(), "yyyy/MM/dd HH:mm", new System.Globalization.CultureInfo("en-US", true));
                }
                catch
                {
                    result = new DateTime(0);
                }

            }
            else
                result = new DateTime(0);

            return result;
        }

        public static DateTime ToTime(String value)
        {
            DateTime result;

            if (!String.IsNullOrEmpty(value))
            {
                try
                {
                    result = DateTime.ParseExact(value.Trim(), "hh:mm:ss", new System.Globalization.CultureInfo("pt-BR", true));
                }
                catch
                {
                    result = new DateTime(0);
                }
            }
            else
                result = new DateTime(0);

            return result;
        }

        public static String RecordSign(Object obj, int level)
        {
            String result = "";

            try
            {
                Object _section = System.Configuration.ConfigurationManager.GetSection("appSettings");

                if (_section != null)
                {
                    String signatureSeed = (String)_section.GetType().GetProperty("Item", new Type[] { typeof(System.String) }).GetValue(_section, new object[] { "SignatureSeed" });
                    if (String.IsNullOrEmpty(signatureSeed))
                        signatureSeed = "kn7Dp4xuvc7q/tspiS+nxQ==";
                    if (signatureSeed.Length > 0)
                    {
                        signatureSeed = (new Base64()).decode(signatureSeed);
                        String sign = Utils.retrieveFieldsValue(obj, level);

                        result = (new Base64()).encode
                        (
                            (new RC6()).encrypt
                            (
                                signatureSeed,
                                (new MD5()).digest(sign)
                            )
                        );
                    }
                    else { }
                }
                else { }
            }
            catch (Exception ex)
            {
                Utils.WriteLog(ex.ToString());
            }

            return result;
        }

        public static string RandomString(int length, bool withoutSpecialChars = false)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%*()-+=";

            if (withoutSpecialChars)
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void ShowErrorMessage(String operation, String message, System.Web.UI.WebControls.Table errorContainer)
        {
            System.Web.UI.WebControls.Table t = errorContainer;
            t.Rows.Add(new System.Web.UI.WebControls.TableRow());
            System.Web.UI.WebControls.TableCell tCell = new System.Web.UI.WebControls.TableCell();
            t.Rows[t.Rows.Count - 1].Cells.Add(tCell);
            tCell.Text = operation + " -> " + message;
            tCell.Attributes.Add("style", "color:Red;");
        }

        public static void ShowErrorMessage(String Message, System.Web.UI.HtmlControls.HtmlGenericControl div)
        {
            div.Parent.Visible = true;
            div.InnerHtml = Message;
        }

        public static void ShowErrorMessage(String Message, System.Web.UI.WebControls.Panel div, string style = "danger")
        {
            div.Visible = true;
            div.Controls.Add(new LiteralControl("<p id=\"pText\">" + Message + "</p>"));
            div.CssClass = "callout callout-" + style;
            ScriptManager.RegisterStartupScript(div.Page, div.Page.GetType(), (div.ClientID + div.Parent.ClientID), "$(\"html, body\").animate({ scrollTop: 0 }, \"slow\");", true);
        }

        public static void ShowSuccessMessage(String Message, System.Web.UI.WebControls.Panel div)
        {
            div.Visible = true;
            ScriptManager.RegisterStartupScript(div.Page, div.Page.GetType(), (div.ClientID + div.Parent.ClientID), "$(\"html, body\").animate({ scrollTop: 0 }, \"slow\");", true);
            div.Controls.Add(new LiteralControl("<p>" + Message + "</p>"));
        }

        public static void ClearErrorMessage(System.Web.UI.HtmlControls.HtmlGenericControl div)
        {
            div.Parent.Visible = false;
        }

        public static System.Web.UI.Control ShowErrorMessage(String operation, String message, int top = -1)
        {
            System.Web.UI.WebControls.Table t = new System.Web.UI.WebControls.Table();
            if (top >= 0)
                t.Attributes.Add("style", "position:absolute;top:" + top + "px;");
            else { }
            t.Rows.Add(new System.Web.UI.WebControls.TableRow());
            System.Web.UI.WebControls.TableCell tCell = new System.Web.UI.WebControls.TableCell();
            t.Rows[t.Rows.Count - 1].Cells.Add(tCell);
            tCell.Text = operation + " -> " + message;
            tCell.Attributes.Add("style", "color:Red;");

            return t;
        }
        #region Log
        public static bool IsWebServer()
        {
            bool result = false;

            try
            {
                Assembly web = Assembly.Load("System.Web.HttpRequest");
                if (!String.IsNullOrEmpty(web.FullName)) { }
            }
            catch
            {
                try
                {
                    foreach (var f in (new System.Diagnostics.StackTrace().GetFrames()))
                    {
                        result = (f.GetMethod().ReflectedType?.Assembly.ManifestModule.Name.ToLower() == "hlc2010.dll");

                        if (result)
                            break;
                        else { }
                    }
                }
                catch { }
            }

            return result;
        }


        public static void WriteQueries(String message)
        {
            Boolean isWebServer = IsWebServer();

            try
            {
                bool saveLog = true;

                if (isWebServer)
                {
                    if (!String.IsNullOrEmpty(Update.getConfiguracoesGlobais("saveLog")))
                        saveLog = Utils.ToBoolean(Update.getConfiguracoesGlobais("saveLog"));
                    else { }
                }
                else
                {
                    if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["saveLog"]))
                        saveLog = Utils.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["saveLog"]);
                    else { }
                }

                if (saveLog)
                {
                    String
                        _logPath = "",
                        _date = DateTime.Now.ToString("yyyy.MM.dd");

                    _logPath = (isWebServer ? System.Configuration.ConfigurationManager.AppSettings["LogPath"] : (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QualityERP\\log\\"));

                    if (!System.IO.Directory.Exists(_logPath))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(_logPath);
                        }
                        catch
                        {
                            _logPath = "";
                        }
                    }
                    else { }

                    if (!String.IsNullOrWhiteSpace(_logPath))
                    {
                        System.IO.StreamWriter fs = new System.IO.StreamWriter
                        (
                            (
                                _logPath +
                                (
                                    (
                                        (_logPath[_logPath.Length - 1] == '\\') ||
                                        (_logPath[_logPath.Length - 1] == '/')
                                    ) ?
                                    "" :
                                    "\\"
                                ) +
                                "logQueries_" +
                                _date +
                                ".log"
                            ),
                            true
                        );

                        fs.WriteLine(String.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), message));

                        fs.Flush();

                        fs.Close();

                        fs.Dispose();

                        fs = null;
                    }
                    else { }
                }
                else { }
            }
            catch { }
        }

        public static void WriteLog(String message)
        {
            Boolean isWebServer = IsWebServer();

            try
            {
                bool saveLog = true;

                if (IsdotnetCore())
                    saveLog = true;
                else if (isWebServer)
                {
                    if (!String.IsNullOrEmpty(Update.getConfiguracoesGlobais("saveLog")))
                        saveLog = Utils.ToBoolean(Update.getConfiguracoesGlobais("saveLog"));
                    else { }
                }
                else
                {
                    if (!String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["saveLog"]))
                        saveLog = Utils.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["saveLog"]);
                    else { }
                }

                if (saveLog)
                {
                    String
                        _logPath = "",
                        _date = DateTime.Now.ToString("yyyy.MM.dd");

                    _logPath = (isWebServer ? System.Configuration.ConfigurationManager.AppSettings["LogPath"] : (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\QualityERP\\log\\"));
                    if (IsdotnetCore())
                        _logPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\log\\";


                    if (!System.IO.Directory.Exists(_logPath))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(_logPath);
                        }
                        catch
                        {
                            _logPath = "";
                        }
                    }
                    else { }

                    if (!String.IsNullOrWhiteSpace(_logPath))
                    {
                        System.IO.StreamWriter fs = new System.IO.StreamWriter
                        (
                            (
                                _logPath +
                                (
                                    (
                                        (_logPath[_logPath.Length - 1] == '\\') ||
                                        (_logPath[_logPath.Length - 1] == '/')
                                    ) ?
                                    "" :
                                    "\\"
                                ) +
                                "log_" +
                                _date +
                                ".log"
                            ),
                            true
                        );

                        fs.WriteLine(String.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), message));

                        fs.Flush();

                        fs.Close();

                        fs.Dispose();

                        fs = null;
                    }
                    else { }
                }
                else { }
            }
            catch { }
        }

        public static void WriteLogPDV(String message)
        {
            WriteLog(message);
            /*
            try
            {
                bool saveLog = true;

                if (!String.IsNullOrEmpty(Update.getConfiguracoesGlobais("saveLogPDV")))
                    saveLog = Utils.ToBoolean(Update.getConfiguracoesGlobais("saveLogPDV"));
                else { }

                if (!saveLog)
                    return;
                else { }

                String
                    _logPath = "",
                    _date = DateTime.Now.ToString("yyyy.MM.dd");

                Object _section = System.Configuration.ConfigurationManager.GetSection("appSettings");

                if (_section != null)
                {
                    _logPath = (String)_section.GetType().GetProperty("Item", new Type[] { typeof(System.String) }).GetValue(_section, new object[] { "LogPath" });

                    if ((_logPath != null) && (_logPath.Length > 0))
                    {
                        System.IO.StreamWriter fs = new System.IO.StreamWriter
                        (
                            (
                                _logPath +
                                (
                                    (
                                        (_logPath[_logPath.Length - 1] == '\\') ||
                                        (_logPath[_logPath.Length - 1] == '/')
                                    ) ?
                                    "" :
                                    "\\"
                                ) +
                                "log_" +
                                _date +
                                ".log"
                            ),
                            true
                        );

                        fs.WriteLine(String.Format("{0} - {1}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), message));

                        fs.Flush();

                        fs.Close();

                        fs.Dispose();

                        fs = null;
                    }
                    else { }

                    _section = null;
                }
                else { }
            }
            catch { }*/
        }
        #endregion

        public static int countRows(String tableName, String where, String join)
        {

            string query = "SELECT COUNT(1) FROM " + tableName;
            query += join;
            query += where.Length > 0 ? " WHERE " + where : "";
            try
            {
                System.Data.DataTable execQuery = Utils.em.executeData(query, null);
                return Utils.ToInt(execQuery.Rows[0][0].ToString());
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return 0;
        }

        #region Funções utilitárias de tabela
        public static void HighLightRow(System.Web.UI.WebControls.GridViewRowEventArgs e, string OriginalColor, string OnMouseOverColor, string OriginalFontColor, string onMouseOverFontColor)
        {
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add
                (
                    "onmouseover",
                    "this.style.background='" + OnMouseOverColor + "';this.style.color='" + onMouseOverFontColor + "';"
                );
                e.Row.Attributes.Add
                (
                    "onmouseout",
                    "this.style.background='" + OriginalColor + "';this.style.color='" + OriginalFontColor + "';"
                );
            }
            else { }
        }

        public static string colorToString(System.Drawing.Color color)
        {
            string
                R = Convert.ToString((int)color.R, 16),
                G = Convert.ToString((int)color.G, 16),
                B = Convert.ToString((int)color.B, 16);

            return
            (
                "#" +
                R.PadLeft(2, '0') +
                G.PadLeft(2, '0') +
                B.PadLeft(2, '0')
            );
        }
        #endregion

        public static System.Collections.Generic.List<Data.Base> listaDados(long idEmpresa, Data.Base data, String filter, Object[] parametros)
        {
            System.Collections.Generic.List<Data.Base> result = new List<Data.Base>();

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                {
                    String
                        _filter = filter,
                        keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!keys.Contains("[" + _key + "]"))
                        {
                            EJB.TableBase.TField _fieldValue = null;
                            Object _value = parametros[_parametros.Count];

                            switch (_value.GetType().Name)
                            {
                                case "DateTime":
                                    _fieldValue = new EJB.TableBase.TFieldDatetime(_key.Substring(1), System.Convert.ToDateTime(_value));
                                    break;

                                case "Int16":
                                case "Int32":
                                case "Int64":
                                    _fieldValue = new EJB.TableBase.TFieldInteger(_key.Substring(1), System.Convert.ToInt32(_value));
                                    break;

                                case "Float":
                                case "Double":
                                    _fieldValue = new EJB.TableBase.TFieldDouble(_key.Substring(1), System.Convert.ToDouble(_value));
                                    break;

                                default:
                                    _fieldValue = new EJB.TableBase.TFieldString(_key.Substring(1), _value.ToString());
                                    break;
                            }

                            _parametros.Add(new NameValue(_key, _fieldValue));
                            keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                _parametros.Add(new NameValue("Filter", filter));
                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result.AddRange(sr(idEmpresa).listar(_parametros.ToArray()));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            return result;
        }

        public static System.Collections.Generic.List<Data.Base> listaDados(Data.Base data, String filter, Object[] parametros, Service _sr)
        {
            System.Collections.Generic.List<Data.Base> result = new List<Data.Base>();

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                {
                    String
                        _filter = filter,
                        keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!keys.Contains("[" + _key + "]"))
                        {
                            EJB.TableBase.TField _fieldValue = null;
                            Object _value = parametros[_parametros.Count];

                            switch (_value.GetType().Name)
                            {
                                case "DateTime":
                                    _fieldValue = new EJB.TableBase.TFieldDatetime(_key.Substring(1), System.Convert.ToDateTime(_value));
                                    break;

                                case "Int16":
                                case "Int32":
                                case "Int64":
                                    _fieldValue = new EJB.TableBase.TFieldInteger(_key.Substring(1), System.Convert.ToInt32(_value));
                                    break;

                                case "Float":
                                case "Double":
                                    _fieldValue = new EJB.TableBase.TFieldDouble(_key.Substring(1), System.Convert.ToDouble(_value));
                                    break;

                                default:
                                    _fieldValue = new EJB.TableBase.TFieldString(_key.Substring(1), _value.ToString());
                                    break;
                            }

                            _parametros.Add(new NameValue(_key, _fieldValue));
                            keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                _parametros.Add(new NameValue("Filter", filter));
                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result.AddRange(_sr.listar(_parametros.ToArray()));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            return result;
        }

        public static System.Collections.Generic.List<Data.Base> listaDados(long idEmpresa, Data.Base data, int maxRow, System.Collections.Generic.List<NameValue> parametros = null, EntityManager em = null)
        {
            System.Collections.Generic.List<Data.Base> result = new List<Data.Base>();

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                    _parametros.AddRange(parametros);
                else { }

                if (data != null)
                    _parametros.Add(new NameValue("Top", maxRow));
                else { }

                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result.AddRange(sr(idEmpresa).listar(_parametros.ToArray(), em));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            return result;
        }

        public static System.Collections.Generic.List<Data.Base> listaDados(Data.Base data, int maxRow, Service _sr, System.Collections.Generic.List<NameValue> parametros = null)
        {
            System.Collections.Generic.List<Data.Base> result = new List<Data.Base>();

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                    _parametros.AddRange(parametros);
                else { }

                if (data != null)
                    _parametros.Add(new NameValue("Top", maxRow));
                else { }

                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result.AddRange(_sr.listar(_parametros.ToArray()));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            return result;
        }

        public static int getCount(long idEmpresa, Data.Base data, System.Collections.Generic.List<NameValue> parametros = null)
        {
            int result = 0;

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                    _parametros.AddRange(parametros);
                else { }

                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result = (sr(idEmpresa).getCount(data, _parametros.ToArray()));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;

                data = null;
            }
            else { }

            return result;
        }
        public static int getCount(long idEmpresa, Data.Base data, Service _sr, System.Collections.Generic.List<NameValue> parametros = null)
        {
            int result = 0;

            if (data != null)
            {

                System.Collections.Generic.List<NameValue> _parametros = new System.Collections.Generic.List<NameValue>();

                if (parametros != null)
                    _parametros.AddRange(parametros);
                else { }

                _parametros.Add(new NameValue("Key", data));

                try
                {
                    result = (_sr.getCount(data, _parametros.ToArray()));
                }
                catch (Exception e)
                {
                    e.ToString();
                }

                _parametros.Clear();
                _parametros = null;

                data = null;
            }
            else { }

            return result;
        }

        /*
    #region Endereços
        public static System.Collections.Generic.List<Data.Pais> listaPaises(Data.Pais data)
        {
            System.Collections.Generic.List<Data.Pais> result = new List<Data.Pais>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Pais();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Pais)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Estado> listaEstados(Data.Estado data)
        {
            System.Collections.Generic.List<Data.Estado> result = new List<Data.Estado>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Estado();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Estado)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Cidade> listaCidades(Data.Cidade data)
        {
            System.Collections.Generic.List<Data.Cidade> result = new List<Data.Cidade>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Cidade();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Cidade)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Bairro> listaBairros(Data.Bairro data)
        {
            System.Collections.Generic.List<Data.Bairro> result = new List<Data.Bairro>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Bairro();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Bairro)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.TipoLogradouro> listaTiposLogradouro(Data.TipoLogradouro data)
        {
            System.Collections.Generic.List<Data.TipoLogradouro> result = new List<Data.TipoLogradouro>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoLogradouro();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoLogradouro)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.FinalidadeEndereco> listaFinalidadesEndereco(Data.FinalidadeEndereco data)
        {
            System.Collections.Generic.List<Data.FinalidadeEndereco> result = new List<Data.FinalidadeEndereco>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.FinalidadeEndereco();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.FinalidadeEndereco)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Logradouro> listaLogradouros(Data.Logradouro data)
        {
            System.Collections.Generic.List<Data.Logradouro> result = new List<Data.Logradouro>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Logradouro();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Logradouro)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Endereco> listaEnderecos(Data.Endereco data)
        {
            System.Collections.Generic.List<Data.Endereco> result = new List<Data.Endereco>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Endereco();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Endereco)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion

    #region Pessoa
        public static System.Collections.Generic.List<Data.TipoAcessoContato> listaTiposAcessoContato(Data.TipoAcessoContato data)
        {
            System.Collections.Generic.List<Data.TipoAcessoContato> result = new List<Data.TipoAcessoContato>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoAcessoContato();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoAcessoContato)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.TipoEnderecoContato> listaTiposEnderecoContato(Data.TipoEnderecoContato data)
        {
            System.Collections.Generic.List<Data.TipoEnderecoContato> result = new List<Data.TipoEnderecoContato>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoEnderecoContato();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoEnderecoContato)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.TipoImagem> listaTiposImagem(Data.TipoImagem data)
        {
            System.Collections.Generic.List<Data.TipoImagem> result = new List<Data.TipoImagem>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoImagem();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoImagem)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.TipoRelacionamento> listaTiposRelacionamento(Data.TipoRelacionamento data)
        {
            System.Collections.Generic.List<Data.TipoRelacionamento> result = new List<Data.TipoRelacionamento>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoRelacionamento();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoRelacionamento)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

    #region fisica
        public static System.Collections.Generic.List<Data.Escolaridade> listaEscolaridades(Data.Escolaridade data)
        {
            System.Collections.Generic.List<Data.Escolaridade> result = new List<Data.Escolaridade>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Escolaridade();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Escolaridade)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.EstadoCivil> listaEstadosCivis(Data.EstadoCivil data)
        {
            System.Collections.Generic.List<Data.EstadoCivil> result = new List<Data.EstadoCivil>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.EstadoCivil();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.EstadoCivil)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Profissao> listaProfissoes(Data.Profissao data)
        {
            System.Collections.Generic.List<Data.Profissao> result = new List<Data.Profissao>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Profissao();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Profissao)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.PessoaFisica> listaPessoasFisica(Data.PessoaFisica data)
        {
            System.Collections.Generic.List<Data.PessoaFisica> result = new List<Data.PessoaFisica>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            parametros.Add(new NameValue("Top", 100));
            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.PessoaFisica)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion

    #region juridica
        public static System.Collections.Generic.List<Data.AtividadeEconomica> listaAtividadesEconomicas(Data.AtividadeEconomica data)
        {
            System.Collections.Generic.List<Data.AtividadeEconomica> result = new List<Data.AtividadeEconomica>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.AtividadeEconomica();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.AtividadeEconomica)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.PessoaJuridica> listaPessoasJuridica(Data.PessoaJuridica data)
        {
            System.Collections.Generic.List<Data.PessoaJuridica> result = new List<Data.PessoaJuridica>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            parametros.Add(new NameValue("Top", 100));
            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.PessoaJuridica)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion
    #endregion

    #region sistema
        public static System.Collections.Generic.List<Data.Pagina> listaPaginas(Data.Pagina data)
        {
            System.Collections.Generic.List<Data.Pagina> result = new List<Data.Pagina>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Pagina();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Pagina)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Menu> listaMenus(Data.Menu data)
        {
            System.Collections.Generic.List<Data.Menu> result = new List<Data.Menu>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Menu();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Menu)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Perfil> listaPerfis(Data.Perfil data)
        {
            System.Collections.Generic.List<Data.Perfil> result = new List<Data.Perfil>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Perfil();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Perfil)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Usuario> listaUsuarios(Data.Usuario data)
        {
            System.Collections.Generic.List<Data.Usuario> result = new List<Data.Usuario>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Usuario();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Usuario)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion

    #region empresa
        public static System.Collections.Generic.List<Data.Empresa> listaEmpresas(Data.Empresa data)
        {
            System.Collections.Generic.List<Data.Empresa> result = new List<Data.Empresa>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Empresa();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Empresa)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Funcionario> listaFuncionarios(Data.Funcionario data)
        {
            System.Collections.Generic.List<Data.Funcionario> result = new List<Data.Funcionario>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Funcionario();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Funcionario)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.Fornecedor> listaFornecedores(Data.Fornecedor data)
        {
            System.Collections.Generic.List<Data.Fornecedor> result = new List<Data.Fornecedor>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Fornecedor();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Fornecedor)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }

        public static System.Collections.Generic.List<Data.TipoRelacionamentoEmpresa> listaTiposRelacionamentoEmpresa(Data.TipoRelacionamentoEmpresa data)
        {
            System.Collections.Generic.List<Data.TipoRelacionamentoEmpresa> result = new List<Data.TipoRelacionamentoEmpresa>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.TipoRelacionamentoEmpresa();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.TipoRelacionamentoEmpresa)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion

    #region Relatório
        public static System.Collections.Generic.List<Data.Relatorios> listaRelatorios(Data.Relatorios data)
        {
            System.Collections.Generic.List<Data.Relatorios> result = new List<Data.Relatorios>();

            Service sr = new Service(Utils.Utils.getSqlConfigs());

            System.Collections.Generic.List<NameValue> parametros = new System.Collections.Generic.List<NameValue>();

            if (data != null)
                parametros.Add(new NameValue("Top", 100));
            else
                data = new Data.Relatorios();

            parametros.Add(new NameValue("Key", data));

            try
            {
                foreach (Data.Base _data in sr.listar(parametros.ToArray()))
                    result.Add((Data.Relatorios)_data);
            }
            catch { }

            parametros.Clear();


            data = null;

            return result;
        }
    #endregion
        */

        public static String toHex(String value)
        {
            return string.Join("", value.Select(c => ((int)c).ToString("X2")));
        }

        public static Data.Base recuperaDocumentoTransferido(long idEmpresa, int idDocumentoTransferenciaItem)
        {
            Data.Base result = null;

            Data.DocumentoTransferenciaItem _data = ((Data.DocumentoTransferenciaItem)Utils.listaDados
            (
                idEmpresa,
                new Data.DocumentoTransferenciaItem
                {
                    idDocumentoTransferenciaItem = idDocumentoTransferenciaItem
                },
                1
            )[0]);

            if (_data.idDocumentoTransferenciaTransferidoItem > 0)
                result = Utils.recuperaDocumentoTransferido
                (
                    idEmpresa,
                    ((Data.DocumentoTransferenciaItem)Utils.listaDados
                    (
                        idEmpresa,
                        new Data.DocumentoTransferenciaItem
                        {
                            idDocumentoTransferenciaItem = _data.idDocumentoTransferenciaTransferidoItem
                        },
                        1
                    )[0]).idDocumentoTransferenciaItem
                );
            else
                if (_data.idDocumentoRecebimentoTransferido > 0)
                result = ((Data.DocumentoRecebimento)Utils.listaDados
                (
                    idEmpresa,
                    new Data.DocumentoRecebimento
                    {
                        idDocumentoRecebimento = _data.idDocumentoRecebimentoTransferido
                    },
                    1
                )[0]);
            else
                result = ((Data.DocumentoTransferencia)Utils.listaDados
                (
                    idEmpresa,
                    new Data.DocumentoTransferencia
                    {
                        idDocumentoTransferencia = _data.idDocumentoTransferencia
                    },
                    1
                )[0]);

            return result;
        }

        public static string ucwords(string input)
        {
            if (String.IsNullOrEmpty(input))
                return String.Empty;

            String[] str = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string retorno = "";
            foreach (var s in str)
            {
                if (!String.IsNullOrEmpty(s))
                    retorno += s.Substring(0, 1).ToUpper() + (s.Length > 1 ? s.Substring(1).ToLower() : "") + " ";
            }

            return retorno.Trim();
        }


        public static double GetSomatoriaMovimentoVenda(int idPdvCompra)
        {

            string query = String.Format(@"SELECT
	isNull
	(
		SUM
		(
		
			CASE
				WHEN ercm.tipoOperacao = 'C' THEN ercm.valorMovimento
				WHEN ercm.tipoOperacao = 'D' THEN ercm.valorMovimento - ercm.valorDesconto
				WHEN ercm.tipoOperacao = 'E' THEN (ercm.valorMovimento * -1)
				WHEN ercm.tipoOperacao = 'V' THEN (ercm.valorMovimento * -1) + ercm.valorDesconto
			end
		),
		0
	) valorMovimento
FROM
	empresaRelacionamentoCartaoMovimento ercm
WHERE
	ercm.idPdvCompra = {0}", idPdvCompra);

            DataTable result = Utils.em.executeData(query, null);
            if (result != null && result.Rows.Count > 0)
                try
                {
                    return Convert.ToDouble(result.Rows[0][0]);
                }
                catch { }
            return 0;
        }


        public static void ClearLine()
        {
            int width = Console.WindowWidth;
            Console.Write(new string(' ', width - 1));
        }

        public static void WriteProgress(string s, int x)
        {
            int origRow = Console.CursorTop;
            int origCol = Console.CursorLeft;
            int width = Console.WindowWidth;
            try
            {
                ClearLine();
                Console.SetCursorPosition(0, x);
                Console.WriteLine(s);
            }
            catch (ArgumentOutOfRangeException e)
            {

            }
        }

        public static string gerarSenhaQualitySuporte(string data = null)
        {

            string[] senhas = new string[26];
            senhas[0] = "202203SENHAMAR22";

            DateTime dataAtual = DateTime.Now;
            if (!String.IsNullOrEmpty(data))
                dataAtual = Convert.ToDateTime(data);
            else { }

            for (int i = 0; i < senhas.Length; i++)
            {
                string pass = senhas[i].Substring(0, 6);
                string mes = dataAtual.Month < 10 ? "0" + dataAtual.Month.ToString() : dataAtual.Month.ToString();
                string anomes = dataAtual.Year.ToString() + mes;
                if (pass == anomes)
                    return senhas[i].Substring(6);
                else { }
            }

            return senhas[senhas.Length - 1].Substring(6);
        }

        public static void redirecionaPagina(string request)
        {
            HttpContext.Current.Response.Redirect(request, false);
        }

        public static void redirecionaPagina(string link, string target = "_blank")
        {
            HttpContext.Current.Response.Write("<script>window.open(" + link + "','" + target + "');</script>");
        }
        public static void redirecionaPagina(HttpRequest request)
        {
            string arquivo = Path.GetFileNameWithoutExtension(request.FilePath);
            string valorRedirecionaArquivo = Update.getConfiguracoesGlobais("redireciona_" + arquivo);

            if (!String.IsNullOrEmpty(valorRedirecionaArquivo))
            {
                if (valorRedirecionaArquivo == @"s")
                    HttpContext.Current.Response.Redirect(request.RawUrl, false);
                else
                {
                    return;
                }
            }
            else
            {
                string valorRedirecionaGlobal = Update.getConfiguracoesGlobais("redirecionaGlobal");
                if (!String.IsNullOrEmpty(valorRedirecionaGlobal))
                {
                    if (valorRedirecionaGlobal == @"s")
                        HttpContext.Current.Response.Redirect(request.RawUrl, false);
                    else
                    {
                        return;
                    }
                }
            }

            return;
        }

        public static void makeLocation(string loc = "pt-BR")
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/Web.config"));
            XmlNodeList configs = doc.SelectNodes("/configuration/system.web");
            bool haveLoc = false;
            for (int i = 0; i < configs.Count; i++)
            {
                for (int j = 0; j < configs[i].ChildNodes.Count; j++)
                {
                    if (configs[i].ChildNodes[j].Name == "globalization")
                    {
                        haveLoc = true;
                        break;
                    }
                }
                if (haveLoc)
                    break;
            }

            if (!haveLoc)
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml("<system.web><globalization culture=\"" + loc + "\" uiCulture=\"" + loc + "\" /></system.web>");
                XmlNode root = doc.DocumentElement;
                XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/system.web"), true);

                root.InsertAfter(importNode, doc.SelectSingleNode("/configuration/system.web"));

                using (XmlTextWriter writer = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/Web.config"), null))
                {
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.Save(writer);
                }

            }
        }

        private static void removeLogin()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/Web.config"));
            XmlNodeList
                configs = doc.SelectNodes("/configuration/system.web"),
                loop = null;

            loop = configs;

            for (int i = 0; i < loop.Count; i++)
            {
                XmlNode nde = loop[i];
                foreach (XmlNode nd in nde.ChildNodes)
                    if (nd.Name == "authentication" || nd.Name == "authorization")
                    {
                        configs[i].RemoveChild(nd);
                        using (XmlTextWriter writer = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/Web.config"), null))
                        {
                            writer.Formatting = System.Xml.Formatting.Indented;
                            doc.Save(writer);
                            writer.Close();
                        }
                        removeLogin();

                    }
                    else { }
            }

            /*XmlDocument docNew = new XmlDocument();
            docNew.LoadXml("<system.web><globalization culture=\"" + loc + "\" uiCulture=\"" + loc + "\" /></system.web>");
            XmlNode root = doc.DocumentElement;
            XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/system.web"), true);

            root.InsertAfter(importNode, doc.SelectSingleNode("/configuration/system.web"));

            using (XmlTextWriter writer = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/Web.config"), null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }*/
        }

        public static void verificaWebConfig()
        {
            removeLogin();
            makeLocation();
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/Web.config"));
            XmlNodeList locations = doc.SelectNodes("/configuration/location");
            bool haveLicense = false,
                 haveImages = false,
                 haveFavicon = false,
                 haveError = false;


            for (int i = 0; i < locations.Count; i++)
            {
                if (locations[i].Attributes[0].Value == @"LicencaInvalida.aspx")
                    haveLicense = true;
                if (locations[i].Attributes[0].Value == @"images/logo.png")
                    haveImages = true;
                if (locations[i].Attributes[0].Value == @"styles/favicon.ico")
                    haveFavicon = true;
                if (locations[i].Attributes[0].Value == @"erro.aspx")
                    haveError = true;
            }

            if (!haveLicense)
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml("<location path=\"LicencaInvalida.aspx\"><system.web><authorization><allow users=\"*\" /></authorization></system.web ></location>");
                XmlNode root = doc.DocumentElement;
                XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/location"), true);
                root.InsertBefore(importNode, doc.SelectSingleNode("/configuration/system.webServer"));
            }

            if (!haveError)
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml("<location path=\"erro.aspx\"><system.web><authorization><allow users=\"*\" /></authorization></system.web ></location>");
                XmlNode root = doc.DocumentElement;
                XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/location"), true);
                root.InsertBefore(importNode, doc.SelectSingleNode("/configuration/system.webServer"));
            }

            if (!haveImages)
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml("<location path=\"images/logo.png\"><system.web><authorization><allow users=\"*\" /></authorization></system.web ></location>");
                XmlNode root = doc.DocumentElement;
                XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/location"), true);
                root.InsertBefore(importNode, doc.SelectSingleNode("/configuration/system.webServer"));
            }

            if (!haveFavicon)
            {
                XmlDocument docNew = new XmlDocument();
                docNew.LoadXml("<location path=\"styles/favicon.ico\"><system.web><authorization><allow users=\"*\" /></authorization></system.web ></location>");
                XmlNode root = doc.DocumentElement;
                XmlNode importNode = doc.ImportNode(docNew.SelectSingleNode("/location"), true);
                root.InsertBefore(importNode, doc.SelectSingleNode("/configuration/system.webServer"));
            }

            if (!haveImages || !haveLicense || !haveFavicon || !haveError)
            {
                using (XmlTextWriter writer = new XmlTextWriter(HttpContext.Current.Server.MapPath("~/Web.config"), null))
                {
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.Save(writer);
                }
            }

            XmlNode fieldAttributes = doc.SelectSingleNode("/configuration/FieldAttributes");
            if (fieldAttributes != null)
            {
                createReportXml(HttpContext.Current.Server.MapPath("~/Web.config"));
                doc.DocumentElement.RemoveChild(fieldAttributes);
                doc.Save(HttpContext.Current.Server.MapPath("~/Web.config"));
            }
            else { }
        }

        public static string GetVisitorIp()
        {
            string ip = null;
            try
            {
                if (HttpContext.Current != null)
                {
                    ip = string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"])
                        ? HttpContext.Current.Request.UserHostAddress
                        : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }
                else { }
                if (string.IsNullOrEmpty(ip) || ip.Trim() == "::1")
                {

                    string lan = String.Empty;
                    foreach (IPAddress item in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                    {
                        if (!item.IsIPv6LinkLocal)
                        {
                            if (item.AddressFamily == AddressFamily.InterNetwork)
                            {
                                lan += lan.Length > 0 ? "-" + item.ToString() : item.ToString();
                            }
                            else { }
                        }
                        else { }
                    }

                    ip = (String.IsNullOrEmpty(lan)) ? string.Empty : lan;
                }
                else { }
            }
            catch { }
            return ip;
        }

        public static Data.ProdutoServicoEmpresa codigoProdutoExists(string codigoProduto, int idEmpresa)
        {
            Data.ProdutoServicoEmpresa pse = null;

            try
            {
                pse = new Data.ProdutoServicoEmpresa
                {
                    codigoProduto = codigoProduto,
                    idEmpresa = idEmpresa
                };
                pse = (Data.ProdutoServicoEmpresa)listaDados(idEmpresa, pse, 1, null)[0];
            }
            catch
            {
                pse = null;
            }

            return pse;

        }
        public static string RemoverAcentos(string text)
        {
            return
                System.Web.HttpUtility.UrlDecode(
                    System.Web.HttpUtility.UrlEncode(
                        text, Encoding.GetEncoding("iso-8859-7")));
        }

        public static string geraCodigoProduto(int idEmpresa, string codigo = null, int idProdutoServico = 0)
        {

            Data.ProdutoServicoEmpresa pse = String.IsNullOrEmpty(codigo) ? null : codigoProdutoExists(codigo, idEmpresa);

            if (pse != null && idProdutoServico != pse.idProdutoServico)
                codigo = geraCodigoProduto(idEmpresa, null, idProdutoServico);
            else { }

            if (String.IsNullOrEmpty(codigo))
            {

                int
                    max = 0,
                    novoCodigo = 0;

                DataTable dt = Utils.em.executeData("SELECT MAX(CAST(codigoProduto AS INT)) FROM produtoServicoEmpresa WHERE idEmpresa = " + idEmpresa.ToString(), null);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    try
                    {
                        max = Convert.ToInt32(dt.Rows[0][0].ToString());
                    }
                    catch
                    {
                        max = 0;
                    }
                else { }

                novoCodigo = max + 1;
                codigo = novoCodigo.ToString();
            }
            else { }

            return codigo;
        }

        public static string serializeClass(Data.Base classe)
        {
            string retorno = "";
            Type tp = classe.GetType();
            System.Reflection.PropertyInfo[] fields = tp.GetProperties();
            foreach (System.Reflection.PropertyInfo fi in fields)
                retorno += (retorno.Length > 0 ? ";" : "") + fi.Name;

            int i = 0;
            foreach (System.Reflection.PropertyInfo fi in fields)
            {
                retorno += (i > 0 ? ";" : "\n") + fi.GetValue(classe, null);
                i++;
            }

            return retorno;
        }

        public static void registerLog(string operacao, string descricao, string classe, int idRef, string complemento = null)
        {


            System.Web.SessionState.HttpSessionState session = null;
            try
            {
                session = System.Web.HttpContext.Current.Session;
            }
            catch { }
            if (session == null)
                return;
            Data.Usuario currentUser = (Data.Usuario)session["currentUser"];
            if (currentUser != null && currentUser.idUsuario > 0)
            {
                string ip = GetVisitorIp();
                DateTime dataOperacao = DateTime.Now;

                int idEmpresa = currentUser.idEmpresa;
                try
                {
                    idEmpresa = ((Data.Empresa)session["currentBusiness"]).idEmpresa;
                }
                catch
                {
                    idEmpresa = currentUser.idEmpresa;
                }
                string hash = currentUser.idUsuario.ToString() + idEmpresa.ToString() + operacao + descricao + ip + (new Base64().encode(dataOperacao.ToString("yyyy-MM-dd hh:mm:ss"))) + classe + idRef.ToString() + complemento;
                string assinatura = new Base64().encode(Security.EncryptRijndael(hash, Security.Inputkey));
                string query = "INSERT INTO logOperacoes VALUES (CONVERT(DATETIME, '" + dataOperacao.ToString("dd/MM/yyyy HH:mm:ss") + "', 103), " + currentUser.idUsuario.ToString() + ", '" + idEmpresa.ToString() + "', '" + ip + "', '" + operacao + "', '" + descricao + "', '" + classe + "', " + idRef.ToString() + ", '" + assinatura + "', '" + complemento + "')";
                try
                {
                    Utils.em.beginTransaction();
                    Utils.em.executeData(query, null);
                    Utils.em.commitTransaction();
                }
                catch
                {
                    Utils.em.rollbackTransaction();
                }
            }
            else { }

        }

        public static Image ResizeImage(Image image, Size size,
            bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                newWidth = (int)(originalWidth * percentWidth);
                newHeight = (int)(originalHeight * percentWidth);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        public static string GetSchemaDir()
        {
#if DEBUG
            string appDir = GetAppDir();
            string schema;
            if (!Directory.Exists(Path.Combine(appDir, "ClientApp")))
                schema = GetAppDir() + "data\\Schemas";
            else
                schema = GetAppDir() + "\\ClientApp\\public\\data\\Schemas";
#else
            string appDir = GetAppDir();
            string schema;
            if (!Directory.Exists(Path.Combine(appDir, "ClientApp")))
                schema = GetAppDir() + "data\\Schemas";
            else
                schema = GetAppDir() + "\\ClientApp\\build\\data\\Schemas";
#endif
            return schema;
        }
        public static string GetAppDir()
        {
            string dir = "";
            if (!System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("Debug"))
            {
                dir = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
                if (dir.Contains("bin"))
                    dir = System.IO.Path.GetDirectoryName(dir);
                else { }
            }
            else
                dir = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)));

            return dir + "\\";
        }

        public static byte[] LoadLogo(string file = null, int newWidth = 0)
        {
            Image logo = null;
            MemoryStream ms = null;
            ImageFormat format = null;
            string img = String.IsNullOrEmpty(file) ? AppDomain.CurrentDomain.BaseDirectory + "data\\dist\\img\\logoRelatorio.jpg" : file;
            Utils.WriteLog(img);
            Utils.WriteLogPDV(img);

            try
            {
                ms = new MemoryStream();
                logo = Image.FromFile(img);
                format = logo.RawFormat;
                if (newWidth > 0 && newWidth < logo.Width)
                    logo = ResizeImage(logo, new Size(newWidth, 0), true);
                else { }

                logo.Save(ms, format);
            }
            catch
            {
                ms.Dispose();
                ms = null;
            }
            return ms?.ToArray();
        }

        public static void createReportXml(string file)
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(file);
            System.Xml.XmlNode fieldAttributes = doc.SelectSingleNode("/configuration/FieldAttributes");

            if (fieldAttributes != null)
            {
                foreach (XmlNode node in fieldAttributes)
                {
                    string classBase = node.Name;
                    if (classBase.Contains('_'))
                        classBase = node.Name.Split('_')[0];
                    else { }

                    try
                    {
                        if (!Directory.Exists(System.IO.Path.GetDirectoryName(file) + "\\relatoriosConfig"))
                            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(file) + "\\relatoriosConfig");
                        else { }

                        string fileName = System.IO.Path.GetDirectoryName(file) + "\\relatoriosConfig\\" + classBase + ".xml";
                        if (!File.Exists(fileName))
                            File.WriteAllText(fileName, "<FieldAttributes></FieldAttributes>");
                        else { }

                        XmlDocument _doc = new XmlDocument();
                        _doc.LoadXml(File.ReadAllText(fileName));
                        if (_doc.DocumentElement.SelectSingleNode(node.Name) == null)
                        {
                            _doc.DocumentElement.AppendChild(_doc.ImportNode(node, true));
                            _doc.Save(fileName);
                        }
                        else { }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Returns a site relative HTTP path from a partial path starting out with a ~.
        /// Same syntax that ASP.Net internally supports but this method can be used
        /// outside of the Page framework.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="originalUrl">Any Url including those starting with ~</param>
        /// <returns>relative url</returns>
        public static string ResolveUrl(string originalUrl)
        {
            if (string.IsNullOrEmpty(originalUrl))
                return originalUrl;

            // *** Absolute path - just return
            if (IsAbsolutePath(originalUrl))
                return originalUrl;

            // *** We don't start with the '~' -> we don't process the Url
            if (!originalUrl.StartsWith("~"))
                return originalUrl;

            // *** Fix up path for ~ root app dir directory
            // VirtualPathUtility blows up if there is a 
            // query string, so we have to account for this.
            int queryStringStartIndex = originalUrl.IndexOf('?');
            if (queryStringStartIndex != -1)
            {
                string queryString = originalUrl.Substring(queryStringStartIndex);
                string baseUrl = originalUrl.Substring(0, queryStringStartIndex);

                return string.Concat(
                VirtualPathUtility.ToAbsolute(baseUrl),
                queryString);
            }
            else
            {
                return VirtualPathUtility.ToAbsolute(originalUrl);
            }

        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// Works like Control.ResolveUrl including support for ~ syntax
        /// but returns an absolute URL.
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <param name="forceHttps">if true forces the url to use https</param>
        /// <returns></returns>
        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (string.IsNullOrEmpty(serverUrl))
                return serverUrl;

            // *** Is it already an absolute Url?
            if (IsAbsolutePath(serverUrl))
                return serverUrl;

            string newServerUrl = ResolveUrl(serverUrl);
            Uri result = new Uri(HttpContext.Current.Request.Url, newServerUrl);

            if (!forceHttps)
                return result.ToString();
            else
                return ForceUriToHttps(result).ToString();
        }

        /// <summary>
        /// This method returns a fully qualified absolute server Url which includes
        /// the protocol, server, port in addition to the server relative Url.
        /// 
        /// It work like Page.ResolveUrl, but adds these to the beginning.
        /// This method is useful for generating Urls for AJAX methods
        /// </summary>
        /// <param name="ServerUrl">Any Url, either App relative or fully qualified</param>
        /// <returns></returns>
        public static string ResolveServerUrl(string serverUrl)
        {
            return ResolveServerUrl(serverUrl, false);
        }

        /// <summary>
        /// Forces the Uri to use https
        /// </summary>
        private static Uri ForceUriToHttps(Uri uri)
        {
            // ** Re-write Url using builder.
            UriBuilder builder = new UriBuilder(uri);
            builder.Scheme = Uri.UriSchemeHttps;
            builder.Port = 443;

            return builder.Uri;
        }

        private static bool IsAbsolutePath(string originalUrl)
        {
            // *** Absolute path - just return
            int IndexOfSlashes = originalUrl.IndexOf("://");
            int IndexOfQuestionMarks = originalUrl.IndexOf("?");

            if (IndexOfSlashes > -1 &&
                 (IndexOfQuestionMarks < 0 ||
                  (IndexOfQuestionMarks > -1 && IndexOfQuestionMarks > IndexOfSlashes)
                  )
                )
                return true;

            return false;
        }
    }

    public static class Extentions
    {
        /// <summary>
        /// Check wheather the string is empty or null (Extention Method)
        /// </summary>
        /// <param name="str">The string to be checked</param>
        /// <returns>Returns true if string is NULL or String.Empty, otherwise false</returns>
        public static bool IsEmptyOrNull(this string str)
        {
            if (str == null || str == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes Json null objects from the serialized string and return a new string(Extention Method)
        /// </summary>
        /// <param name="str">The String to be checked</param>
        /// <returns>Returns the new processed string or NULL if null or empty string passed</returns>
        public static string RemoveJsonNulls(this string str)
        {
            if (!str.IsEmptyOrNull())
            {
                Regex regex = new Regex(UtilityRegExp.JsonNullRegEx);
                string data = regex.Replace(str, string.Empty);
                data = data.Replace(",}", "}");
                regex = new Regex(UtilityRegExp.JsonNullArrayRegEx);
                return regex.Replace(data, "[]");
            }
            return null;
        }

        /// <summary>
        /// Serializes an objct to a Json string using Javascript Serializer and removes Json null objects if opted (Extention Method)
        /// </summary>
        /// <param name="arg">Object to serialize</param>
        /// <param name="checknull">Set to true if you want remove null Json objects from serialized string, otherwise false(default)</param>
        /// <returns>The serialized Json as string, if check null was set true then null Json strings are removed</returns>        
        public static string SerializeToJson(this object arg, bool checknull = false)
        {
            JavaScriptSerializer sr = new JavaScriptSerializer();
            if (checknull)
            {
                return sr.Serialize(arg).RemoveJsonNulls();
            }
            return sr.Serialize(arg);
        }

        public static object DeserializeObject(this string json, object obj)
        {
            JavaScriptSerializer sr = new JavaScriptSerializer();
            Type type = obj.GetType();
            object
                _obj = sr.Deserialize(json, type),
                newObj = Utils.instanceDataClass(type.Name);

            DuckCopyShallow(newObj, _obj);

            return _obj;
        }

        public static void DuckCopyShallow(this Object dst, object src)
        {
            var srcT = src.GetType();
            var dstT = dst.GetType();
            foreach (var f in srcT.GetFields())
            {
                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }

            foreach (var f in srcT.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var dstF = dstT.GetProperty(f.Name);
                if (dstF == null)
                    continue;

                dstF.SetValue(dst, f.GetValue(src, null), null);
            }
        }

    }

    /// <summary>
    /// <para>Contains the Regular Expression for use in Application</para>>
    /// </summary>
    /// <remarks>
    /// Copyright: Copyright (c) 2010-2011 Samaj Shekhar
    /// Last Update: 30-Dec-2010|04:22pm
    /// </remarks>
    public class UtilityRegExp
    {
        /// <summary>
        /// <para>A Regular Expression to Match any null Json object in a string</para>
        /// <para>like "Samaj_Shekhar":null,</para>
        /// <para>Useful in removing nulls from serialized Json string</para>
        /// </summary>
        public static string JsonNullRegEx = "[\"][a-zA-Z0-9_]*[\"]:null[ ]*[,]?";

        /// <summary>
        /// <para>A Regular Expression to Match an array of null Json object in a string</para>
        /// <para>like [null, null]</para>
        /// <para>Useful in removing null array from serialized Json string</para>
        /// </summary>
        public static string JsonNullArrayRegEx = "\\[( *null *,? *)*]";

        /// <summary>
        /// <para>A Regular Expression to Match an Email Address</para>
        /// <para>Useful in validating email addresses</para>
        /// </summary>
        public static string ValidEmailRegEx = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
    }
}