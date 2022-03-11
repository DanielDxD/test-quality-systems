using System;
using System.Data;

namespace Data
{
    //[Serializable]
    public class ApiToken : Base
    {

        public ApiToken() : base()
        {
        }

        private Usuario m_IdUsuario;
        public Usuario usuario
        {
            get { return this.m_IdUsuario; }
            set { this.m_IdUsuario = value; }
        }

        private ApiCredencial m_IdApiCredencial;
        public ApiCredencial apiCredencial
        {
            get { return this.m_IdApiCredencial; }
            set { this.m_IdApiCredencial = value; }
        }

        private string m_Token;
        public string token
        {
            get { return this.m_Token; }
            set { this.m_Token = value; }
        }

        private DateTime m_ExpiresIn;
        public DateTime expiresIn
        {
            get { return this.m_ExpiresIn; }
            set { this.m_ExpiresIn = value; }
        }

        public void IncluirToken(int idUsuario, string access_token, string expires_in, int idApiCredencial)
        {
            string query = String.Format(@"
SELECT * FROM apiToken apit
WHERE 
	apit.idUsuario = {0} AND
	apit.idApiCredencial = {1}", idUsuario, idApiCredencial);

            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddSeconds(Convert.ToDouble(expires_in)).ToLocalTime();

            DataTable results = Utils.Utils.em.executeData(query, null);
            if (results != null && results.Rows.Count > 0)
            {
                
                Data.ApiToken apiToken = new ApiToken
                {
                    operacao = ENum.eOperacao.ALTERAR,
                    apiCredencial = new ApiCredencial
                    {
                        idApiCredencial = idApiCredencial
                    },
                    token = access_token,
                    expiresIn = dateTime,
                    usuario = new Usuario
                    {
                        idUsuario = idUsuario
                    }
                };
                apiToken = (Data.ApiToken)Utils.Utils.sr(0).atualizar(apiToken);

            }
            else
            {
                Data.ApiToken apiToken = new ApiToken
                {
                    operacao = ENum.eOperacao.INCLUIR,
                    apiCredencial = new ApiCredencial
                    {
                        idApiCredencial = idApiCredencial
                    },
                    token = access_token,
                    expiresIn = dateTime,
                    usuario = new Usuario
                    {
                        idUsuario = idUsuario
                    }
                };
                apiToken = (Data.ApiToken)Utils.Utils.sr(0).atualizar(apiToken);
            }
        }

    }
}
