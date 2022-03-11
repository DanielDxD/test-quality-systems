using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class ConfiguracoesGlobais : Base
    {
        public ConfiguracoesGlobais() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("Nome Configuração", 55),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private string m_nmConfiguracao;
        public string nmConfiguracao
        {
            get { return this.m_nmConfiguracao; }
            set { this.m_nmConfiguracao = value; }
        }

        [
            TFieldAttributeGridDisplay("Valor Configuração", 200 + 155),
            TFieldAttributeData(50, true)
        ]
        private String m_ValorConfiguracao;
        public String valorConfiguracao
        {
            get { return this.m_ValorConfiguracao; }
            set { this.m_ValorConfiguracao = value; }
        }
    }
}
