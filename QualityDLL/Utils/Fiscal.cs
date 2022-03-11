using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class Fiscal
    {

        private static Dictionary<string, string> m_Configs = null;
        private static Dictionary<string, string> configs
        {
            get
            {
                if (m_Configs == null || m_Configs.Count == 0)
                    m_Configs = listConfigs();
                else { }
                return m_Configs;
            }
        }
        private static int idEmpresa;


        private static Dictionary<string, string> listConfigs()
        {

            Dictionary<string, string> _results = new Dictionary<string, string>();
            Data.ConfiguracaoFiscal cf = new Data.ConfiguracaoFiscal
            {
                empresa = new Data.Empresa
                {
                    idEmpresa = idEmpresa
                }
            };

            foreach (Data.ConfiguracaoFiscal item in Utils.listaDados(idEmpresa, cf, 0))
                _results.Add(String.Concat(idEmpresa, "_", item.nomeConfig), item.valorConfig);

            return _results;
        }

        public static string getConfig(string nomeConfig, int _idEmpresa, bool fromDb = false)
        {
            idEmpresa = _idEmpresa;
            if (fromDb)
            {
                Data.ConfiguracaoFiscal cf = new Data.ConfiguracaoFiscal
                {
                    nomeConfig = nomeConfig,
                    empresa = new Data.Empresa
                    {
                        idEmpresa = idEmpresa
                    }
                };
                return cf.get();
            }
            else
            {
                string config = "";
                try
                {
                    config = configs[String.Concat(idEmpresa, "_", nomeConfig)];
                }
                catch { }
                return config;
            }
        }

    }
}
