using System;

namespace Data
{
    //[Serializable]
    public class Titulo : Base
    {
        public Titulo() : base()
        {
        }

        private int m_IdTitulo;
        public int idTitulo
        {
            get { return this.m_IdTitulo; }
            set { this.m_IdTitulo = value; }
        }

        private Int64 m_Numero;
        public Int64 numero
        {
            get { return this.m_Numero; }
            set { this.m_Numero = value; }
        }

        private String m_Serie;
        public String serie
        {
            get { return this.m_Serie; }
            set { this.m_Serie = value; }
        }

        private Situacao m_IdSituacao;
        public Situacao situacao
        {
            get { return this.m_IdSituacao; }
            set { this.m_IdSituacao = value; }
        }

        private DateTime m_DataCriacao;
        public DateTime dataCriacao
        {
            get { return this.m_DataCriacao; }
            set { this.m_DataCriacao = value; }
        }

        private int m_IdEmpresa;
        public int idEmpresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        //idTitulo
        private TituloConsignacao[] m_TituloConsignacaos;
        public TituloConsignacao[] tituloConsignacaos
        {
            get { return this.m_TituloConsignacaos; }
            set { this.m_TituloConsignacaos = value; }
        }

        //idTitulo
        private TituloSocio[] m_TituloSocios;
        public TituloSocio[] tituloSocios
        {
            get { return this.m_TituloSocios; }
            set { this.m_TituloSocios = value; }
        }

        public override string ToString()
        {
            return this.m_IdTitulo.ToString();
        }
    }
}
