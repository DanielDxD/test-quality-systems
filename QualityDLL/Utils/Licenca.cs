using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utils
{
    public class Licenca
    {

        public static bool verificaLicenca(bool force = false)
        {

            try
            {
                string host = HttpContext.Current.Request.Url.Host;
                int port = HttpContext.Current.Request.Url.Port;
                if ((host == @"192.168.0.250" && port == 8080) || (host == @"windows.qualitysys.com.br"))
                    return true;
                else { }

                Boolean verificaConexao = Utils.internetStatus;
                if (verificaConexao && !Update.checkWebsiteIsUp("http://www.qualitysys.com.br"))
                    return true;
                else if (!verificaConexao)
                {
                    DateTime dataVencBanco = System.Convert.ToDateTime(Update.getConfiguracoesGlobais("dataVencimentoChave"));
                    DateTime dataAtual = DateTime.Now;
                    if (String.IsNullOrEmpty(dataVencBanco.ToString()) || (!String.IsNullOrEmpty(dataVencBanco.ToString()) && ((dataVencBanco - dataAtual).TotalSeconds < 0)))
                        return false;

                    return true;
                }

                string idCliente = getIdClienteQuality(Update.getConfiguracoesGlobais("idClienteQuality"));
                string retornoDataUltimaChecagemChave = Update.getConfiguracoesGlobais("dataUltimaChecagemChave");
                DateTime dataUltimaChecagemChave = DateTime.Now;
                if (!String.IsNullOrEmpty(retornoDataUltimaChecagemChave))
                    dataUltimaChecagemChave = System.Convert.ToDateTime(retornoDataUltimaChecagemChave);

                if (
                    (String.IsNullOrEmpty(retornoDataUltimaChecagemChave)) ||
                    (
                       !String.IsNullOrEmpty(retornoDataUltimaChecagemChave) && (DateTime.Now - dataUltimaChecagemChave).TotalHours >= 24
                    ) ||
                    force
                )
                {

                    if (!String.IsNullOrEmpty(idCliente))
                    {
                        string request = Update.sendRequest(Update.urlAPI + @"api.php", "action=verificaLicenca&idCliente=" + idCliente, "POST");
                        if (!String.IsNullOrEmpty(request))
                        {
                            DateTime dataVenc = System.Convert.ToDateTime(request);
                            Update.atualizaConfiguracao("dataVencimentoChave", dataVenc.ToString("yyyy-MM-dd"));
                        }
                    }
                    else
                    {
                        Update.atualizaConfiguracao("dataVencimentoChave", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"));
                    }
                    Update.atualizaConfiguracao("dataUltimaChecagemChave", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                DateTime dataVencimentoChave = DateTime.MinValue;
                try
                {
                    dataVencimentoChave = System.Convert.ToDateTime(Update.getConfiguracoesGlobais("dataVencimentoChave"));
                }
                catch { }
                //DateTime dataVencimentoChave = System.Convert.ToDateTime("2016-02-11");
                //Data = 2016-04-28

                /* Bloquear o sistema caso a licença estiver vencida */
                int dias = (Int32)(dataVencimentoChave - DateTime.Now).TotalDays;
                if (dias < 0)
                    return false;
                else { }

                /* Enviar email de aviso para o dpto financeiro da Quality quando faltarem 10 dias para vencer a licença */
                /*if (dias >= 9 && dias <= 10)
                {
                    string retornoDateEmailFinanceiroQuality = Update.getConfiguracoesGlobais("dateEmailFinanceiroQuality");
                    DateTime dateEmailFinanceiroQuality = DateTime.Now;
                    if (!String.IsNullOrEmpty(retornoDateEmailFinanceiroQuality))
                        dateEmailFinanceiroQuality = System.Convert.ToDateTime(retornoDateEmailFinanceiroQuality);

                    if(
                        String.IsNullOrEmpty(retornoDateEmailFinanceiroQuality) || 
                        ((!String.IsNullOrEmpty(retornoDateEmailFinanceiroQuality) && ((DateTime.Now - dateEmailFinanceiroQuality).TotalHours >= 264 && (DateTime.Now - dataVencimentoChave).TotalHours <= 240)))
                    )
                    {
                        Update.sendRequest(Update.urlAPI + @"api.php", "action=enviaEmailFinanceiroQuality&idCliente=" + idCliente, "POST");
                        Update.atualizaConfiguracao("dateEmailFinanceiroQuality", dateEmailFinanceiroQuality.ToString("yyyy-MM-dd"));
                    }
                }*/

                /* Enviar email de aviso para o cliente e para o dpto financeiro da Quality quando faltarem 4 dias para vencer a licença */
                /*if (dias > 0 && dias <= 4)
                {
                    string retornoDateEmailAviso = Update.getConfiguracoesGlobais("dateEmailAviso");
                    DateTime dateEmailAviso = DateTime.Now;
                    if (!String.IsNullOrEmpty(retornoDateEmailAviso))
                        dateEmailAviso = System.Convert.ToDateTime(retornoDateEmailAviso);

                    if (
                        String.IsNullOrEmpty(retornoDateEmailAviso) ||
                        ((!String.IsNullOrEmpty(retornoDateEmailAviso) && ((DateTime.Now - dateEmailAviso).TotalHours >= 120 && (DateTime.Now - dataVencimentoChave).TotalHours <= 96)))
                    )
                    {
                        Update.sendRequest(Update.urlAPI + @"api.php", "action=enviaEmailAviso&idCliente="+idCliente, "POST");
                        Update.atualizaConfiguracao("dateEmailAviso", dateEmailAviso.ToString("yyyy-MM-dd"));
                    }
                }*/
            }
            catch
            {
                return true;
            }
            return true;
        }

        public static string getIdClienteQuality(string idCliente, List<string> cnpjParam = null)
        {
            if (String.IsNullOrEmpty(idCliente))
            {
                string _cnpjResult = null;
                int i = 0;
                if (cnpjParam == null)
                {
                    cnpjParam = new List<string>();
                    _cnpjResult = "''";

                }
                else
                {
                    foreach (string _cnpj in cnpjParam)
                    {
                        _cnpjResult += "'" + _cnpj + "'";
                        _cnpjResult += (cnpjParam.Count - 1) > i ? @"," : null;
                        i++;
                    }
                }

                string query = "SELECT * FROM empresa LEFT JOIN pessoa ON (pessoa.idPessoa = empresa.idPessoa) WHERE pessoa.pfpj = 'J' AND pessoa.cpfCnpj IS NOT NULL AND pessoa.cpfCnpj NOT IN (" + _cnpjResult + ")";
                System.Data.DataTable result = Utils.em.executeData(query, null);

                if (result.Rows.Count > 0)
                {
                    string cnpj = result.Rows[0][7].ToString();
                    if (!String.IsNullOrEmpty(cnpj))
                    {
                        string codqualy = Update.sendRequest(Update.urlAPI + @"api.php", "action=getIdQuality&cnpj=" + cnpj, "POST");
                        if (String.IsNullOrEmpty(codqualy))
                        {
                            cnpjParam.Add(cnpj);
                            return getIdClienteQuality(idCliente, cnpjParam);
                        }
                        if (!String.IsNullOrEmpty(codqualy))
                        {
                            Update.atualizaConfiguracao("idClienteQuality", codqualy);
                            idCliente = Update.getConfiguracoesGlobais("idClienteQuality");
                        }

                    }
                }
            }

            return idCliente;
        }
    }
}