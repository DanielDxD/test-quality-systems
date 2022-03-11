using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class PdvCompraTaxaServico : WS.CRUD.Base
    {
        public PdvCompraTaxaServico(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraTaxaServico input = (Data.PdvCompraTaxaServico)parametros["Key"];
            Tables.PdvCompraTaxaServico bd = new Tables.PdvCompraTaxaServico();

            bd.idPdvCompraTaxaServico.isNull = true;
            bd.valor.value = input.valor;
            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PdvCompraTaxaServico)parametros["Key"]).idPdvCompraTaxaServico = (int)bd.idPdvCompraTaxaServico.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraTaxaServico input = (Data.PdvCompraTaxaServico)parametros["Key"];
            Tables.PdvCompraTaxaServico bd = (Tables.PdvCompraTaxaServico)this.m_EntityManager.find
            (
                typeof(Tables.PdvCompraTaxaServico),
                new Object[]
                {
                    input.idPdvCompraTaxaServico
                }
            );
            bd.valor.value = input.valor;
            if (input.pdvCompra != null && input.pdvCompra.idPdvCompra > 0)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvCompraTaxaServico bd = new Tables.PdvCompraTaxaServico();

            bd.idPdvCompraTaxaServico.value = ((Data.PdvCompraTaxaServico)parametros["Key"]).idPdvCompraTaxaServico;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvCompraTaxaServico)bd).idPdvCompraTaxaServico.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvCompraTaxaServico)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvCompraTaxaServico)input).idPdvCompraTaxaServico = ((Tables.PdvCompraTaxaServico)bd).idPdvCompraTaxaServico.value;
                    ((Data.PdvCompraTaxaServico)input).valor = ((Tables.PdvCompraTaxaServico)bd).valor.value;

                    if (level < 1)
                    {
                        ((Data.PdvCompraTaxaServico)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvCompra(),
                            ((Tables.PdvCompraTaxaServico)bd).pdvCompra,
                            level + 1
                        );
                    }
                    else { }           
                    
                }
                else { }

            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraTaxaServico result = (Data.PdvCompraTaxaServico)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idPdvCompraTaxaServico > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraTaxaServico", result.idPdvCompraTaxaServico));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraTaxaServico.idPdvCompraTaxaServico = @idPdvCompraTaxaServico";
                }
                else { }
                if ((result.pdvCompra != null && result.pdvCompra.idPdvCompra > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", result.pdvCompra.idPdvCompra));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "PdvCompraTaxaServico.idPdvCompra = @idPdvCompra";
                }
                else { }

                queryString =
                (
                    "select \n" +
                    "    *\n" +
                    "from \n" + 
                    "    PdvCompraTaxaServico PdvCompraTaxaServico\n" +
                    "inner join pdvCompra pdvCompra\n " +
                    "   on pdvCompra.idPdvCompra = PdvCompraTaxaServico.idPdvCompra\n" +
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
                    Tables.PdvCompraTaxaServico _data in
                    (System.Collections.Generic.List<Tables.PdvCompraTaxaServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraTaxaServico),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvCompraTaxaServico)this.preencher
                    (
                        new Data.PdvCompraTaxaServico(),
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

            Data.PdvCompraTaxaServico _input = (Data.PdvCompraTaxaServico)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvCompraTaxaServico > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    PdvCompraTaxaServico.idPdvCompraTaxaServico = @idPdvCompraTaxaServico");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraTaxaServico", _input.idPdvCompraTaxaServico));
                    if (!sqlOrderBy.Contains("PdvCompraTaxaServico.idPdvCompraTaxaServico"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraTaxaServico.idPdvCompraTaxaServico");
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

                


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "PdvCompraTaxaServico.* ") +
                    "from \n" +
                    " inner join pdvCompra pdvCompra\n " +
                    "   on pdvCompra.idPdvCompra = PdvCompraTaxaServico.idPdvCompra\n " +
                    " inner join pdvEstacoes pdvEstacoes\n " +
                    "   on pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao\n " +
                    " left join contasAReceber contasAReceber\n " +
                    "   on contasAReceber.idContasAReceber = pdvCompra.idContasAReceber\n " +
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
            Data.PdvCompraTaxaServico input = (Data.PdvCompraTaxaServico)parametros["Key"];
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
                    typeof(Tables.PdvCompraTaxaServico),
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
                    Tables.PdvCompraTaxaServico _data in
                    (System.Collections.Generic.List<Tables.PdvCompraTaxaServico>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraTaxaServico),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.PdvCompraTaxaServico(), _data, level);

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
