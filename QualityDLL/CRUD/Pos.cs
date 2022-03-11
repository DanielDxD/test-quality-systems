using System;

namespace WS.CRUD
{
    public class Pos : WS.CRUD.Base
    {
        public Pos(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Pos input = (Data.Pos)parametros["Key"];
            Tables.Pos bd = new Tables.Pos();

            bd.idPos.isNull = true;
            bd.idPos.value = input.idPos;

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            bd.descricao.value = input.descricao;
            bd.impressora.value = input.impressora;
            bd.fixarMenuPrePago.value = input.fixarMenuPrePago == "s";
            this.m_EntityManager.persist(bd);

            ((Data.Pos)parametros["Key"]).idPos = (int)bd.idPos.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Pos input = (Data.Pos)parametros["Key"];
            Tables.Pos bd = (Tables.Pos)this.m_EntityManager.find
            (
                typeof(Tables.Pos),
                new Object[]
                {
                    input.idPos
                }
            );

            bd.idPos.value = input.idPos;
            bd.descricao.value = input.descricao;
            bd.impressora.value = input.impressora;
            bd.fixarMenuPrePago.value = input.fixarMenuPrePago == "s";
            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }
            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Pos bd = new Tables.Pos();

            bd.idPos.value = ((Data.Pos)parametros["Key"]).idPos;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Pos)bd).idPos.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Pos)input).operacao = ENum.eOperacao.NONE;
                    ((Data.Pos)input).idPos = ((Tables.Pos)bd).idPos.value;
                    ((Data.Pos)input).descricao = ((Tables.Pos)bd).descricao.value;
                    ((Data.Pos)input).impressora = ((Tables.Pos)bd).impressora.value;
                    ((Data.Pos)input).fixarMenuPrePago = ((Tables.Pos)bd).fixarMenuPrePago.value ? "s" : "n";

                    ((Data.Pos)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacao(),
                        ((Tables.Pos)bd).pdvEstacao,
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
            Data.Pos result = (Data.Pos)parametros["Key"];

            try
            {
                result = (Data.Pos)this.preencher
                (
                    new Data.Pos(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Pos),
                        new Object[]
                        {
                            result.idPos
                        }
                    ),
                    0
                );
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
                throw new Exception(e.Message);
            }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.Pos input = (Data.Pos)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);


            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> _fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();

                if (parametros["Filter"] != null)
                {
                    String _filter = (String)parametros["Filter"];

                    while (_filter.Contains("@"))
                    {
                        String _key = _filter.Substring(_filter.IndexOf("@")).Split(new char[] { ' ', ')' })[0];
                        _fieldKeys.Add((EJB.TableBase.TField)parametros[_key]);
                        _filter = _filter.Substring(_filter.IndexOf("@") + _key.Length);
                    }
                }
                else { }

                String _select = this.makeSelect
                (
                    typeof(Tables.Pos),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.Pos _data in
                    (System.Collections.Generic.List<Tables.Pos>)this.m_EntityManager.list
                    (
                        typeof(Tables.Pos),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.Pos(), _data, level);
                    result.Add(_base);
                }


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

            Data.Pos _input = (Data.Pos)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPos > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pos.idPos = @idPos");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPos", _input.idPos));
                    if (!sqlOrderBy.Contains("Pos.idPos"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pos.idPos");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pos.descricao LIKE @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("Pos.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pos.descricao");
                    else { }
                }
                else { }

                if(_input.pdvEstacao != null)
                {
                    if(_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Pos.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        if (!sqlOrderBy.Contains("Pos.idPdvEstacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Pos.idPdvEstacao");
                        else { }
                    }
                    else { }

                    if(_input.pdvEstacao.departamento != null)
                    {
                        if(_input.pdvEstacao.departamento.idEmpresa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "departamento.idEmpresa = @idEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.pdvEstacao.departamento.idEmpresa));
                            if (!sqlOrderBy.Contains("departamento.idEmpresa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : " Pos.* ") +
                    "from Pos Pos " +
                    "\n inner join pdvEstacoes ON pdvEstacoes.idPdvEstacao = Pos.idPdvEstacao \n" +
                    "\n left join departamento ON departamento.idDepartamento = pdvEstacoes.idDepartamento \n" +
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

    }
}
