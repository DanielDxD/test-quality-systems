using System;

namespace Data
{
    //[Serializable]
    public class TituloSocioVinculo : Base
    {
        public TituloSocioVinculo() : base()
        {
        }

        private int m_IdTituloSocioVinculo;
        public int idTituloSocioVinculo
        {
            get { return this.m_IdTituloSocioVinculo; }
            set { this.m_IdTituloSocioVinculo = value; }
        }


        private TituloSocio m_IdTituloSocio;
        public TituloSocio tituloSocio
        {
            get { return this.m_IdTituloSocio; }
            set { this.m_IdTituloSocio = value; }
        }

        private TituloSocio m_IdTituloSocioVinculado;
        public TituloSocio tituloSocioVinculado
        {
            get { return this.m_IdTituloSocioVinculado; }
            set { this.m_IdTituloSocioVinculado = value; }
        }

        private DateTime m_DataInicio;
        public DateTime dataInicio
        {
            get { return this.m_DataInicio; }
            set { this.m_DataInicio = value; }
        }

        private DateTime m_DataFim;
        public DateTime dataFim
        {
            get { return this.m_DataFim; }
            set { this.m_DataFim = value; }
        }

        private Vinculo m_IdVinculo;
        public Vinculo vinculo
        {
            get { return this.m_IdVinculo; }
            set { this.m_IdVinculo = value; }
        }

        private Status m_Status;
        public Status status
        {
            get { return this.m_Status; }
            set { this.m_Status = value; }
        }

        public override string ToString()
        {
            return this.m_IdTituloSocioVinculo.ToString();
        }

        public enum Status
        {
            None, Ativo, Inativo
        }
    }
}
