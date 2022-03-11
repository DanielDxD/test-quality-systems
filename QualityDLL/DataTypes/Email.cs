using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace DataTypes
{
    public class Email
    {
        public Email()
        {

            if (this._msg == null)
                this._msg = new MailMessage();
            else { }
        }

        public Email(string MailFrom)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }

            _msg.From = new MailAddress(MailFrom);
        }

        public Email(string Nome, string From)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }

            _msg.From = new MailAddress(From, Nome);
        }

        private Provedores _provedor = null;
        private MailMessage _msg = null;
        private string _senha = null;
        private string _from = null;

        private string m_Assunto;
        public string Assunto
        {
            get { return this.m_Assunto; }
            set
            {
                if (this._msg == null)
                    this._msg = new MailMessage();
                else { }

                this._msg.Subject = value;
                this.m_Assunto = value;
            }
        }

        private Prioridade m_prioridade;
        public Prioridade prioridade
        {
            get { return this.m_prioridade; }
            set { this.m_prioridade = value; }
        }

        private string m_Body;
        public string Body
        {
            get { return this.m_Body; }
            set
            {
                if (this._msg == null)
                    this._msg = new MailMessage();
                else { }

                this._msg.Body = value;
                this._msg.IsBodyHtml = true;
                this.m_Body = value;
            }
        }

        private string m_To;
        public string To
        {
            get { return this.m_To; }
            set
            {
                if (this._msg == null)
                    this._msg = new MailMessage();
                else { }

                char splitChar = value.Contains(";") ? ';' : ',';
                foreach (String _item in value.Split(splitChar))
                    this._msg.To.Add(_item);

                this.m_To = value;
            }
        }

        public void From(string from)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }

            this._msg.From = new MailAddress(from);
        }

        public void From(string from, string name)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }

            this._msg.From = new MailAddress(from, name);
        }

        public void Credenciais(string senha)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }
            _from = this._msg.From.Address;
            _senha = senha;
        }

        public void Credenciais(string from, string senha)
        {
            if (this._msg == null)
                this._msg = new MailMessage();
            else { }
            _from = from;
            _senha = senha;
        }

        public void enviar()
        {

            if (_provedor == null)
                throw new Exception("Informar o provedor!");
            else { }

            SmtpClient client = new SmtpClient(_provedor.host, _provedor.porta);
            client.EnableSsl = _provedor.ssl;
            client.Timeout = 10000;
            client.Credentials = new NetworkCredential(_from, _senha);
            _sendEmail(client);
        }

        private bool _sendEmail(SmtpClient client)
        {

            if (this._msg == null)
                this._msg = new MailMessage();
            else { }

            if (_provedor == null)
                throw new Exception("Informar o provedor!");
            else { }

            if (String.IsNullOrEmpty(_from))
                throw new Exception("Informar o usuário de email para autenticação do SMTP!");
            else { }

            if (String.IsNullOrEmpty(_senha))
                throw new Exception("Informar a senha para autenticação do SMTP!");
            else { }

            if (_provedor != null)
            {
                if (_provedor.provedor == "custom")
                {
                    if (!String.IsNullOrEmpty(_provedor.host))
                        throw new Exception("Informar o host do provedor!");
                    else { }

                    if (_provedor.porta == 0)
                        throw new Exception("Informar a porta do provedor");
                    else { }
                }
            }
            else { }

            if (_msg.From == null)
                _msg.From = new MailAddress(_from);
            else { }

            _msg.Priority = (MailPriority)prioridade;

            try
            {
                client.Send(this._msg);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        public void setProvedor(string provedor)
        {

            if (provedor == "custom")
                throw new Exception("Necessário informar a porta, SSL e o host de SMTP");
            else { }

            _provedor = new Provedores
            {
                provedor = provedor
            };

            if (_msg == null)
                _msg = new MailMessage();
            else { }
        }

        public void setProvedor(string provedor, int porta, bool ssl, string host)
        {

            _provedor = new Provedores
            {
                provedor = provedor,
                porta = porta,
                ssl = ssl,
                host = host
            };
        }

    }

    public class Provedores
    {
        private string m_Provedor;
        public string provedor
        {
            get { return this.m_Provedor; }
            set
            {

                switch (value)
                {
                    case "gmail":
                        {
                            this.m_ssl = true;
                            this.porta = 587;
                            this.m_host = "smtp.gmail.com";
                            break;
                        }

                    case "hotmail":
                        {
                            this.m_ssl = true;
                            this.porta = 587;
                            this.m_host = "smtp.live.com";
                            break;
                        }
                }
                this.m_Provedor = value;
            }
        }

        private string m_host;
        public string host
        {
            get { return this.m_host; }
            set { this.m_host = value; }
        }

        private int m_Porta;
        public int porta
        {
            get { return this.m_Porta; }
            set { this.m_Porta = value; }
        }

        private bool m_ssl;
        public bool ssl
        {
            get { return this.m_ssl; }
            set { this.m_ssl = value; }
        }
    }

    public enum Prioridade
    {
        //
        // Summary:
        //     The email has normal priority.
        Normal = 0,
        //
        // Summary:
        //     The email has low priority.
        Baixa = 1,
        //
        // Summary:
        //     The email has high priority.
        Alta = 2
    }
}
