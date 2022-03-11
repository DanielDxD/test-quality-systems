using System;

namespace WS.CRUD
{
    public class DocumentoRecebimentoContasAReceber : WS.CRUD.Base
    {
        public DocumentoRecebimentoContasAReceber(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimentoContasAReceber input = (Data.DocumentoRecebimentoContasAReceber)parametros["Key"];
            Tables.DocumentoRecebimentoContasAReceber bd = new Tables.DocumentoRecebimentoContasAReceber();

            bd.idDocumentoRecebimentoContasAReceber.isNull = true;
            bd.idDocumentoRecebimento.value = input.idDocumentoRecebimento;
            bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            bd.valorBase.value = input.valorBase;
            bd.valorRecebido.value = input.valorRecebido;

            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;

            this.m_EntityManager.persist(bd);

            ((Data.DocumentoRecebimentoContasAReceber)parametros["Key"]).idDocumentoRecebimentoContasAReceber = (int)bd.idDocumentoRecebimentoContasAReceber.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimentoContasAReceber input = (Data.DocumentoRecebimentoContasAReceber)parametros["Key"];
            Tables.DocumentoRecebimentoContasAReceber bd = (Tables.DocumentoRecebimentoContasAReceber)this.m_EntityManager.find
            (
                typeof(Tables.DocumentoRecebimentoContasAReceber),
                new Object[]
                {
                    input.idDocumentoRecebimentoContasAReceber
                }
            );

            bd.idDocumentoRecebimento.value = input.idDocumentoRecebimento;
            bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            bd.valorBase.value = input.valorBase;
            bd.valorRecebido.value = input.valorRecebido;

            bd.valorMulta.value = input.valorMulta;
            bd.valorJuros.value = input.valorJuros;
            bd.valorDesconto.value = input.valorDesconto;
            bd.valorCM.value = input.valorCM;
            bd.valorINSSRetido.value = input.valorINSSRetido;
            bd.valorISSRetido.value = input.valorISSRetido;
            bd.valorIRRetido.value = input.valorIRRetido;
            bd.valorPISRetido.value = input.valorPISRetido;
            bd.valorCOFINSRetido.value = input.valorCOFINSRetido;
            bd.valorCSLLRetido.value = input.valorCSLLRetido;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DocumentoRecebimentoContasAReceber bd = new Tables.DocumentoRecebimentoContasAReceber();

            bd.idDocumentoRecebimentoContasAReceber.value = ((Data.DocumentoRecebimentoContasAReceber)parametros["Key"]).idDocumentoRecebimentoContasAReceber;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DocumentoRecebimentoContasAReceber)bd).idDocumentoRecebimentoContasAReceber.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DocumentoRecebimentoContasAReceber)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DocumentoRecebimentoContasAReceber)input).idDocumentoRecebimentoContasAReceber = ((Tables.DocumentoRecebimentoContasAReceber)bd).idDocumentoRecebimentoContasAReceber.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).idDocumentoRecebimento = ((Tables.DocumentoRecebimentoContasAReceber)bd).idDocumentoRecebimento.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.DocumentoRecebimentoContasAReceber)bd).contasAReceber,
                        level + 1
                    );
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorBase = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorBase.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorRecebido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorRecebido.value;

                    ((Data.DocumentoRecebimentoContasAReceber)input).valorMulta = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorMulta.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorJuros = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorJuros.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorDesconto = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorDesconto.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorCM = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorCM.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorINSSRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorINSSRetido.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorISSRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorISSRetido.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorIRRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorIRRetido.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorPISRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorPISRetido.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorCOFINSRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorCOFINSRetido.value;
                    ((Data.DocumentoRecebimentoContasAReceber)input).valorCSLLRetido = ((Tables.DocumentoRecebimentoContasAReceber)bd).valorCSLLRetido.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimentoContasAReceber result = (Data.DocumentoRecebimentoContasAReceber)parametros["Key"];

            try
            {
                result = (Data.DocumentoRecebimentoContasAReceber)this.preencher
                (
                    new Data.DocumentoRecebimentoContasAReceber(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.DocumentoRecebimentoContasAReceber),
                        new Object[]
                        {
                            result.idDocumentoRecebimentoContasAReceber
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override String makeSelect(Type classBase, Data.Base input, Object _fieldKeys, System.Collections.Hashtable _params = null)
        {
            String
                result = "",
                sqlWhere = "",
                sqlOrderBy = "";

            int
                numRows = 0,
                offSet = -1;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("offSet"))
                    offSet = (int)_params["offSet"];
                else { }

                if (_params.ContainsKey("where"))
                    sqlWhere = ((String)_params["where"] ?? "");
                else { }

                if (_params.ContainsKey("orderBy"))
                    sqlOrderBy = ((String)_params["orderBy"] ?? "");
                else { }
            }
            else { }

            Data.DocumentoRecebimentoContasAReceber _input = (Data.DocumentoRecebimentoContasAReceber)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere = "";

                if (_input.idDocumentoRecebimentoContasAReceber > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoRecebimentoContasAReceber.idDocumentoRecebimentoContasAReceber = @idDocumentoRecebimentoContasAReceber");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimentoContasAReceber", _input.idDocumentoRecebimentoContasAReceber));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoRecebimentoContasAReceber.idDocumentoRecebimentoContasAReceber");
                }
                else { }

                if (_input.idDocumentoRecebimento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "documentoRecebimentoContasAReceber.idDocumentoRecebimento = @idDocumentoRecebimento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDocumentoRecebimento", _input.idDocumentoRecebimento));
                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "documentoRecebimentoContasAReceber.idDocumentoRecebimento");
                }
                else { }

                if (_input.contasAReceber != null)
                {
                    if (_input.contasAReceber.idEmpresa > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.idEmpresa = @idEmpresa");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.contasAReceber.idEmpresa));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idEmpresa");
                    }
                    else { }

                    if (_input.contasAReceber.idContasAReceber > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "contasAReceber.idContasAReceber = @idContasAReceber");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.contasAReceber.idContasAReceber));
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idContasAReceber");
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   documentoRecebimentoContasAReceber.* " +
                    "from " +
                    (
                        "   documentoRecebimentoContasAReceber documentoRecebimentoContasAReceber " +
                        "       inner join documentoRecebimento documentoRecebimento " +
                        "           on  documentoRecebimento.idDocumentoRecebimento = documentoRecebimentoContasAReceber.idDocumentoRecebimento " +
                        "       inner join contasAReceber contasAReceber " +
                        "           on  contasAReceber.idContasAReceber = documentoRecebimentoContasAReceber.idContasAReceber " +
                        "       left join empresaRelacionamento empresaRelacionamento\n" +
                        "           on contasAReceber.idEmpresaRelacionamento = empresaRelacionamento.idEmpresaRelacionamento" +
                        "       inner join pessoa pessoa\n" +
                        "           on	pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento\n"
                    ) +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                    (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.DocumentoRecebimentoContasAReceber input = (Data.DocumentoRecebimentoContasAReceber)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String
                        _filter = (String)parametros["Filter"],
                        _keys = "";

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];

                        if (!_keys.Contains("[" + _key + "]"))
                        {
                            _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                            _keys += "[" + _key + "]";
                        }
                        else { }

                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.DocumentoRecebimentoContasAReceber),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.DocumentoRecebimentoContasAReceber _data in
                    (System.Collections.Generic.List<Tables.DocumentoRecebimentoContasAReceber>)this.m_EntityManager.list
                    (
                        typeof(Tables.DocumentoRecebimentoContasAReceber),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    //if (mode == "Roll")
                    //{
                    //_base = new Data.ResultadoConsulta();

                    //if (!_data.codConsCampo.codUsuario.isNull)
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codConsCampo.codUsuario.value;
                    //    ((Data.ResultadoConsulta)_base).descricao =
                    //    (
                    //        _data.descricao.value + ( + _data.codConsCampo.idCadastro.nome.value + )
                    //    );
                    //}
                    //else
                    //{
                    //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                    //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                    //}
                    //}
                    //else
                    _base = (Data.Base)this.preencher(new Data.DocumentoRecebimentoContasAReceber(), _data, level);

                    if (report != null)
                        report.ProcessRecord(_base);
                    else
                        result.Add(_base);
                }

                if (report != null)
                    report.ProcessRecord(null);
                else { }

                _fieldKeys.Clear();
                _fieldKeys = null;
                _select = null;
            }
            catch (Exception e)
            {
                System.Console.Out.Write(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
