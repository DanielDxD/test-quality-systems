using System;
using System.Data;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ConfiguracaoFiscal : Base
    {
        public ConfiguracaoFiscal() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("Nome Configuração", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private string m_nomeConfig;
        public string nomeConfig
        {
            get { return this.m_nomeConfig; }
            set { this.m_nomeConfig = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor Configuração", 200 + 155),
            TFieldAttributeData(50, true)
        ]
        private String m_ValorConfig;
        public String valorConfig
        {
            get { return this.m_ValorConfig; }
            set { this.m_ValorConfig = value; }
        }

        private Empresa m_Empresa;
        public Empresa empresa
        {
            get { return this.m_Empresa; }
            set { this.m_Empresa = value; }
        }

        public string get()
        {

            if (!String.IsNullOrEmpty(nomeConfig))
            {
                DataTable results = Utils.Utils.em.executeData("SELECT configuracaoFiscal.valorConfig FROM configuracaoFiscal WHERE nomeConfig = '" + nomeConfig + "' AND idEmpresa = " + empresa.idEmpresa.ToString(), null);
                if (results != null && results.Rows.Count > 0)
                    try
                    {
                        return results.Rows[0][0].ToString();
                    }
                    catch
                    {
                        return null;
                    }
                else { }
            }
            else { }

            return null;
        }

        public string get(string _nomeConfig)
        {

            if (!String.IsNullOrEmpty(_nomeConfig))
            {
                DataTable results = Utils.Utils.em.executeData("SELECT configuracaoFiscal.valorConfig FROM configuracaoFiscal WHERE nomeConfig = '" + _nomeConfig + "' AND idEmpresa = " + empresa.idEmpresa.ToString(), null);
                if (results != null && results.Rows.Count > 0)
                    try
                    {
                        return results.Rows[0][0].ToString();
                    }
                    catch
                    {
                        return null;
                    }
                else { }
            }
            else { }

            return null;
        }
        public void save()
        {
            if (String.IsNullOrEmpty(nomeConfig))
                throw new Exception("Informar o nome da configuração!");
            else { }

            if (empresa == null || (empresa != null && empresa.idEmpresa == 0))
                throw new Exception("Informar a empresa!");
            else { }

            if (String.IsNullOrEmpty(valorConfig))
                Utils.Utils.em.execute("DELETE FROM configuracaoFiscal WHERE nomeConfig = '" + nomeConfig + "' AND idEmpresa = " + empresa.idEmpresa.ToString(), null);
            else
            {

                if (exists())
                    Utils.Utils.em.execute("UPDATE configuracaoFiscal SET valorConfig = '" + valorConfig + "' WHERE idEmpresa = " + empresa.idEmpresa.ToString() + " AND nomeConfig = '" + nomeConfig + "'", null);
                else
                    Utils.Utils.em.execute("INSERT INTO configuracaoFiscal (nomeConfig, valorConfig, idEmpresa) VALUES ('" + nomeConfig + "', '" + valorConfig + "', " + empresa.idEmpresa.ToString() + ")", null);
            }
        }

        public bool exists()
        {
            DataTable results = Utils.Utils.em.executeData("SELECT * FROM configuracaoFiscal WHERE idEmpresa = " + empresa.idEmpresa.ToString() + " AND nomeConfig = '" + nomeConfig + "'", null);
            return (results != null && results.Rows.Count > 0);
        }
    }
}
