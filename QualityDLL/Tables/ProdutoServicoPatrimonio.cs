using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
    [TTable("produtoServicoPatrimonio")]
    public class ProdutoServicoPatrimonio : TTableBase
    {
        [TColumn("idProdutoServicoPatrimonio", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_idProdutoServicoPatrimonio = new TFieldInteger();
        public TFieldInteger idProdutoServicoPatrimonio
        {
            get { return this.m_idProdutoServicoPatrimonio; }
        }

        [
            TColumn("idProdutoServico", System.Data.SqlDbType.BigInt, false, false),
            TJoin(new String[] { "idProdutoServico->idProdutoServico" })
        ]
        private ProdutoServico m_idProdutoServico = null;
        public ProdutoServico produtoServico
        {
            get
            {
                if (this.m_idProdutoServico == null)
                {
                    this.m_idProdutoServico = new ProdutoServico();

                    foreach (TJoin attribute in this.m_idProdutoServico.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idProdutoServico.connectionString = this.connectionString;
                            this.m_idProdutoServico.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idProdutoServico.selfFill();

                return this.m_idProdutoServico;
            }
        }

        [
            TColumn("idEmpresa", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idEmpresa->idEmpresa" })
        ]
        private Empresa m_idEmpresa = null;
        public Empresa empresa
        {
            get
            {
                if (this.m_idEmpresa == null)
                {
                    this.m_idEmpresa = new Empresa();

                    foreach (TJoin attribute in this.m_idEmpresa.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idEmpresa.connectionString = this.connectionString;
                            this.m_idEmpresa.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idEmpresa.selfFill();

                return this.m_idEmpresa;
            }
        }

        [
            TColumn("idDepartamento", System.Data.SqlDbType.Int, false, false),
            TJoin(new String[] { "idDepartamento->idDepartamento" })
        ]
        private Departamento m_idDepartamento = null;
        public Departamento departamento
        {
            get
            {
                if (this.m_idDepartamento == null)
                {
                    this.m_idDepartamento = new Departamento();

                    foreach (TJoin attribute in this.m_idDepartamento.GetType().GetCustomAttributes(typeof(TJoin), false))
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
                            this.m_idDepartamento.connectionString = this.connectionString;
                            this.m_idDepartamento.keyFields = _keys.ToArray();
                        }
                        else { }
                    }
                }
                else { }

                this.m_idDepartamento.selfFill();

                return this.m_idDepartamento;
            }
        }

        [TColumn("codigoPatrimonial", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_codigoPatrimonial = new TFieldString();
        public TFieldString codigoPatrimonial
        {
            get { return this.m_codigoPatrimonial; }
        }

        [TColumn("dataTombamento", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataTombamento = new TFieldDatetime();
        public TFieldDatetime dataTombamento
        {
            get { return this.m_dataTombamento; }
        }

        [TColumn("dataInclusao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataInclusao = new TFieldDatetime();
        public TFieldDatetime dataInclusao
        {
            get { return this.m_dataInclusao; }
        }

        [TColumn("dataAquisicao", System.Data.SqlDbType.Date, false, false)]
        private TFieldDatetime m_dataAquisicao = new TFieldDatetime();
        public TFieldDatetime dataAquisicao
        {
            get { return this.m_dataAquisicao; }
        }

        [TColumn("modalidadeAquisicao", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_modalidadeAquisicao = new TFieldString();
        public TFieldString modalidadeAquisicao
        {
            get { return this.m_modalidadeAquisicao; }
        }

        [TColumn("estadoConservacao", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_estadoConservacao = new TFieldString();
        public TFieldString estadoConservacao
        {
            get { return this.m_estadoConservacao; }
        }

        [TColumn("situacaoUtilitaria", System.Data.SqlDbType.Char, false, false)]
        private TFieldString m_situacaoUtilitaria = new TFieldString();
        public TFieldString situacaoUtilitaria
        {
            get { return this.m_situacaoUtilitaria; }
        }

        [TColumn("valorAquisicaoEstimado", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorAquisicaoEstimado = new TFieldDouble();
        public TFieldDouble valorAquisicaoEstimado
        {
            get { return this.m_valorAquisicaoEstimado; }
        }

        [TColumn("valorResidual", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorResidual = new TFieldDouble();
        public TFieldDouble valorResidual
        {
            get { return this.m_valorResidual; }
        }

        [TColumn("valorAtual", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_valorAtual = new TFieldDouble();
        public TFieldDouble valorAtual
        {
            get { return this.m_valorAtual; }
        }

        [TColumn("dataBaixa", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_dataBaixa = new TFieldDatetime();
        public TFieldDatetime dataBaixa
        {
            get { return this.m_dataBaixa; }
        }

        [TColumn("motivoBaixa", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_motivoBaixa = new TFieldString();
        public TFieldString motivoBaixa
        {
            get { return this.m_motivoBaixa; }
        }

        [TColumn("vidaUtil", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_vidaUtil = new TFieldInteger();
        public TFieldInteger vidaUtil
        {
            get { return this.m_vidaUtil; }
        }

        [TColumn("observacao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_observacao = new TFieldString();
        public TFieldString observacao
        {
            get { return this.m_observacao; }
        }

        [TColumn("numeroNotaFiscal", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroNotaFiscal = new TFieldString();
        public TFieldString numeroNotaFiscal
        {
            get { return this.m_numeroNotaFiscal; }
        }

        [TColumn("numeroSerie", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_numeroSerie = new TFieldString();
        public TFieldString numeroSerie
        {
            get { return this.m_numeroSerie; }
        }
    }
}
