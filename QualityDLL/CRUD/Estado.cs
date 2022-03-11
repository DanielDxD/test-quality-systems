using System;

namespace WS.CRUD
{
    public class Estado : WS.CRUD.Base
    {
        public Estado(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Estado input = (Data.Estado)parametros["Key"];
            Tables.Estado bd = new Tables.Estado();

            bd.idEstado.isNull = true;
            bd.uf.value = input.uf;
            bd.descricao.value = input.descricao;
            bd.aliquotaInter.value = input.aliquotaInter;
            bd.aliquotaIntra.value = input.aliquotaIntra;
            bd.fcp.value = input.fcp;
            if (input.pais != null)
                bd.pais.idPais.value = input.pais.idPais;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.Estado)parametros["Key"]).idEstado = (int)bd.idEstado.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Estado input = (Data.Estado)parametros["Key"];
            Tables.Estado bd = (Tables.Estado)this.m_EntityManager.find
            (
                typeof(Tables.Estado),
                new Object[]
                {
                    input.idEstado
                }
            );

            bd.uf.value = input.uf;
            bd.descricao.value = input.descricao;
            bd.aliquotaInter.value = input.aliquotaInter;
            bd.aliquotaIntra.value = input.aliquotaIntra;
            bd.fcp.value = input.fcp;
            if (input.pais != null)
                bd.pais.idPais.value = input.pais.idPais;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Estado bd = new Tables.Estado();

            bd.idEstado.value = ((Data.Estado)parametros["Key"]).idEstado;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Estado)bd).idEstado.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Estado)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Estado)input).idEstado = ((Tables.Estado)bd).idEstado.value;
                    ((Data.Estado)input).uf = ((Tables.Estado)bd).uf.value;
                    ((Data.Estado)input).descricao = ((Tables.Estado)bd).descricao.value;
                    ((Data.Estado)input).aliquotaInter = ((Tables.Estado)bd).aliquotaInter.value;
                    ((Data.Estado)input).aliquotaIntra = ((Tables.Estado)bd).aliquotaIntra.value;
                    ((Data.Estado)input).fcp = ((Tables.Estado)bd).fcp.value;
                    ((Data.Estado)input).pais = (Data.Pais)(new WS.CRUD.Pais(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pais(),
                        ((Tables.Estado)bd).pais,
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
            Data.Estado result = (Data.Estado)parametros["Key"];

            try
            {
                result = (Data.Estado)this.preencher
                (
                    new Data.Estado(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Estado),
                        new Object[]
                        {
                            result.idEstado
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

            Data.Estado _input = (Data.Estado)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if ((_input.pais != null) && (_input.pais.idPais > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + " pais.idPais = @idPais");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPais", _input.pais.idPais));
                    if (!sqlOrderBy.Contains("pais.idPais"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pais.idPais");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   estado.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("estado.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estado.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.uf))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   estado.uf = @uf");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("uf", _input.uf));
                    if (!sqlOrderBy.Contains("estado.uf"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "estado.uf");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "estado.* ") +
                    "from \n" +
                    "   estado estado\n" +
                    "       inner join pais pais\n" +
                    "           on estado.idPais = pais.idPais \n" +
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
            Data.Estado input = (Data.Estado)parametros["Key"];
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
                String _select = this.makeSelect
                (
                    typeof(Tables.Estado),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                foreach
                (
                    Tables.Estado _data in
                    (System.Collections.Generic.List<Tables.Estado>)this.m_EntityManager.list
                    (
                        typeof(Tables.Estado),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.Estado(), _data, level);

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
