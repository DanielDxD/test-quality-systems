using System;

namespace WS.CRUD
{
    public class ModalidadeEsportiva : WS.CRUD.Base
    {
        public ModalidadeEsportiva(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportiva input = (Data.ModalidadeEsportiva)parametros["Key"];
            Tables.ModalidadeEsportiva bd = new Tables.ModalidadeEsportiva();

            bd.idModalidadeEsportiva.isNull = true;
            bd.descricao.value = input.descricao;
            bd.idadeMinima.value = input.idadeMinima;
            bd.idadeMaxima.value = input.idadeMaxima;
            bd.situacao.value = input.situacao;

            this.m_EntityManager.persist(bd);

            ((Data.ModalidadeEsportiva)parametros["Key"]).idModalidadeEsportiva = (int)bd.idModalidadeEsportiva.value;

            if (input.turmas != null)
            {
                WS.CRUD.ModalidadeEsportivaTurma turmasCRUD = new WS.CRUD.ModalidadeEsportivaTurma(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.turmas.Length; i++)
                {
                    input.turmas[i].modalidadeEsportiva = new Data.ModalidadeEsportiva { idModalidadeEsportiva = bd.idModalidadeEsportiva.value };
                    _parameters.Add("Key", input.turmas[i]);
                    turmasCRUD.atualizar(_parameters);
                    if (input.turmas[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.turmas[i] = (Data.ModalidadeEsportivaTurma)turmasCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                turmasCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportiva input = (Data.ModalidadeEsportiva)parametros["Key"];
            Tables.ModalidadeEsportiva bd = (Tables.ModalidadeEsportiva)this.m_EntityManager.find
            (
                typeof(Tables.ModalidadeEsportiva),
                new Object[]
                {
                    input.idModalidadeEsportiva
                }
            );

            bd.descricao.value = input.descricao;
            bd.idadeMinima.value = input.idadeMinima;
            bd.idadeMaxima.value = input.idadeMaxima;
            bd.situacao.value = input.situacao;

            this.m_EntityManager.merge(bd);

            if (input.turmas != null)
            {
                WS.CRUD.ModalidadeEsportivaTurma turmasCRUD = new WS.CRUD.ModalidadeEsportivaTurma(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.turmas.Length; i++)
                {
                    input.turmas[i].modalidadeEsportiva = new Data.ModalidadeEsportiva { idModalidadeEsportiva = bd.idModalidadeEsportiva.value };
                    _parameters.Add("Key", input.turmas[i]);
                    if (input.turmas[i].operacao != ENum.eOperacao.NONE)
                        input.turmas[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    turmasCRUD.atualizar(_parameters);
                    if (input.turmas[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.turmas[i] = (Data.ModalidadeEsportivaTurma)turmasCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                turmasCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ModalidadeEsportiva bd = new Tables.ModalidadeEsportiva();

            bd.idModalidadeEsportiva.value = ((Data.ModalidadeEsportiva)parametros["Key"]).idModalidadeEsportiva;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ModalidadeEsportiva)bd).idModalidadeEsportiva.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ModalidadeEsportiva)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ModalidadeEsportiva)input).idModalidadeEsportiva = ((Tables.ModalidadeEsportiva)bd).idModalidadeEsportiva.value;
                    ((Data.ModalidadeEsportiva)input).descricao = ((Tables.ModalidadeEsportiva)bd).descricao.value;
                    ((Data.ModalidadeEsportiva)input).idadeMinima = ((Tables.ModalidadeEsportiva)bd).idadeMinima.value;
                    ((Data.ModalidadeEsportiva)input).idadeMaxima = ((Tables.ModalidadeEsportiva)bd).idadeMaxima.value;
                    ((Data.ModalidadeEsportiva)input).situacao = ((Tables.ModalidadeEsportiva)bd).situacao.value;
                    ((Data.ModalidadeEsportiva)input).situacaoView = ((Tables.ModalidadeEsportiva)bd).situacao.value == "at" ? "Ativo" : "Bloqueado";

                    //Preencher ModalidadeEsportivaTurmas
                    if (((Tables.ModalidadeEsportiva)bd).turmas != null)
                    {
                        System.Collections.Generic.List<Data.ModalidadeEsportivaTurma> _list = new System.Collections.Generic.List<Data.ModalidadeEsportivaTurma>();

                        foreach (Tables.ModalidadeEsportivaTurma _item in ((Tables.ModalidadeEsportiva)bd).turmas)
                        {
                            _list.Add
                            (
                                (Data.ModalidadeEsportivaTurma)
                                (new WS.CRUD.ModalidadeEsportivaTurma(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ModalidadeEsportivaTurma(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ModalidadeEsportiva)input).turmas = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ModalidadeEsportiva)input).turmas != null)
                        {
                            System.Collections.Generic.List<Data.ModalidadeEsportivaTurma> _list = new System.Collections.Generic.List<Data.ModalidadeEsportivaTurma>();

                            foreach (Data.ModalidadeEsportivaTurma _item in ((Data.ModalidadeEsportiva)input).turmas)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ModalidadeEsportiva)input).turmas = _list.ToArray();
                            else
                                ((Data.ModalidadeEsportiva)input).turmas = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportiva result = (Data.ModalidadeEsportiva)parametros["Key"];

            try
            {
                result = (Data.ModalidadeEsportiva)this.preencher
                (
                    new Data.ModalidadeEsportiva(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ModalidadeEsportiva),
                        new Object[]
                        {
                            result.idModalidadeEsportiva
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

            bool
                onlyCount = false;

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
                    onlyCount = (bool)_params["onlyCount"];
                else { }
            }
            else { }

            Data.ModalidadeEsportiva _input = (Data.ModalidadeEsportiva)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {

                if (_input.idModalidadeEsportiva > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "modalidadeEsportiva.idModalidadeEsportiva = @idModalidadeEsportiva");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportiva", _input.idModalidadeEsportiva));
                    if (!sqlOrderBy.Contains("modalidadeEsportiva.idModalidadeEsportiva"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "modalidadeEsportiva.idModalidadeEsportiva");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.descricao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   modalidadeEsportiva.descricao like @descricao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", _input.descricao + "%"));
                    if (!sqlOrderBy.Contains("modalidadeEsportiva.descricao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "modalidadeEsportiva.descricao");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.situacao))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   modalidadeEsportiva.situacao = @situacao");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("situacao", _input.situacao));
                    if (!sqlOrderBy.Contains("modalidadeEsportiva.situacao"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "modalidadeEsportiva.situacao");
                    else { }
                }
                else { }

                if (_input.idadeMinima > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   modalidadeEsportiva.idadeMinima >= @idadeMinima");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idadeMinima", _input.idadeMinima));
                    if (!sqlOrderBy.Contains("modalidadeEsportiva.idadeMinima"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "modalidadeEsportiva.idadeMinima");
                    else { }
                }
                else { }

                if (_input.idadeMaxima > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   modalidadeEsportiva.idadeMaxima <= @idadeMaxima");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idadeMaxima", _input.idadeMaxima));
                    if (!sqlOrderBy.Contains("modalidadeEsportiva.idadeMaxima"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "modalidadeEsportiva.idadeMaxima");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "modalidadeEsportiva.* ") +
                    "from \n" + 
                    "   modalidadeEsportiva\n" +
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
            Data.ModalidadeEsportiva input = (Data.ModalidadeEsportiva)parametros["Key"];
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
                    typeof(Tables.ModalidadeEsportiva),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ModalidadeEsportiva _data in
                    (System.Collections.Generic.List<Tables.ModalidadeEsportiva>)this.m_EntityManager.list
                    (
                        typeof(Tables.ModalidadeEsportiva),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.ModalidadeEsportiva();
                        ((Data.ModalidadeEsportiva)_base).idModalidadeEsportiva = _data.idModalidadeEsportiva.value;
                        ((Data.ModalidadeEsportiva)_base).descricao = _data.descricao.value;
                        ((Data.ModalidadeEsportiva)_base).idadeMinima = _data.idadeMinima.value;
                        ((Data.ModalidadeEsportiva)_base).idadeMaxima = _data.idadeMaxima.value;
                        ((Data.ModalidadeEsportiva)_base).situacao = _data.situacao.value;
                        ((Data.ModalidadeEsportiva)_base).situacaoView = _data.situacao.value == "at" ? "Ativo" : "Bloqueado";
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.ModalidadeEsportiva(), _data, level);


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
