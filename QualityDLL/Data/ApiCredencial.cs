using DataTypes;
using System;

namespace Data
{
    //[Serializable]
    public class ApiCredencial : Base
    {

        public ApiCredencial() : base()
        {
        }

        private int m_IdApiCredencial;
        public int idApiCredencial
        {
            get { return this.m_IdApiCredencial; }
            set { this.m_IdApiCredencial = value; }
        }

        private Empresa m_IdEmpresa;
        public Empresa empresa
        {
            get { return this.m_IdEmpresa; }
            set { this.m_IdEmpresa = value; }
        }

        public string urlProvider
        {
            get; set;
        }

        private ProvedorToken m_Provedor;
        public ProvedorToken provedor
        {
            get { return this.m_Provedor; }
            set { this.m_Provedor = value; }
        }

        private string m_Descricao;
        public string descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        private string m_Client_id;
        public string client_id
        {
            get { return this.m_Client_id; }
            set { this.m_Client_id = value; }
        }

        private string m_Client_secret;
        public string client_secret
        {
            get { return this.m_Client_secret; }
            set { this.m_Client_secret = value; }
        }

        private string m_Observacao;
        public string observacao
        {
            get { return this.m_Observacao; }
            set { this.m_Observacao = value; }
        }

        public string token { get; set; }

    }
}
