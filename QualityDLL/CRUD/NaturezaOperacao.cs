using System;

namespace WS.CRUD
{
    public class NaturezaOperacao : WS.CRUD.Base
    {
        public NaturezaOperacao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.NaturezaOperacao input = (Data.NaturezaOperacao)parametros["Key"];
            Tables.NaturezaOperacao bd = new Tables.NaturezaOperacao();

            bd.idNaturezaOperacao.isNull = true;
            bd.descricao.value = input.descricao;
            bd.codigoContabilReduzido.value = input.codigoContabilReduzido;
            bd.idEmpresa.value = input.idEmpresa;
            bd.pagarReceber.value = input.pagarReceber;
            bd.ativo.value = input.ativo;
            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.persist(bd);
            ((Data.NaturezaOperacao)parametros["Key"]).idNaturezaOperacao = (int)bd.idNaturezaOperacao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.NaturezaOperacao input = (Data.NaturezaOperacao)parametros["Key"];
            Tables.NaturezaOperacao bd = (Tables.NaturezaOperacao)this.m_EntityManager.find
            (
                typeof(Tables.NaturezaOperacao),
                new Object[]
                {
                    input.idNaturezaOperacao
                }
            );

            bd.idNaturezaOperacao.value = input.idNaturezaOperacao;
            bd.descricao.value = input.descricao;
            bd.codigoContabilReduzido.value = input.codigoContabilReduzido;
            bd.idEmpresa.value = input.idEmpresa;
            bd.pagarReceber.value = input.pagarReceber;
            bd.ativo.value = input.ativo;
            if (input.parametroAcrescimo != null && input.parametroAcrescimo.idParametroAcrescimo > 0)
                bd.parametroAcrescimo.idParametroAcrescimo.value = input.parametroAcrescimo.idParametroAcrescimo;
            else
                bd.parametroAcrescimo.idParametroAcrescimo.isNull = true;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.NaturezaOperacao bd = new Tables.NaturezaOperacao();

            bd.idNaturezaOperacao.value = ((Data.NaturezaOperacao)parametros["Key"]).idNaturezaOperacao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.NaturezaOperacao)bd).idNaturezaOperacao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.NaturezaOperacao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.NaturezaOperacao)input).idNaturezaOperacao = ((Tables.NaturezaOperacao)bd).idNaturezaOperacao.value;
                    ((Data.NaturezaOperacao)input).descricao = ((Tables.NaturezaOperacao)bd).descricao.value;
                    ((Data.NaturezaOperacao)input).codigoContabilReduzido = ((Tables.NaturezaOperacao)bd).codigoContabilReduzido.value;
                    ((Data.NaturezaOperacao)input).idEmpresa = ((Tables.NaturezaOperacao)bd).idEmpresa.value;
                    ((Data.NaturezaOperacao)input).pagarReceber = ((Tables.NaturezaOperacao)bd).pagarReceber.value;
                    ((Data.NaturezaOperacao)input).ativo = ((Tables.NaturezaOperacao)bd).ativo.value;
                    ((Data.NaturezaOperacao)input).parametroAcrescimo = (Data.ParametroAcrescimo)(new WS.CRUD.ParametroAcrescimo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ParametroAcrescimo(),
                        ((Tables.NaturezaOperacao)bd).parametroAcrescimo,
                        level + 1
                    );
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.NaturezaOperacao result = (Data.NaturezaOperacao)parametros["Key"];

            try
            {
                result = (Data.NaturezaOperacao)this.preencher
                (
                    new Data.NaturezaOperacao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.NaturezaOperacao),
                        new Object[]
                        {
                            result.idNaturezaOperacao
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


            bool onlyCount = false;

            if (_params != null)
            {
                if (_params.ContainsKey("numRows"))
                    numRows = (int)_params["numRows"];
                else { }

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (bool)_params["onlyCount"];
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

            Data.NaturezaOperacao _input = (Data.NaturezaOperacao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idNaturezaOperacao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "naturezaOperacao.idNaturezaOperacao = @idNaturezaOperacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.idNaturezaOperacao));
                    if (!sqlOrderBy.Contains("naturezaOperacao.idNaturezaOperacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.idNaturezaOperacao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   naturezaOperacao.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("naturezaOperacao.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.descricao");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.pagarReceber))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   naturezaOperacao.pagarReceber = @pagarReceber");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("pagarReceber", _input.pagarReceber));
                    if (!sqlOrderBy.Contains("naturezaOperacao.pagarReceber"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.pagarReceber");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.ativo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   naturezaOperacao.ativo = @ativo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("ativo", _input.ativo));
                    if (!sqlOrderBy.Contains("naturezaOperacao.ativo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.ativo");
                    else { }
                }
                else { }

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "naturezaOperacao.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("naturezaOperacao.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.idEmpresa");
                    else { }
                }
                else { }

                if (_input.parametroAcrescimo != null)
                {
                    if (_input.parametroAcrescimo.idParametroAcrescimo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "naturezaOperacao.idParametroAcrescimo = @idParametroAcrescimo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idParametroAcrescimo", _input.parametroAcrescimo.idParametroAcrescimo));
                        if (!sqlOrderBy.Contains("naturezaOperacao.idParametroAcrescimo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.idParametroAcrescimo");
                        else { }
                    }
                }
                else { }

                /*if(!String.IsNullOrEmpty(_input.idEmpresa.ToString()))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   naturezaOperacao.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("idEmpresa", _input.idEmpresa.ToString()));
                    if (!sqlOrderBy.Contains("naturezaOperacao.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.idEmpresa");
                    else { }
                }
                else { }*/

                if (!String.IsNullOrEmpty(_input.codigoContabilReduzido))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   naturezaOperacao.codigoContabilReduzido = @codigoContabilReduzido");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigoContabilReduzido", _input.codigoContabilReduzido));
                    if (!sqlOrderBy.Contains("naturezaOperacao.codigoContabilReduzido"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "naturezaOperacao.codigoContabilReduzido");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "naturezaOperacao.* ") +
                    "from " +
                    "   naturezaOperacao " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    )
                );

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.NaturezaOperacao input = (Data.NaturezaOperacao)parametros["Key"];
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
                    typeof(Tables.NaturezaOperacao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.NaturezaOperacao _data in
                    (System.Collections.Generic.List<Tables.NaturezaOperacao>)this.m_EntityManager.list
                    (
                        typeof(Tables.NaturezaOperacao),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.NaturezaOperacao(), _data, level);

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
                Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return ((result.Count > 0) ? result.ToArray() : null);
        }
    }
}
