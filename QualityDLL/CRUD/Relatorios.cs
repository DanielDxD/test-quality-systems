using System;

namespace WS.CRUD
{
    public class Relatorios : WS.CRUD.Base
    {
        public Relatorios(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Relatorios input = (Data.Relatorios)parametros["Key"];
            Tables.Relatorios bd = new Tables.Relatorios();

            bd.idRelatorio.value = (int)System.Convert.ChangeType
            (
                this.m_EntityManager.executeScalar
                (
                    (
                        "select\n" +
                        "   IsNull(Max(idRelatorio) + 1, 0)\n" +
                        "from \n" + 
                        "   relatorios\n" +
                        "where\n" +
                        "   tipo = @tipo"
                    ),
                    new EJB.TableBase.TField[] { new EJB.TableBase.TFieldString("tipo", input.tipo) }
                ),
                typeof(int)
            );

            bd.tipo.value = input.tipo;

            if (bd.idRelatorio.value == 0)
                if (bd.tipo.value == "S")
                    bd.idRelatorio.value = 1;
                else
                    bd.idRelatorio.value = 1000;
            else { }

            bd.descricao.value = input.descricao;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.colunas.value = input.colunas;
            bd.paginas.value = input.paginas;
            bd.margemTopo.value = input.margemTopo;
            bd.margemRodape.value = input.margemRodape;
            bd.margemEsquerda.value = input.margemEsquerda;
            bd.margemDireita.value = input.margemDireita;
            bd.fonteNome.value = input.fonteNome;
            bd.fonteTamanho.value = input.fonteTamanho;
            bd.classeBase.value = input.classeBase;
            bd.condicao.value = input.condicao;

            this.m_EntityManager.persist(bd);

            ((Data.Relatorios)parametros["Key"]).idRelatorio = (int)bd.idRelatorio.value;

            WS.CRUD.RelatorioBandas relatorioBandasCRUD = new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager);
            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            //Processa Relatorio Cabecalho
            if (input.cabecalho != null)
            {
                input.cabecalho.idRelatorio = bd.idRelatorio.value;
                input.cabecalho.tipo = "C";
                _parameters.Add("Key", input.cabecalho);
                relatorioBandasCRUD.incluir(_parameters);
                _parameters.Clear();
            }
            else { }

            //Processa Grupo Cabecalho
            if (input.grupoCabecalhos != null)
            {
                for (int i = 0; i < input.grupoCabecalhos.Length; i++)
                {
                    input.grupoCabecalhos[i].idRelatorio = bd.idRelatorio.value;
                    input.grupoCabecalhos[i].tipo = "GC";
                    _parameters.Add("Key", input.grupoCabecalhos[i]);
                    relatorioBandasCRUD.incluir(_parameters);
                    _parameters.Clear();
                }
            }
            else { }

            //Processa Detalhes
            if (input.detalhe != null)
            {
                input.detalhe.idRelatorio = bd.idRelatorio.value;
                input.detalhe.tipo = "D";
                _parameters.Add("Key", input.detalhe);
                relatorioBandasCRUD.incluir(_parameters);
                _parameters.Clear();
            }
            else { }

            //Processa Grupo Rodapé
            if (input.grupoRodapes != null)
            {
                for (int i = 0; i < input.grupoRodapes.Length; i++)
                {
                    input.grupoRodapes[i].idRelatorio = bd.idRelatorio.value;
                    input.grupoRodapes[i].tipo = "GR";
                    _parameters.Add("Key", input.grupoRodapes[i]);
                    relatorioBandasCRUD.incluir(_parameters);
                    _parameters.Clear();
                }
            }
            else { }

            //Processa Relatorio Rodapé
            if (input.rodape != null)
            {
                input.rodape.idRelatorio = bd.idRelatorio.value;
                input.rodape.tipo = "R";
                _parameters.Add("Key", input.rodape);
                relatorioBandasCRUD.incluir(_parameters);
                _parameters.Clear();
            }
            else { }

            relatorioBandasCRUD = null;
            _parameters = null;

            return input; // this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Relatorios input = (Data.Relatorios)parametros["Key"];
            Tables.Relatorios bd = (Tables.Relatorios)this.m_EntityManager.find
            (
                typeof(Tables.Relatorios),
                new Object[]
                {
                    input.idRelatorio
                }
            );

            bd.descricao.value = input.descricao;
            bd.largura.value = input.largura;
            bd.altura.value = input.altura;
            bd.colunas.value = input.colunas;
            bd.paginas.value = input.paginas;
            bd.margemTopo.value = input.margemTopo;
            bd.margemRodape.value = input.margemRodape;
            bd.margemEsquerda.value = input.margemEsquerda;
            bd.margemDireita.value = input.margemDireita;
            bd.fonteNome.value = input.fonteNome;
            bd.fonteTamanho.value = input.fonteTamanho;
            bd.classeBase.value = input.classeBase;
            //bd.tipo.value = input.tipo;
            bd.condicao.value = input.condicao;

            this.m_EntityManager.merge(bd);

            WS.CRUD.RelatorioBandas relatorioBandasCRUD = new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager);
            System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

            //Processa Relatorio Cabecalho
            if (input.cabecalho != null)
            {
                input.cabecalho.idRelatorio = bd.idRelatorio.value;
                input.cabecalho.tipo = "C";
                _parameters.Add("Key", input.cabecalho);
                relatorioBandasCRUD.atualizar(_parameters);
                _parameters.Clear();
            }
            else { }

            //Processa Grupo Cabecalho
            if (input.grupoCabecalhos != null)
            {
                for (int i = 0; i < input.grupoCabecalhos.Length; i++)
                {
                    input.grupoCabecalhos[i].idRelatorio = bd.idRelatorio.value;
                    input.grupoCabecalhos[i].tipo = "GC";
                    _parameters.Add("Key", input.grupoCabecalhos[i]);
                    relatorioBandasCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }
            }
            else { }

