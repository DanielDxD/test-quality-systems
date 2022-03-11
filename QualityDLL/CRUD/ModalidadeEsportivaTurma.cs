using System;
using System.Linq;

namespace WS.CRUD
{
    public class ModalidadeEsportivaTurma : WS.CRUD.Base
    {
        public ModalidadeEsportivaTurma(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportivaTurma input = (Data.ModalidadeEsportivaTurma)parametros["Key"];
            Tables.ModalidadeEsportivaTurma bd = new Tables.ModalidadeEsportivaTurma();

            bd.idModalidadeEsportivaTurma.isNull = true;
            bd.modalidadeEsportiva.idModalidadeEsportiva.value = input.modalidadeEsportiva.idModalidadeEsportiva;
            bd.horarioInicial.value = input.horarioInicial;
            bd.horarioFinal.value = input.horarioFinal;
            bd.toleranciaInicial.value = input.toleranciaInicial;
            bd.toleranciaFinal.value = input.toleranciaFinal;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.limiteAlunos.value = input.limiteAlunos;
            bd.nivelTurma.value = input.nivelTurma;
            bd.observacoes.value = input.observacoes;
            bd.tipoControleFrequencia.value = input.tipoControleFrequencia;
            bd.qtdLimite.value = input.qtdLimite;
            bd.domingo.value = input.domingo;
            bd.segunda.value = input.segunda;
            bd.terca.value = input.terca;
            bd.quarta.value = input.quarta;
            bd.quinta.value = input.quinta;
            bd.sexta.value = input.sexta;
            bd.sabado.value = input.sabado;
            bd.naturezaOperacaoMatricula.idNaturezaOperacao.value = input.naturezaOperacaoMatricula.idNaturezaOperacao;
            bd.valorMatriculaSocio.value = input.valorMatriculaSocio;
            bd.valorMatriculaNaoSocio.value = input.valorMatriculaNaoSocio;
            bd.situacao.value = input.situacao;

            this.m_EntityManager.persist(bd);

            ((Data.ModalidadeEsportivaTurma)parametros["Key"]).idModalidadeEsportivaTurma = (int)bd.idModalidadeEsportivaTurma.value;

            if (input.valores != null)
            {
                WS.CRUD.ModalidadeEsportivaTurmaValor valoresCRUD = new WS.CRUD.ModalidadeEsportivaTurmaValor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.valores.Length; i++)
                {
                    input.valores[i].modalidadeEsportivaTurma = new Data.ModalidadeEsportivaTurma { idModalidadeEsportivaTurma = bd.idModalidadeEsportivaTurma.value };
                    _parameters.Add("Key", input.valores[i]);
                    valoresCRUD.atualizar(_parameters);
                    if (input.valores[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.valores[i] = (Data.ModalidadeEsportivaTurmaValor)valoresCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                valoresCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.ModalidadeEsportivaTurma input = (Data.ModalidadeEsportivaTurma)parametros["Key"];
            Tables.ModalidadeEsportivaTurma bd = (Tables.ModalidadeEsportivaTurma)this.m_EntityManager.find
            (
                typeof(Tables.ModalidadeEsportivaTurma),
                new Object[]
                {
                    input.idModalidadeEsportivaTurma
                }
            );

            bd.modalidadeEsportiva.idModalidadeEsportiva.value = input.modalidadeEsportiva.idModalidadeEsportiva;
            bd.horarioInicial.value = input.horarioInicial;
            bd.horarioFinal.value = input.horarioFinal;
            bd.toleranciaInicial.value = input.toleranciaInicial;
            bd.toleranciaFinal.value = input.toleranciaFinal;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.limiteAlunos.value = input.limiteAlunos;
            bd.nivelTurma.value = input.nivelTurma;
            bd.observacoes.value = input.observacoes;
            bd.tipoControleFrequencia.value = input.tipoControleFrequencia;
            bd.qtdLimite.value = input.qtdLimite;
            bd.domingo.value = input.domingo;
            bd.segunda.value = input.segunda;
            bd.terca.value = input.terca;
            bd.quarta.value = input.quarta;
            bd.quinta.value = input.quinta;
            bd.sexta.value = input.sexta;
            bd.sabado.value = input.sabado;
            bd.naturezaOperacaoMatricula.idNaturezaOperacao.value = input.naturezaOperacaoMatricula.idNaturezaOperacao;
            bd.valorMatriculaSocio.value = input.valorMatriculaSocio;
            bd.valorMatriculaNaoSocio.value = input.valorMatriculaNaoSocio;
            bd.situacao.value = input.situacao;

            this.m_EntityManager.merge(bd);

            if (input.valores != null)
            {
                WS.CRUD.ModalidadeEsportivaTurmaValor valoresCRUD = new WS.CRUD.ModalidadeEsportivaTurmaValor(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.valores.Length; i++)
                {
                    input.valores[i].modalidadeEsportivaTurma = new Data.ModalidadeEsportivaTurma { idModalidadeEsportivaTurma = bd.idModalidadeEsportivaTurma.value };
                    _parameters.Add("Key", input.valores[i]);
                    if (input.valores[i].operacao == ENum.eOperacao.NONE)
                        input.valores[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    valoresCRUD.atualizar(_parameters);
                    if (input.valores[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.valores[i] = (Data.ModalidadeEsportivaTurmaValor)valoresCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                _parameters = null;
                valoresCRUD = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.ModalidadeEsportivaTurma bd = new Tables.ModalidadeEsportivaTurma();

            bd.idModalidadeEsportivaTurma.value = ((Data.ModalidadeEsportivaTurma)parametros["Key"]).idModalidadeEsportivaTurma;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.ModalidadeEsportivaTurma)bd).idModalidadeEsportivaTurma.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.ModalidadeEsportivaTurma)input).operacao = ENum.eOperacao.NONE;

                    ((Data.ModalidadeEsportivaTurma)input).idModalidadeEsportivaTurma = ((Tables.ModalidadeEsportivaTurma)bd).idModalidadeEsportivaTurma.value;
                    ((Data.ModalidadeEsportivaTurma)input).horarioInicial = ((Tables.ModalidadeEsportivaTurma)bd).horarioInicial.value;
                    ((Data.ModalidadeEsportivaTurma)input).horarioFinal = ((Tables.ModalidadeEsportivaTurma)bd).horarioFinal.value;
                    ((Data.ModalidadeEsportivaTurma)input).toleranciaInicial = ((Tables.ModalidadeEsportivaTurma)bd).toleranciaInicial.value;
                    ((Data.ModalidadeEsportivaTurma)input).toleranciaFinal = ((Tables.ModalidadeEsportivaTurma)bd).toleranciaFinal.value;
                    ((Data.ModalidadeEsportivaTurma)input).limiteAlunos = ((Tables.ModalidadeEsportivaTurma)bd).limiteAlunos.value;
                    ((Data.ModalidadeEsportivaTurma)input).nivelTurma = ((Tables.ModalidadeEsportivaTurma)bd).nivelTurma.value;
                    ((Data.ModalidadeEsportivaTurma)input).observacoes = ((Tables.ModalidadeEsportivaTurma)bd).observacoes.value;
                    ((Data.ModalidadeEsportivaTurma)input).tipoControleFrequencia = ((Tables.ModalidadeEsportivaTurma)bd).tipoControleFrequencia.value;
                    ((Data.ModalidadeEsportivaTurma)input).qtdLimite = ((Tables.ModalidadeEsportivaTurma)bd).qtdLimite.value;
                    ((Data.ModalidadeEsportivaTurma)input).domingo = ((Tables.ModalidadeEsportivaTurma)bd).domingo.value;
                    ((Data.ModalidadeEsportivaTurma)input).segunda = ((Tables.ModalidadeEsportivaTurma)bd).segunda.value;
                    ((Data.ModalidadeEsportivaTurma)input).terca = ((Tables.ModalidadeEsportivaTurma)bd).terca.value;
                    ((Data.ModalidadeEsportivaTurma)input).quarta = ((Tables.ModalidadeEsportivaTurma)bd).quarta.value;
                    ((Data.ModalidadeEsportivaTurma)input).quinta = ((Tables.ModalidadeEsportivaTurma)bd).quinta.value;
                    ((Data.ModalidadeEsportivaTurma)input).sexta = ((Tables.ModalidadeEsportivaTurma)bd).sexta.value;
                    ((Data.ModalidadeEsportivaTurma)input).sabado = ((Tables.ModalidadeEsportivaTurma)bd).sabado.value;
                    ((Data.ModalidadeEsportivaTurma)input).valorMatriculaSocio = ((Tables.ModalidadeEsportivaTurma)bd).valorMatriculaSocio.value;
                    ((Data.ModalidadeEsportivaTurma)input).valorMatriculaNaoSocio = ((Tables.ModalidadeEsportivaTurma)bd).valorMatriculaNaoSocio.value;
                    ((Data.ModalidadeEsportivaTurma)input).situacao = ((Tables.ModalidadeEsportivaTurma)bd).situacao.value;
                    ((Data.ModalidadeEsportivaTurma)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.ModalidadeEsportivaTurma)bd).funcionario,
                        level + 1
                    );
                    ((Data.ModalidadeEsportivaTurma)input).modalidadeEsportiva = (Data.ModalidadeEsportiva)(new WS.CRUD.ModalidadeEsportiva(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ModalidadeEsportiva(),
                        ((Tables.ModalidadeEsportivaTurma)bd).modalidadeEsportiva,
                        level + 1
                    );

                    ((Data.ModalidadeEsportivaTurma)input).naturezaOperacaoMatricula = (Data.NaturezaOperacao)(new WS.CRUD.NaturezaOperacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.NaturezaOperacao(),
                        ((Tables.ModalidadeEsportivaTurma)bd).naturezaOperacaoMatricula,
                        level + 1
                    );

                    //Preencher ModalidadeEsportivaTurmaValores
                    if (((Tables.ModalidadeEsportivaTurma)bd).valores != null)
                    {
                        System.Collections.Generic.List<Data.ModalidadeEsportivaTurmaValor> _list = new System.Collections.Generic.List<Data.ModalidadeEsportivaTurmaValor>();

                        foreach (Tables.ModalidadeEsportivaTurmaValor _item in ((Tables.ModalidadeEsportivaTurma)bd).valores)
                        {
                            _list.Add
                            (
                                (Data.ModalidadeEsportivaTurmaValor)
                                (new WS.CRUD.ModalidadeEsportivaTurmaValor(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                (
                                    new Data.ModalidadeEsportivaTurmaValor(),
                                    _item,
                                    level + 1
                                )
                            );
                        }

                        ((Data.ModalidadeEsportivaTurma)input).valores = _list.ToArray();
                        _list.Clear();
                        _list = null;
                    }
                    else
                    {
                        if (((Data.ModalidadeEsportivaTurma)input).valores != null)
                        {
                            System.Collections.Generic.List<Data.ModalidadeEsportivaTurmaValor> _list = new System.Collections.Generic.List<Data.ModalidadeEsportivaTurmaValor>();

                            foreach (Data.ModalidadeEsportivaTurmaValor _item in ((Data.ModalidadeEsportivaTurma)input).valores)
                            {
                                if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                {
                                    _item.operacao = ENum.eOperacao.NONE;
                                    _list.Add(_item);
                                }
                                else { }
                            }

                            if (_list.Count > 0)
                                ((Data.ModalidadeEsportivaTurma)input).valores = _list.ToArray();
                            else
                                ((Data.ModalidadeEsportivaTurma)input).valores = null;

                            _list.Clear();
                            _list = null;
                        }
                        else { }
                    }

                    ((Data.ModalidadeEsportivaTurma)input).valorSocio = 0;
                    ((Data.ModalidadeEsportivaTurma)input).valorNaoSocio = 0;
                    if (((Data.ModalidadeEsportivaTurma)input).valores != null && ((Data.ModalidadeEsportivaTurma)input).valores.Length > 0)
                        try
                        {
                            ((Data.ModalidadeEsportivaTurma)input).valorSocio = ((Data.ModalidadeEsportivaTurma)input).valores.First(X => X.dataFim.Ticks == 0).valorSocio;
                            ((Data.ModalidadeEsportivaTurma)input).valorNaoSocio = ((Data.ModalidadeEsportivaTurma)input).valores.First(X => X.dataFim.Ticks == 0).valorNaoSocio;
                        }
                        catch
                        {
                            ((Data.ModalidadeEsportivaTurma)input).valorSocio = ((Data.ModalidadeEsportivaTurma)input).valores.LastOrDefault().valorSocio;
                            ((Data.ModalidadeEsportivaTurma)input).valorNaoSocio = ((Data.ModalidadeEsportivaTurma)input).valores.LastOrDefault().valorNaoSocio;
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
            Data.ModalidadeEsportivaTurma result = (Data.ModalidadeEsportivaTurma)parametros["Key"];

            try
            {
                result = (Data.ModalidadeEsportivaTurma)this.preencher
                (
                    new Data.ModalidadeEsportivaTurma(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.ModalidadeEsportivaTurma),
                        new Object[]
                        {
                            result.idModalidadeEsportivaTurma
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

            Data.ModalidadeEsportivaTurma _input = (Data.ModalidadeEsportivaTurma)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idModalidadeEsportivaTurma > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "ModalidadeEsportivaTurma.idModalidadeEsportivaTurma = @idModalidadeEsportivaTurma");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportivaTurma", _input.idModalidadeEsportivaTurma));
                    if (!sqlOrderBy.Contains("ModalidadeEsportivaTurma.idModalidadeEsportivaTurma"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurma.idModalidadeEsportivaTurma");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.observacoes))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ModalidadeEsportivaTurma.observacoes like @observacoes");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("observacoes", _input.observacoes + "%"));
                    if (!sqlOrderBy.Contains("ModalidadeEsportivaTurma.observacoes"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurma.observacoes");
                    else { }
                }
                else { }

                if (_input.funcionario != null)
                {

                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ModalidadeEsportivaTurma.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.funcionario.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("ModalidadeEsportivaTurma.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurma.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.funcionario.tipoRelacionamentoEmpresa != null)
                    {
                        if (_input.funcionario.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa = @idTipoRelacionamentoEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoRelacionamentoEmpresa", _input.funcionario.tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa));
                            if (!sqlOrderBy.Contains("tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa");
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.funcionario.pessoa != null)
                    {
                        if (_input.funcionario.pessoa.idPessoa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.funcionario.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }

                        if (!String.IsNullOrEmpty(_input.funcionario.pessoa.nomeRazaoSocial))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.funcionario.pessoa.nomeRazaoSocial + "%"));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                    }
                    else { }

                }
                else { }

                if (_input.naturezaOperacaoMatricula != null)
                {
                    if (_input.naturezaOperacaoMatricula.idNaturezaOperacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ModalidadeEsportivaTurma.idNaturezaOperacao = @idNaturezaOperacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idNaturezaOperacao", _input.naturezaOperacaoMatricula.idNaturezaOperacao));
                        if (!sqlOrderBy.Contains("ModalidadeEsportivaTurma.idNaturezaOperacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurma.idNaturezaOperacao");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.modalidadeEsportiva != null)
                {
                    if (_input.modalidadeEsportiva.idModalidadeEsportiva > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   ModalidadeEsportivaTurma.idModalidadeEsportiva = @idModalidadeEsportiva");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idModalidadeEsportiva", _input.modalidadeEsportiva.idModalidadeEsportiva));
                        if (!sqlOrderBy.Contains("ModalidadeEsportivaTurma.idModalidadeEsportiva"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "ModalidadeEsportivaTurma.idModalidadeEsportiva");
                        else { }
                    }
                    else { }
                }
                else { }


                result =
                (
                    "select " + (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "") +
                    "   ModalidadeEsportivaTurma.*\n" +
                    "from \n" + 
                    "   ModalidadeEsportivaTurma\n" +
                    "inner join empresaRelacionamento empresaRelacionamento" +
                    "   on empresaRelacionamento.idEmpresaRelacionamento = ModalidadeEsportivaTurma.idFuncionario\n" +
                    "inner join pessoa pessoa" +
                    "   on empresaRelacionamento.idPessoaRelacionamento = pessoa.idPessoa\n" +
                    "inner join tipoRelacionamentoEmpresa tipoRelacionamentoEmpresa" +
                    "   on empresaRelacionamento.idTipoRelacionamentoEmpresa = tipoRelacionamentoEmpresa.idTipoRelacionamentoEmpresa\n" +
                    "inner join naturezaOperacao naturezaOperacao" +
                    "   on naturezaOperacao.idNaturezaOperacao = ModalidadeEsportivaTurma.idNaturezaOperacaoMatricula\n" +
                    "inner join modalidadeEsportiva modalidadeEsportiva" +
                    "   on modalidadeEsportiva.idModalidadeEsportiva = ModalidadeEsportivaTurma.idModalidadeEsportiva\n " +
                    (sqlWhere.Length > 0 ? "where " + sqlWhere : "") + "\n" +
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
            Data.ModalidadeEsportivaTurma input = (Data.ModalidadeEsportivaTurma)parametros["Key"];
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
                    typeof(Tables.ModalidadeEsportivaTurma),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.ModalidadeEsportivaTurma _data in
                    (System.Collections.Generic.List<Tables.ModalidadeEsportivaTurma>)this.m_EntityManager.list
                    (
                        typeof(Tables.ModalidadeEsportivaTurma),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    /*if (mode == "Roll")
                    {
                        _base = new Data.ModalidadeEsportivaTurma();
                        ((Data.ModalidadeEsportivaTurma)_base).idModalidadeEsportivaTurma = _data.idModalidadeEsportivaTurma.value;
                    }
                    else*/
                    _base = (Data.Base)this.preencher(new Data.ModalidadeEsportivaTurma(), _data, level);


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
