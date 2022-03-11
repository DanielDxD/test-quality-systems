using System;

namespace WS.CRUD
{
    public class EventoInscricao: WS.CRUD.Base
    {
        public EventoInscricao(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.EventoInscricao input = (Data.EventoInscricao)parametros["Key"];
            Tables.EventoInscricao bd = new Tables.EventoInscricao();

            bd.idEventoInscricao.isNull = true;
            bd.dataInscricao.value = input.dataInscricao;
            if (bd.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamento.idEmpresaRelacionamento.isNull = true;
            if (bd.evento != null)
                bd.evento.idEvento.value = input.evento.idEvento;
            else
                bd.evento.idEvento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.EventoInscricao)parametros["Key"]).idEventoInscricao = (int)bd.idEventoInscricao.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.EventoInscricao input = (Data.EventoInscricao)parametros["Key"];
            Tables.EventoInscricao bd = (Tables.EventoInscricao)this.m_EntityManager.find
            (
                typeof(Tables.EventoInscricao),
                new Object[]
                {
                    input.idEventoInscricao
                }
            );

            bd.dataInscricao.value = input.dataInscricao;
            if (bd.empresaRelacionamento != null)
                bd.empresaRelacionamento.idEmpresaRelacionamento.value = input.empresaRelacionamento.idEmpresaRelacionamento;
            else
                bd.empresaRelacionamento.idEmpresaRelacionamento.isNull = true;
            if (bd.evento != null)
                bd.evento.idEvento.value = input.evento.idEvento;
            else
                bd.evento.idEvento.isNull = true;

            this.m_EntityManager.merge(bd);

            
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.EventoInscricao bd = new Tables.EventoInscricao();

            bd.idEventoInscricao.value = ((Data.EventoInscricao)parametros["Key"]).idEventoInscricao;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.EventoInscricao)bd).idEventoInscricao.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.EventoInscricao)input).operacao = ENum.eOperacao.NONE;

                    ((Data.EventoInscricao)input).idEventoInscricao = ((Tables.EventoInscricao)bd).idEventoInscricao.value;
                    ((Data.EventoInscricao)input).dataInscricao = ((Tables.EventoInscricao)bd).dataInscricao.value;
                    ((Data.EventoInscricao)input).empresaRelacionamento = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.EventoInscricao)bd).empresaRelacionamento,
                        level + 1
                    );
                    ((Data.EventoInscricao)input).evento = (Data.Evento)(new WS.CRUD.Evento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Evento(),
                        ((Tables.EventoInscricao)bd).evento,
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
            Data.EventoInscricao result = (Data.EventoInscricao)parametros["Key"];

            try
            {
                result = (Data.EventoInscricao)this.preencher
                (
                    new Data.EventoInscricao(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.EventoInscricao),
                        new Object[]
                        {
                            result.idEventoInscricao
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

            Boolean onlyCount = false;

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

                if (_params.ContainsKey("onlyCount"))
                    onlyCount = (Boolean)_params["onlyCount"];
                else { }
            }
            else { }

            Data.EventoInscricao _input = (Data.EventoInscricao)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;
            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idEventoInscricao > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricao.idEventoInscricao = @idEventoInscricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEventoInscricao", _input.idEventoInscricao));
                    if (!sqlOrderBy.Contains("EventoInscricao.idEventoInscricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricao.idEventoInscricao");
                    else { }
                }
                else { }

                if (_input.evento != null && _input.evento.idEvento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricao.idEvento = @idEvento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEvento", _input.evento.idEvento));
                    if (!sqlOrderBy.Contains("EventoInscricao.idEvento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricao.idEvento");
                    else { }
                }
                else { }

                if (_input.empresaRelacionamento != null && _input.empresaRelacionamento.idEmpresaRelacionamento > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "EventoInscricao.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.empresaRelacionamento.idEmpresaRelacionamento));
                    if (!sqlOrderBy.Contains("EventoInscricao.idEmpresaRelacionamento"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "EventoInscricao.idEmpresaRelacionamento");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "EventoInscricao.* ") +
                    "from " +
                    (
                        "   EventoInscricao EventoInscricao \n"
                    ) +
                    @"inner join empresaRelacionamento 
                        ON empresaRelacionamento.idEmpresaRelacionamento = eventoInscricao.idEmpresaRelacionamento
                      inner join pessoa
                        on pessoa.idPessoa = empresaRelacionamento.idPessoaRelacionamento " +
                    (sqlWhere.Length > 0 ? " where " + sqlWhere : "") +
                    (onlyCount ? "" :
                        (sqlOrderBy.Length > 0 ? " order by " + sqlOrderBy : "") +
                        (((numRows > 0) && (offSet >= 0)) ? " offset " + offSet + " rows fetch next " + numRows + " rows only" : "")
                    ));

                table = null;
            }
            else { }

            return result;
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.EventoInscricao input = (Data.EventoInscricao)parametros["Key"];
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
                    typeof(Tables.EventoInscricao),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );
                
                parametros.Clear();
                parametros = null;

                foreach
                (
                    Tables.EventoInscricao _data in
                    (System.Collections.Generic.List<Tables.EventoInscricao>)this.m_EntityManager.list
                    (
                        typeof(Tables.EventoInscricao),
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
                        //        _data.descricao.value + "(" + _data.codConsCampo.idCadastro.nome.value + ")"
                        //    );
                        //}
                        //else
                        //{
                        //    ((Data.ResultadoConsulta)_base).codigo = (int)_data.codCarteira.value;
                        //    ((Data.ResultadoConsulta)_base).descricao = _data.descricao.value;
                        //}
                    //}
                    //else
                        _base = (Data.Base)this.preencher(new Data.EventoInscricao(), _data, level);

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
