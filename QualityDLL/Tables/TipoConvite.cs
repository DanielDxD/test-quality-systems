
using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("TipoConvite")]
    public class TipoConvite : TTableBase
    {
        [TColumn("idTipoConvite", System.Data.SqlDbType.Int, true, true)]
        private TFieldInteger m_IdTipoConvite = new TFieldInteger();
        public TFieldInteger idTipoConvite
        {
            get { return this.m_IdTipoConvite; }
        }

        [TColumn("idadeInicial", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdadeInicial = new TFieldInteger();
        public TFieldInteger idadeInicial
        {
            get { return this.m_IdadeInicial; }
        }

        [TColumn("idadeFinal", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_IdadeFinal = new TFieldInteger();
        public TFieldInteger idadeFinal
        {
            get { return this.m_IdadeFinal; }
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_Descricao; }
        }

        [TColumn("modeloTermo", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_ModeloTermo = new TFieldString();
        public TFieldString modeloTermo
        {
            get { return this.m_ModeloTermo; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_Valor = new TFieldDouble();
        public TFieldDouble valor
        {
            get { return this.m_Valor; }
        }

        [
         TColumn("idNaturezaOperacao", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idNaturezaOperacao->idNaturezaOperacao" })
        ]
        private NaturezaOperacao m_IdNaturezaOperacao;
        public NaturezaOperacao naturezaOperacao
        {
            get
            {
                if (this.m_IdNaturezaOperacao == null)
                {
                    this.m_IdNaturezaOperacao = new NaturezaOperacao();

                    foreach (TJoin attribute in this.m_IdNaturezaOperacao.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdNaturezaOperacao.connectionString = this.connectionString;
                            this.m_IdNaturezaOperacao.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdNaturezaOperacao.selfFill();

                return this.m_IdNaturezaOperacao;
            }
        }

        [
         TColumn("idDepartamento", System.Data.SqlDbType.BigInt, false, false),
         TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_IdDepartamento;
        public Departamento departamento
        {
            get
            {
                if (this.m_IdDepartamento == null)
                {
                    this.m_IdDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_IdDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_IdDepartamento.connectionString = this.connectionString;
                            this.m_IdDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_IdDepartamento.selfFill();

                return this.m_IdDepartamento;
            }
        }
    }
}
