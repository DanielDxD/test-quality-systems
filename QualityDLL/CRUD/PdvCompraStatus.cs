using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class PdvCompraStatus : WS.CRUD.Base
    {
        public PdvCompraStatus(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraStatus input = (Data.PdvCompraStatus)parametros["Key"];
            Tables.PdvCompraStatus bd = new Tables.PdvCompraStatus();

            bd.idPdvCompraStatus.isNull = true;
            bd.data.value = input.data;
            bd.statusVenda.value = input.statusVenda;
            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }
            if (input.funcionario != null && input.funcionario.idEmpresaRelacionamento > 0)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PdvCompraStatus)parametros["Key"]).idPdvCompraStatus = (int)bd.idPdvCompraStatus.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraStatus input = (Data.PdvCompraStatus)parametros["Key"];
            Tables.PdvCompraStatus bd = (Tables.PdvCompraStatus)this.m_EntityManager.find
            (
                typeof(Tables.PdvCompraStatus),
                new Object[]
                {
                    input.idPdvCompraStatus
                }
            );
            bd.data.value = input.data;
            bd.statusVenda.value = input.statusVenda;
            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }
            if (input.funcionario != null && input.funcionario.idEmpresaRelacionamento > 0)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvCompraStatus bd = new Tables.PdvCompraStatus();

            bd.idPdvCompraStatus.value = ((Data.PdvCompraStatus)parametros["Key"]).idPdvCompraStatus;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvCompraStatus)bd).idPdvCompraStatus.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvCompraStatus)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvCompraStatus)input).idPdvCompraStatus = ((Tables.PdvCompraStatus)bd).idPdvCompraStatus.value;
                    ((Data.PdvCompraStatus)input).statusVenda = ((Tables.PdvCompraStatus)bd).statusVenda.value;
                    ((Data.PdvCompraStatus)input).data = ((Tables.PdvCompraStatus)bd).data.value;

                    if (level < 1)
                    {
                        ((Data.PdvCompraStatus)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvCompra(),
                            ((Tables.PdvCompraStatus)bd).pdvCompra,
                            level + 1
                        );
                    }
                    else { }

                    ((Data.PdvCompraStatus)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PdvCompraStatus)bd).funcionario,
                        level /* Pegar todas as situacoes */
                    );             
                    
                }
                else { }

            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraStatus result = (Data.PdvCompraStatus)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idPdvCompraStatus > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraStatus", result.idPdvCompraStatus));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraStatus.idPdvCompraStatus = @idPdvCompraStatus";
                }
                else { }
                if ((result.pdvCompra != null && result.pdvCompra.idPdvCompra > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", result.pdvCompra.idPdvCompra));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraStatus.idPdvCompra = @idPdvCompra";
                }
                else { }


                if (result.data.Ticks > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("data", result.data));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraStatus.data = @data";
                }
                else { }

                if (!String.IsNullOrEmpty(result.statusVenda))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusVenda", result.statusVenda));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraStatus.statusVenda = @statusVenda";
                }
                else { }

                if (result.funcionario != null && result.funcionario.idEmpresaRelacionamento> 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", result.funcionario.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraStatus.idFuncionario = @idFuncionario";
                }
                else { }

                queryString =
                (
                    "select \n" +
                    "    *\n" +
                    "from \n" + 
                    "    PdvCompraStatus PdvCompraStatus\n" +
                    "inner join pdvCompra pdvCompra\n " +
                    "   on pdvCompra.idPdvCompra = PdvCompraStatus.idPdvCompra\n" +
                    "inner join empresaRelacionamento empresaRelacionamento\n " +
                    "   on empresaRelacionamento.idEmpresaRelacionamento = pdvCompra.idEmpresaRelacionamento\n " +
                    "inner join pdvEstacoes pdvEstacoes\n " +
                    "   on pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao\n " +
                    "left join contasAReceber contasAReceber\n " +
                    "   on contasAReceber.idContasAReceber = pdvCompra.idContasAReceber\n " +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    )
                );

                foreach
                (
                    Tables.PdvCompraStatus _data in
                    (System.Collections.Generic.List<Tables.PdvCompraStatus>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraStatus),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvCompraStatus)this.preencher
                    (
                        new Data.PdvCompraStatus(),
                        _data,
                        0
                    );
                }
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString());
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

            Data.PdvCompraStatus _input = (Data.PdvCompraStatus)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvCompraStatus > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    PdvCompraStatus.idPdvCompraStatus = @idPdvCompraStatus");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraStatus", _input.idPdvCompraStatus));
                    if (!sqlOrderBy.Contains("PdvCompraStatus.idPdvCompraStatus"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraStatus.idPdvCompraStatus");
                    else { }
                }
                else { }

                if (_input.pdvCompra != null)
                {
                    if (_input.pdvCompra.idPdvCompra > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    PdvCompra.idPdvCompra = @idPdvCompra");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.pdvCompra.idPdvCompra));
                        if (!sqlOrderBy.Contains("PdvCompra.idPdvCompra"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompra.idPdvCompra");
                        else { }
                    }
                    else { }                    
                }
                else { }

                if (_input.funcionario != null)
                {

                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresaRelacionamentoFuncionario.idEmpresaRelacionamento = @idEmpresaRelacionamentoFuncionario");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoFuncionario", _input.funcionario.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamentoFuncionario.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoFuncionario.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.funcionario.pessoa != null)
                    {
                        if (_input.funcionario.pessoa.idPessoa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoaFuncionario.idPessoa = @idPessoaFuncionario");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoaFuncionario", _input.funcionario.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoaFuncionario.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoaFuncionario.idPessoa");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }                          

                if (!String.IsNullOrEmpty(_input.statusVenda))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   PdvCompraStatus.statusVenda = @statusVenda");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusVenda", _input.statusVenda));
                    if (!sqlOrderBy.Contains("PdvCompraStatus.statusVenda"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraStatus.statusVenda");
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PdvCompraStatus.* ") +
                    "from \n" + 
                    "   PdvCompraStatus PdvCompraStatus\n" +
                    "       inner join pdvCompra\n" +
                    "           on PdvCompraStatus.idPdvCompra = pdvCompra.idPdvCompra" +
                    "       inner join empresaRelacionamento empresaRelacionamentoFuncionario\n" +
                    "           on pdvCompraStatus.idFuncionario = empresaRelacionamentoFuncionario.idEmpresaRelacionamento \n" +
                    "       inner join pessoa pessoaFuncionario\n" +
                    "           on (empresaRelacionamentoFuncionario.idPessoaRelacionamento = pessoaFuncionario.idPessoa) \n" +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.PdvCompraStatus input = (Data.PdvCompraStatus)parametros["Key"];
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
                    typeof(Tables.PdvCompraStatus),
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
                    Tables.PdvCompraStatus _data in
                    (System.Collections.Generic.List<Tables.PdvCompraStatus>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraStatus),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.PdvCompraStatus(), _data, level);

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
    }
}
