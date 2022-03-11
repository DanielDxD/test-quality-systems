using System;

namespace WS.CRUD
{
    public class RelatorioBandas : WS.CRUD.Base
    {
        public RelatorioBandas(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.RelatorioBandas input = (Data.RelatorioBandas)parametros["Key"];
            Tables.RelatorioBandas bd = new Tables.RelatorioBandas();

            bd.idRelatorioBanda.isNull = true;
            bd.idRelatorio.idRelatorio.value = input.idRelatorio;
            bd.nome.value = input.nome;
            bd.tipo.value = input.tipo;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.imagemFundo.value = input.imagemFundo;
            if (input.idRelatorioBandaPai > 0)
                bd.idRelatorioBandaPai.idRelatorioBanda.value = input.idRelatorioBandaPai;
            else { }
            bd.novaPagina.value = input.novaPagina;

            this.m_EntityManager.persist(bd);

            ((Data.RelatorioBandas)parametros["Key"]).idRelatorioBanda = (int)bd.idRelatorioBanda.value;

            //Processa RelatorioBandas
            if (input.relatorioBandass != null)
            {
                WS.CRUD.RelatorioBandas relatorioBandasCRUD = new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.relatorioBandass.Length; i++)
                {
                    input.relatorioBandass[i].idRelatorioBandaPai = bd.idRelatorioBanda.value;
                    _parameters.Add("Key", input.relatorioBandass[i]);
                    relatorioBandasCRUD.incluir(_parameters);
                    _parameters.Clear();
                }

                _parameters = null;
                relatorioBandasCRUD = null;
            }
            else { }

            //Processa RelatorioCampos
            if (input.relatorioCamposs != null)
            {
                WS.CRUD.RelatorioCampos relatorioCamposCRUD = new WS.CRUD.RelatorioCampos(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.relatorioCamposs.Length; i++)
                {
                    input.relatorioCamposs[i].idRelatorioBanda = bd.idRelatorioBanda.value;
                    _parameters.Add("Key", input.relatorioCamposs[i]);
                    relatorioCamposCRUD.incluir(_parameters);
                    _parameters.Clear();
                }

                _parameters = null;
                relatorioCamposCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioBandas input = (Data.RelatorioBandas)parametros["Key"];
            Tables.RelatorioBandas bd = (Tables.RelatorioBandas)this.m_EntityManager.find
            (
                typeof(Tables.RelatorioBandas),
                new Object[]
                {
                    input.idRelatorioBanda
                }
            );

            bd.idRelatorio.idRelatorio.value = input.idRelatorio;
            bd.nome.value = input.nome;
            bd.tipo.value = input.tipo;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.imagemFundo.value = input.imagemFundo;
            if (input.idRelatorioBandaPai > 0)
                bd.idRelatorioBandaPai.idRelatorioBanda.value = input.idRelatorioBandaPai;
            else { }
            bd.novaPagina.value = input.novaPagina;

            this.m_EntityManager.merge(bd);

            //Processa RelatorioBandas
            if (input.relatorioBandass != null)
            {
                WS.CRUD.RelatorioBandas relatorioBandasCRUD = new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.relatorioBandass.Length; i++)
                {
                    input.relatorioBandass[i].idRelatorioBandaPai = bd.idRelatorioBanda.value;
                    _parameters.Add("Key", input.relatorioBandass[i]);
                    relatorioBandasCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                _parameters = null;
                relatorioBandasCRUD = null;
            }
            else { }

            //Processa RelatorioCampos
            if (input.relatorioCamposs != null)
            {
                WS.CRUD.RelatorioCampos relatorioCamposCRUD = new WS.CRUD.RelatorioCampos(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.relatorioCamposs.Length; i++)
                {
                    input.relatorioCamposs[i].idRelatorioBanda = bd.idRelatorioBanda.value;
                    _parameters.Add("Key", input.relatorioCamposs[i]);
                    relatorioCamposCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                _parameters = null;
                relatorioCamposCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.RelatorioBandas bd = new Tables.RelatorioBandas();

            bd.idRelatorioBanda.value = ((Data.RelatorioBandas)parametros["Key"]).idRelatorioBanda;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.RelatorioBandas)bd).idRelatorioBanda.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.RelatorioBandas)input).operacao = ENum.eOperacao.NONE;

