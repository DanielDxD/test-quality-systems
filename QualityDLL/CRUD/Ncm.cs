using System;

namespace WS.CRUD
{
    public class Ncm : WS.CRUD.Base
    {
        public Ncm(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Ncm input = (Data.Ncm)parametros["Key"];
            Tables.Ncm bd = new Tables.Ncm();

            if (input.estado != null && input.estado.idEstado > 0)
                bd.estado.idEstado.value = input.estado.idEstado;
            else { }
            bd.codigo.value = input.codigo;
            bd.ex.value = input.ex;
            bd.chave.value = input.chave;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;
            bd.nacionalFederal.value = input.nacionalFederal;
            bd.importadosFederal.value = input.importadosFederal;
            bd.estadual.value = input.estadual;
            bd.municipal.value = input.municipal;
            bd.vigenciaInicio.value = input.vigenciaInicio;
            bd.vigenciaFim.value = input.vigenciaFim;
            bd.versao.value = input.versao;
            bd.fonte.value = input.fonte;

            this.m_EntityManager.persist(bd);
            ((Data.Ncm)parametros["Key"]).idNcm = (int)bd.idNcm.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Ncm input = (Data.Ncm)parametros["Key"];
            Tables.Ncm bd = (Tables.Ncm)this.m_EntityManager.find
            (
                typeof(Tables.Ncm),
                new Object[]
                {
                    input.idNcm
                }
            );

            if (input.estado != null && input.estado.idEstado > 0)
                bd.estado.idEstado.value = input.estado.idEstado;
            else { }
            bd.codigo.value = input.codigo;
            bd.ex.value = input.ex;
            bd.chave.value = input.chave;
            bd.descricao.value = input.descricao;
            bd.tipo.value = input.tipo;
            bd.nacionalFederal.value = input.nacionalFederal;
            bd.importadosFederal.value = input.importadosFederal;
            bd.estadual.value = input.estadual;
            bd.municipal.value = input.municipal;
            bd.vigenciaInicio.value = input.vigenciaInicio;
            bd.vigenciaFim.value = input.vigenciaFim;
            bd.versao.value = input.versao;
            bd.fonte.value = input.fonte;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Ncm bd = new Tables.Ncm();

            bd.idNcm.value = ((Data.Ncm)parametros["Key"]).idNcm;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.Ncm)bd).idNcm.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Ncm)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Ncm)input).idNcm = ((Tables.Ncm)bd).idNcm.value;
                    ((Data.Ncm)input).estado = (Data.Estado)(new WS.CRUD.Estado(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Estado(),
                        ((Tables.Ncm)bd).estado,
                        level + 1
                    );
                    ((Data.Ncm)input).codigo = ((Tables.Ncm)bd).codigo.value;
                    ((Data.Ncm)input).ex = ((Tables.Ncm)bd).ex.value;
                    ((Data.Ncm)input).tipo = ((Tables.Ncm)bd).tipo.value;
                    ((Data.Ncm)input).descricao = ((Tables.Ncm)bd).descricao.value;
                    ((Data.Ncm)input).nacionalFederal = ((Tables.Ncm)bd).nacionalFederal.value;
                    ((Data.Ncm)input).importadosFederal = ((Tables.Ncm)bd).importadosFederal.value;
                    ((Data.Ncm)input).estadual = ((Tables.Ncm)bd).estadual.value;
                    ((Data.Ncm)input).municipal = ((Tables.Ncm)bd).municipal.value;
                    ((Data.Ncm)input).vigenciaInicio = ((Tables.Ncm)bd).vigenciaInicio.value;
                    ((Data.Ncm)input).vigenciaFim = ((Tables.Ncm)bd).vigenciaFim.value;
                    ((Data.Ncm)input).chave = ((Tables.Ncm)bd).chave.value;
                    ((Data.Ncm)input).versao = ((Tables.Ncm)bd).versao.value;
                    ((Data.Ncm)input).fonte = ((Tables.Ncm)bd).fonte.value;
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Ncm result = (Data.Ncm)parametros["Key"];

            try
            {
                result = (Data.Ncm)this.preencher
                (
                    new Data.Ncm(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Ncm),
                        new Object[]
                        {
                            result.idNcm
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

            Data.Ncm _input = (Data.Ncm)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idNcm > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Ncm.idNcm = @idNcm");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNcm", _input.idNcm));
                    if (!sqlOrderBy.Contains("Ncm.idNcm"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Ncm.idNcm");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Ncm.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("Ncm.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Ncm.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.codigo))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Ncm.codigo = @codigo");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("codigo", _input.codigo));
                    if (!sqlOrderBy.Contains("Ncm.codigo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Ncm.codigo");
                    else { }
                }
                else { }

                if (_input.estado != null)
                {
                    if (_input.estado.idEstado > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ncm.idEstado = @idEstado");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEstado", _input.estado.idEstado));
                        if (!sqlOrderBy.Contains("ncm.idEstado"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ncm.idEstado");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Ncm.* ") +
                    "from " +
                    (
                        "   Ncm Ncm " +
                        "       inner join estado estado " +
                        "           on	estado.idEstado = Ncm.idEstado "
                    ) +
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
            Data.Ncm input = (Data.Ncm)parametros["Key"];
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
                    typeof(Tables.Ncm),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Ncm _data in
                    (System.Collections.Generic.List<Tables.Ncm>)this.m_EntityManager.list
                    (
                        typeof(Tables.Ncm),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    _base = (Data.Base)this.preencher(new Data.Ncm(), _data, level);
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
