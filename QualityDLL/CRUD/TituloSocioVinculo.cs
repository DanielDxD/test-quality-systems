using System;

namespace WS.CRUD
{
    public class TituloSocioVinculo : WS.CRUD.Base
    {
        public TituloSocioVinculo(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioVinculo input = (Data.TituloSocioVinculo)parametros["Key"];
            Tables.TituloSocioVinculo bd = new Tables.TituloSocioVinculo();

            bd.idTituloSocioVinculo.isNull = true;
            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }
            if (input.tituloSocioVinculado != null && input.tituloSocioVinculado.idTituloSocio > 0)
                bd.tituloSocioVinculado.idTituloSocio.value = input.tituloSocioVinculado.idTituloSocio;
            else { }

            if (input.dataInicio.Ticks > 0)
                bd.dataInicio.value = input.dataInicio;
            else
            {
                bd.dataInicio.value = DateTime.Now;
            }

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }

            if (input.vinculo != null && input.vinculo.idVinculo > 0)
                bd.vinculo.idVinculo.value = input.vinculo.idVinculo;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.TituloSocioVinculo)parametros["Key"]).idTituloSocioVinculo = (int)bd.idTituloSocioVinculo.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioVinculo input = (Data.TituloSocioVinculo)parametros["Key"];
            Tables.TituloSocioVinculo bd = (Tables.TituloSocioVinculo)this.m_EntityManager.find
            (
                typeof(Tables.TituloSocioVinculo),
                new Object[]
                {
                    input.idTituloSocioVinculo
                }
            );

            if (input.tituloSocio != null && input.tituloSocio.idTituloSocio > 0)
                bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            else { }
            if (input.tituloSocioVinculado != null && input.tituloSocioVinculado.idTituloSocio > 0)
                bd.tituloSocioVinculado.idTituloSocio.value = input.tituloSocioVinculado.idTituloSocio;
            else { }

            if (input.dataInicio.Ticks > 0)
                bd.dataInicio.value = input.dataInicio;
            else
            {
                bd.dataInicio.value = DateTime.Now;
            }

            if (input.dataFim.Ticks > 0)
                bd.dataFim.value = input.dataFim;
            else { }

            if (input.vinculo != null && input.vinculo.idVinculo > 0)
                bd.vinculo.idVinculo.value = input.vinculo.idVinculo;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.TituloSocioVinculo bd = new Tables.TituloSocioVinculo();

            bd.idTituloSocioVinculo.value = ((Data.TituloSocioVinculo)parametros["Key"]).idTituloSocioVinculo;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.TituloSocioVinculo)bd).idTituloSocioVinculo.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.TituloSocioVinculo)input).operacao = ENum.eOperacao.NONE;

                    ((Data.TituloSocioVinculo)input).idTituloSocioVinculo = ((Tables.TituloSocioVinculo)bd).idTituloSocioVinculo.value;
                    ((Data.TituloSocioVinculo)input).tituloSocio = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.TituloSocioVinculo)bd).tituloSocio,
                        level + 1
                    );

                    ((Data.TituloSocioVinculo)input).tituloSocioVinculado = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.TituloSocioVinculo)bd).tituloSocioVinculado,
                        level + 1
                    );

                    ((Data.TituloSocioVinculo)input).dataInicio = ((Tables.TituloSocioVinculo)bd).dataInicio.value;
                    ((Data.TituloSocioVinculo)input).dataFim = ((Tables.TituloSocioVinculo)bd).dataFim.value;
                    ((Data.TituloSocioVinculo)input).vinculo = (Data.Vinculo)(new WS.CRUD.Vinculo(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Vinculo(),
                        ((Tables.TituloSocioVinculo)bd).vinculo,
                        level + 1
                    );

                    if (((Tables.TituloSocioVinculo)bd).dataFim.value.Ticks > 0)
                        ((Data.TituloSocioVinculo)input).status = Data.TituloSocioVinculo.Status.Inativo;
                    else
                        ((Data.TituloSocioVinculo)input).status = Data.TituloSocioVinculo.Status.Ativo;

                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.TituloSocioVinculo result = (Data.TituloSocioVinculo)parametros["Key"];

            try
            {
                result = (Data.TituloSocioVinculo)this.preencher
                (
                    new Data.TituloSocioVinculo(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.TituloSocioVinculo),
                        new Object[]
                        {
                            result.idTituloSocioVinculo
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

            Data.TituloSocioVinculo _input = (Data.TituloSocioVinculo)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idTituloSocioVinculo > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.idTituloSocioVinculo = @idTituloSocioVinculo");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocioVinculo", _input.idTituloSocioVinculo));
                    if (!sqlOrderBy.Contains("tituloSocioVinculo.idTituloSocioVinculo"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioVinculo.idTituloSocioVinculo");
                    else { }
                }
                else { }

                if (_input.tituloSocio != null)
                {
                    if (_input.tituloSocio.idTituloSocio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.idTituloSocio = @idTituloSocio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocio", _input.tituloSocio.idTituloSocio));
                        if (!sqlOrderBy.Contains("tituloSocioVinculo.idTituloSocio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioVinculo.idTituloSocio");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.tituloSocioVinculado != null)
                {
                    if (_input.tituloSocioVinculado.idTituloSocio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.idTituloSocioVinculado = @idTituloSocioVinculado");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocioVinculado", _input.tituloSocioVinculado.idTituloSocio));
                        if (!sqlOrderBy.Contains("tituloSocioVinculo.idTituloSocioVinculado"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioVinculo.idTituloSocioVinculado");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.vinculo != null)
                {
                    if (_input.vinculo.idVinculo > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.idVinculo = @idVinculo");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idVinculo", _input.vinculo.idVinculo));
                        if (!sqlOrderBy.Contains("tituloSocioVinculo.idVinculo"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocioVinculo.idVinculo");
                        else { }
                    }
                    else { }
                }

                switch (_input.status)
                {
                    case Data.TituloSocioVinculo.Status.Ativo:
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.dataFim IS NULL");
                            break;
                        }
                    case Data.TituloSocioVinculo.Status.Inativo:
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "tituloSocioVinculo.dataFim IS NOT NULL");
                            break;
                        }
                }


                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   * " +
                    "from " +
                    @"  tituloSocioVinculo
		                inner join tituloSocio
			                on	tituloSocio.idTituloSocio = tituloSocioVinculo.idTituloSocio
		                inner join tituloSocio tituloSocioVinculado
			                on	tituloSocioVinculado.idTituloSocio = tituloSocioVinculo.idTituloSocioVinculado
		                inner join vinculo
			                on	vinculo.idVinculo = tituloSocioVinculo.idVinculo" +
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
            Data.TituloSocioVinculo input = (Data.TituloSocioVinculo)parametros["Key"];
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
                    typeof(Tables.TituloSocioVinculo),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.TituloSocioVinculo _data in
                    (System.Collections.Generic.List<Tables.TituloSocioVinculo>)this.m_EntityManager.list
                    (
                        typeof(Tables.TituloSocioVinculo),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.TituloSocioVinculo(), _data, level);

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