                    ((Data.RelatorioBandas)input).idRelatorioBanda = ((Tables.RelatorioBandas)bd).idRelatorioBanda.value;
                    ((Data.RelatorioBandas)input).idRelatorio = ((Tables.RelatorioBandas)bd).idRelatorio.idRelatorio.value;
                    ((Data.RelatorioBandas)input).nome = ((Tables.RelatorioBandas)bd).nome.value;
                    ((Data.RelatorioBandas)input).tipo = ((Tables.RelatorioBandas)bd).tipo.value;
                    ((Data.RelatorioBandas)input).largura = ((Tables.RelatorioBandas)bd).largura.value;
                    ((Data.RelatorioBandas)input).altura = ((Tables.RelatorioBandas)bd).altura.value;
                    ((Data.RelatorioBandas)input).idRelatorioBandaPai = ((Tables.RelatorioBandas)bd).idRelatorioBandaPai.idRelatorioBanda.value;
                    ((Data.RelatorioBandas)input).novaPagina = ((Tables.RelatorioBandas)bd).novaPagina.value;
                    ((Data.RelatorioBandas)input).imagemFundo = ((Tables.RelatorioBandas)bd).imagemFundo.value;
                }
                else { }
            else { }

            //Preencher RelatorioBandass
            if (((Tables.RelatorioBandas)bd).relatorioBandass != null)
            {
                System.Collections.Generic.List<Data.RelatorioBandas> _list = new System.Collections.Generic.List<Data.RelatorioBandas>();

                foreach (Tables.RelatorioBandas _item in ((Tables.RelatorioBandas)bd).relatorioBandass)
                {
                    _list.Add
                    (
                        (Data.RelatorioBandas)
                        (new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.RelatorioBandas(),
                            _item,
                            level + 1
                        )
                    );
                }

                ((Data.RelatorioBandas)input).relatorioBandass = _list.ToArray();
                _list.Clear();
                _list = null;
            }
            else
            {
                if (((Data.RelatorioBandas)input).relatorioBandass != null)
                {
                    System.Collections.Generic.List<Data.RelatorioBandas> _list = new System.Collections.Generic.List<Data.RelatorioBandas>();

                    foreach (Data.RelatorioBandas _item in ((Data.RelatorioBandas)input).relatorioBandass)
                    {
                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                        {
                            _item.operacao = ENum.eOperacao.NONE;
                            _list.Add(_item);
                        }
                        else { }
                    }

                    if (_list.Count > 0)
                        ((Data.RelatorioBandas)input).relatorioBandass = _list.ToArray();
                    else
                        ((Data.RelatorioBandas)input).relatorioBandass = null;

                    _list.Clear();
                    _list = null;
                }
                else { }
            }

            //Preencher RelatorioCamposs
            if (((Tables.RelatorioBandas)bd).relatorioCamposs != null)
            {
                System.Collections.Generic.List<Data.RelatorioCampos> _list = new System.Collections.Generic.List<Data.RelatorioCampos>();

                foreach (Tables.RelatorioCampos _item in ((Tables.RelatorioBandas)bd).relatorioCamposs)
                {
                    _list.Add
                    (
                        (Data.RelatorioCampos)
                        (new WS.CRUD.RelatorioCampos(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.RelatorioCampos(),
                            _item,
                            level + 1
                        )
                    );
                }

                ((Data.RelatorioBandas)input).relatorioCamposs = _list.ToArray();
                _list.Clear();
                _list = null;
            }
            else
            {
                if (((Data.RelatorioBandas)input).relatorioCamposs != null)
                {
                    System.Collections.Generic.List<Data.RelatorioCampos> _list = new System.Collections.Generic.List<Data.RelatorioCampos>();

                    foreach (Data.RelatorioCampos _item in ((Data.RelatorioBandas)input).relatorioCamposs)
                    {
                        if (_item.operacao != ENum.eOperacao.EXCLUIR)
                        {
                            _item.operacao = ENum.eOperacao.NONE;
                            _list.Add(_item);
                        }
                        else { }
                    }

                    if (_list.Count > 0)
                        ((Data.RelatorioBandas)input).relatorioCamposs = _list.ToArray();
                    else
                        ((Data.RelatorioBandas)input).relatorioCamposs = null;

                    _list.Clear();
                    _list = null;
                }
                else { }
            }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioBandas result = (Data.RelatorioBandas)parametros["Key"];

            try
            {
                result = (Data.RelatorioBandas)this.preencher
                (
                    new Data.RelatorioBandas(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.RelatorioBandas),
                        new Object[]
                        {
                            result.idRelatorioBanda
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.RelatorioBandas input = (Data.RelatorioBandas)parametros["Key"];
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
                    typeof(Tables.RelatorioBandas),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.RelatorioBandas _data in
                    (System.Collections.Generic.List<Tables.RelatorioBandas>)this.m_EntityManager.list
                    (
                        typeof(Tables.RelatorioBandas),
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
                    _base = (Data.Base)this.preencher(new Data.RelatorioBandas(), _data, level);

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
