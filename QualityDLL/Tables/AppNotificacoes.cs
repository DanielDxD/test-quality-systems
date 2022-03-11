
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("AppNotificacoes")]
    public class AppNotificacoes : TTableBase
    {
        [TColumn("idAppNotificacao", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdAppNotificacao = new TFieldInteger();
        public TFieldInteger idAppNotificacao
        {
            get { return this.m_IdAppNotificacao; }
        }

        [TColumn("idFuncionario", System.Data.SqlDbType.BigInt, false, false),
TJoin(new String[] { "idFuncionario->idFuncionario" })]
        private Funcionario m_IdFuncionario = null;
        public Funcionario funcionario
        {
            get
            {
                if (this.m_IdFuncionario == null)
                {
                    this.m_IdFuncionario = new Funcionario();
                    foreach (TJoin attribute in this.m_IdFuncionario.GetType().GetCustomAttributes(typeof(TJoin), false))
                    {
                        System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();
                        bool existNullKey = false;
                        for (int i = 0; i < attribute.count; i++)
                        {
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
                                existNullKey = true;
                            else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
                        }
                        if (!existNullKey)
                        {
                            this.m_IdFuncionario.connectionString = this.connectionString;
                            this.m_IdFuncionario.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }
                this.m_IdFuncionario.selfFill();
                return this.m_IdFuncionario;
            }
        }

        [TColumn("dataNotificacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataNotificacao = new TFieldDatetime();
        public TFieldDatetime dataNotificacao
        {
            get { return this.m_DataNotificacao; }
        }

        [TColumn("textoNotificacao", System.Data.SqlDbType.NVarChar, false, false)]
        private TFieldString m_TextoNotificacao = new TFieldString();
        public TFieldString textoNotificacao
        {
            get { return this.m_TextoNotificacao; }
        }

        [TColumn("textoConteudo", System.Data.SqlDbType.NVarChar, false, false)]
        private TFieldString m_TextoConteudo = new TFieldString();
        public TFieldString textoConteudo
        {
            get { return this.m_TextoConteudo; }
        }

    }
}