            //Processa Detalhes
            if (input.detalhe != null)
            {
                input.detalhe.idRelatorio = bd.idRelatorio.value;
                input.detalhe.tipo = "D";
                _parameters.Add("Key", input.detalhe);
                relatorioBandasCRUD.atualizar(_parameters);
                _parameters.Clear();
            }
            else { }

            //Processa Grupo Rodapé
            if (input.grupoRodapes != null)
            {
                for (int i = 0; i < input.grupoRodapes.Length; i++)
                {
                    input.grupoRodapes[i].idRelatorio = bd.idRelatorio.value;
                    input.grupoRodapes[i].tipo = "GR";
                    _parameters.Add("Key", input.grupoRodapes[i]);
                    relatorioBandasCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }
            }
            else { }

            //Processa Relatorio Rodapé
            if (input.rodape != null)
            {
                input.rodape.idRelatorio = bd.idRelatorio.value;
                input.rodape.tipo = "R";
                _parameters.Add("Key", input.rodape);
                relatorioBandasCRUD.atualizar(_parameters);
                _parameters.Clear();
            }
            else { }

            relatorioBandasCRUD = null;
            _parameters = null;

            return input; // this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Relatorios bd = new Tables.Relatorios();

            bd.idRelatorio.value = ((Data.Relatorios)parametros["Key"]).idRelatorio;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Relatorios)bd).idRelatorio.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Relatorios)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Relatorios)input).idRelatorio = ((Tables.Relatorios)bd).idRelatorio.value;
                    ((Data.Relatorios)input).descricao = ((Tables.Relatorios)bd).descricao.value;
                    ((Data.Relatorios)input).largura = ((Tables.Relatorios)bd).largura.value;
                    ((Data.Relatorios)input).altura = ((Tables.Relatorios)bd).altura.value;
                    ((Data.Relatorios)input).colunas = ((Tables.Relatorios)bd).colunas.value;
                    ((Data.Relatorios)input).paginas = ((Tables.Relatorios)bd).paginas.value;
                    ((Data.Relatorios)input).margemTopo = ((Tables.Relatorios)bd).margemTopo.value;
                    ((Data.Relatorios)input).margemRodape = ((Tables.Relatorios)bd).margemRodape.value;
                    ((Data.Relatorios)input).margemEsquerda = ((Tables.Relatorios)bd).margemEsquerda.value;
                    ((Data.Relatorios)input).margemDireita = ((Tables.Relatorios)bd).margemDireita.value;
                    ((Data.Relatorios)input).fonteNome = ((Tables.Relatorios)bd).fonteNome.value;
                    ((Data.Relatorios)input).fonteTamanho = ((Tables.Relatorios)bd).fonteTamanho.value;
                    ((Data.Relatorios)input).classeBase = ((Tables.Relatorios)bd).classeBase.value;
                    ((Data.Relatorios)input).tipo = ((Tables.Relatorios)bd).tipo.value;
                    ((Data.Relatorios)input).condicao = ((Tables.Relatorios)bd).condicao.value;
                }
                else { }
            }
            else { }

            //Preencher RelatorioBandass
            if (((Tables.Relatorios)bd).relatorioBandass != null)
            {
                System.Collections.Generic.List<Data.RelatorioBandas>
                    _listGC = new System.Collections.Generic.List<Data.RelatorioBandas>(),
                    _listGR = new System.Collections.Generic.List<Data.RelatorioBandas>();

                foreach (Tables.RelatorioBandas _item in ((Tables.Relatorios)bd).relatorioBandass)
                {
                    Data.RelatorioBandas banda =
                    (
                        (Data.RelatorioBandas)
                        (new WS.CRUD.RelatorioBandas(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.RelatorioBandas(),
                            _item,
                            level + 1
                        )
                    );

                    if (banda != null)
                    {
                        switch (banda.tipo)
                        {
                            case "C":
                                ((Data.Relatorios)input).cabecalho = banda;
                                break;

                            case "D":
                                ((Data.Relatorios)input).detalhe = banda;
                                break;

                            case "R":
                                ((Data.Relatorios)input).rodape = banda;
                                break;

                            case "GC":
                                _listGC.Add(banda);
                                break;

                            case "GR":
                                _listGR.Add(banda);
                                break;

                            default:
                                break;
                        }
                    }
                    else { }
                }

                _listGC.Sort((x, y) => x.nome.CompareTo(y.nome));
                _listGR.Sort((x, y) => x.nome.CompareTo(y.nome));

                ((Data.Relatorios)input).grupoCabecalhos = _listGC.ToArray();
                ((Data.Relatorios)input).grupoRodapes = _listGR.ToArray();
                _listGC.Clear();
                _listGR.Clear();
                _listGC = null;
                _listGR = null;
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.Relatorios result = (Data.Relatorios)parametros["Key"];

            try
            {
                result = (Data.Relatorios)this.preencher
                (
                    new Data.Relatorios(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Relatorios),
                        new Object[]
                        {
                            result.idRelatorio
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
            Data.Relatorios input = (Data.Relatorios)parametros["Key"];
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
                    typeof(Tables.Relatorios),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Relatorios _data in
                    (System.Collections.Generic.List<Tables.Relatorios>)this.m_EntityManager.list
                    (
                        typeof(Tables.Relatorios),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = null;

                    if (mode == "Roll")
                    {
                        _base = new Data.Relatorios();
                        ((Data.Relatorios)_base).idRelatorio = _data.idRelatorio.value;
                        ((Data.Relatorios)_base).descricao = _data.descricao.value;
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Relatorios(), _data, level);

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
