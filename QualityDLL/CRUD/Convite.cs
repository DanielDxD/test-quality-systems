using System;
using System.Linq;

namespace WS.CRUD
{
    public class Convite : WS.CRUD.Base
    {
        public Convite(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Convite input = (Data.Convite)parametros["Key"];
            Tables.Convite bd = new Tables.Convite();

            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.convidado);
                _parametros.Add("Return", bd.convidado);

                input.convidado = (Data.Convidado)(new WS.CRUD.Convidado(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            if (input.contasAReceber != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.contasAReceber);
                _parametros.Add("Return", bd.contasAReceber);

                input.contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }


            bd.idConvite.isNull = true;
            bd.tipoConvite.idTipoConvite.value = input.tipoConvite.idTipoConvite;
            bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.dataCriacaoConvite.value = input.dataCriacaoConvite;
            bd.dataVencimentoInicial.value = input.dataVencimentoInicial;
            bd.dataVencimentoFinal.value = input.dataVencimentoFinal;
            bd.metodoCriacao.value = input.metodoCriacao;
            bd.convidado.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value = input.convidado.idEmpresaRelacionamento;

            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else
                bd.contasAReceber.idContasAReceber.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.Convite)parametros["Key"]).idConvite = (int)bd.idConvite.value;


            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
            {
                WS.CRUD.ContasAReceber contasAReceberCRUD = new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.contasAReceber.contasAReceberItems.Length; i++)
                {
                    input.contasAReceber.operacao = ENum.eOperacao.ALTERAR;
                    input.contasAReceber.contasAReceberItems[i].operacao = ENum.eOperacao.ALTERAR;
                    input.contasAReceber.contasAReceberItems[i].convite = new Data.Convite
                    {
                        idConvite = ((Data.Convite)parametros["Key"]).idConvite
                    };
                    _parameters.Add("Key", input.contasAReceber);
                    contasAReceberCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                contasAReceberCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Convite input = (Data.Convite)parametros["Key"];
            Tables.Convite bd = (Tables.Convite)this.m_EntityManager.find
            (
                typeof(Tables.Convite),
                new Object[]
                {
                    input.idConvite
                }
            );

            bd.tipoConvite.idTipoConvite.value = input.tipoConvite.idTipoConvite;
            bd.tituloSocio.idTituloSocio.value = input.tituloSocio.idTituloSocio;
            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            bd.convidado.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value = input.convidado.idEmpresaRelacionamento;
            bd.dataCriacaoConvite.value = input.dataCriacaoConvite;
            bd.dataVencimentoInicial.value = input.dataVencimentoInicial;
            bd.dataVencimentoFinal.value = input.dataVencimentoFinal;
            bd.metodoCriacao.value = input.metodoCriacao;

            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else
                bd.contasAReceber.idContasAReceber.isNull = true;

            this.m_EntityManager.merge(bd);
            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Convite bd = new Tables.Convite();

            if (((Data.Convite)parametros["Key"]).contasAReceber != null && ((Data.Convite)parametros["Key"]).contasAReceber.idContasAReceber > 0)
            {
                this.m_EntityManager.executeData(String.Format("update contasAReceberItem set idConvite = null where idConvite = {0}", ((Data.Convite)parametros["Key"]).idConvite), null);
                this.m_EntityManager.executeData(String.Format("update convite set idContasAReceber = null where idConvite = {0}", ((Data.Convite)parametros["Key"]).idConvite), null);
                this.m_EntityManager.executeData(String.Format("delete from contasareceber where idcontasareceber = {0}", ((Data.Convite)parametros["Key"]).contasAReceber.idContasAReceber), null);
            }
            bd.idConvite.value = ((Data.Convite)parametros["Key"]).idConvite;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Convite)bd).idConvite.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Convite)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Convite)input).idConvite = ((Tables.Convite)bd).idConvite.value;
                    ((Data.Convite)input).dataCriacaoConvite = ((Tables.Convite)bd).dataCriacaoConvite.value;
                    ((Data.Convite)input).dataVencimentoInicial = ((Tables.Convite)bd).dataVencimentoInicial.value;
                    ((Data.Convite)input).dataVencimentoFinal = ((Tables.Convite)bd).dataVencimentoFinal.value;
                    ((Data.Convite)input).metodoCriacao = ((Tables.Convite)bd).metodoCriacao.value;
                    ((Data.Convite)input).tituloSocio = (Data.TituloSocio)(new WS.CRUD.TituloSocio(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TituloSocio(),
                        ((Tables.Convite)bd).tituloSocio,
                        level + 1
                    );
                    ((Data.Convite)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.Convite)bd).funcionario,
                        level + 1
                    );
                    ((Data.Convite)input).tipoConvite = (Data.TipoConvite)(new WS.CRUD.TipoConvite(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.TipoConvite(),
                        ((Tables.Convite)bd).tipoConvite,
                        level + 1
                    );
                    ((Data.Convite)input).convidado = (Data.Convidado)(new WS.CRUD.Convidado(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                   (
                       new Data.Convidado(),
                       ((Tables.Convite)bd).convidado,
                       level + 1
                   );
                    ((Data.Convite)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.Convite)bd).contasAReceber,
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
            Data.Convite result = (Data.Convite)parametros["Key"];

            try
            {
                result = (Data.Convite)this.preencher
                (
                    new Data.Convite(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.Convite),
                        new Object[]
                        {
                            result.idConvite
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

            bool onlyCount = false;


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

            Data.Convite _input = (Data.Convite)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idConvite > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Convite.idConvite = @idConvite");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idConvite", _input.idConvite));
                    if (!sqlOrderBy.Contains("Convite.idConvite"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Convite.idConvite");
                    else { }
                }
                else { }


                if (_input.dataVencimentoInicial.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Convite.dataVencimentoInicial >= @dataVencimentoInicial");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataVencimentoInicial", _input.dataVencimentoInicial));
                    if (!sqlOrderBy.Contains("Convite.dataVencimentoInicial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Convite.dataVencimentoInicial");
                    else { }
                }
                else { }

                if (_input.dataVencimentoFinal.Ticks > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "Convite.dataVencimentoFinal <= @dataVencimentoFinal");
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("dataVencimentoFinal", _input.dataVencimentoFinal));
                    if (!sqlOrderBy.Contains("Convite.dataVencimentoFinal"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "Convite.dataVencimentoFinal");
                    else { }
                }
                else { }


                if (_input.tipoConvite != null)
                {
                    if (_input.tipoConvite.idTipoConvite > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoConvite.idTipoConvite = @idTipoConvite");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTipoConvite", _input.tipoConvite.idTipoConvite));
                        if (!sqlOrderBy.Contains("tipoConvite.idTipoConvite"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idTipoConvite");
                        else { }
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.tipoConvite.descricao))
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoConvite.descricao LIKE @descricao");
                        fieldKeys.Add(new EJB.TableBase.TFieldString("descricao", "%" + _input.tipoConvite.descricao + "%"));
                        if (!sqlOrderBy.Contains("tipoConvite.descricao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.descricao");
                        else { }
                    }

                    if (_input.tipoConvite.idadeInicial > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoConvite.idadeInicial = @idadeInicial");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idadeInicial", _input.tipoConvite.idadeInicial));
                        if (!sqlOrderBy.Contains("tipoConvite.idadeInicial"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idadeInicial");
                        else { }
                    }
                    else { }

                    if (_input.tipoConvite.idadeFinal > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tipoConvite.idadeFinal = @idadeFinal");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idadeFinal", _input.tipoConvite.idadeFinal));
                        if (!sqlOrderBy.Contains("tipoConvite.idadeFinal"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tipoConvite.idadeFinal");
                        else { }
                    }
                    else { }

                }
                else { }

                if (_input.tituloSocio != null)
                {
                    if (_input.tituloSocio.idTituloSocio > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   tituloSocio.idTituloSocio = @idTituloSocio");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idTituloSocio", _input.tituloSocio.idTituloSocio));
                        if (!sqlOrderBy.Contains("tituloSocio.idTituloSocio"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "tituloSocio.idTituloSocio");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.convidado != null)
                {
                    if (_input.convidado.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   convidado.idConvidado = @idConvidado");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idConvidado", _input.convidado.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("convidado.idConvidado"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "convidado.idConvidado");
                        else { }
                    }
                    else { }
                }
                else { }
                if (_input.funcionario != null)
                {
                    if (_input.funcionario.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   funcionario.idFuncionario = @idFuncionario");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idFuncionario", _input.funcionario.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("funcionario.idFuncionario"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "funcionario.idFuncionario");
                        else { }
                    }
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "Convite.* ") +
                    "from \n" +
                    "   Convite\n" +
                    "inner join tipoConvite tipoConvite" +
                    "   on tipoConvite.idTipoConvite = convite.idTipoConvite\n" +
                    "inner join convidado convidado" +
                    "   on convidado.idConvidado = convite.idConvidado\n" +
                    "inner join tituloSocio tituloSocio" +
                    "   on tituloSocio.idTituloSocio = convite.idTituloSocio\n " +
                    "inner join funcionario funcionario" +
                    "   on funcionario.idFuncionario = convite.idFuncionario\n " +

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
            Data.Convite input = (Data.Convite)parametros["Key"];
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
                    typeof(Tables.Convite),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Convite _data in
                    (System.Collections.Generic.List<Tables.Convite>)this.m_EntityManager.list
                    (
                        typeof(Tables.Convite),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    if (mode == "Roll")
                    {
                        _base = new Data.Convite();
                        ((Data.Convite)_base).idConvite = _data.idConvite.value;
                        ((Data.Convite)_base).dataCriacaoConvite = _data.dataCriacaoConvite.value;
                        ((Data.Convite)_base).dataVencimentoInicial = _data.dataVencimentoInicial.value;
                        ((Data.Convite)_base).dataVencimentoFinal = _data.dataVencimentoFinal.value;
                        ((Data.Convite)_base).metodoCriacao = _data.metodoCriacao.value;
                        ((Data.Convite)_base).tipoConvite = new Data.TipoConvite
                        {
                            idTipoConvite = _data.tipoConvite.idTipoConvite.value
                        };
                        ((Data.Convite)_base).funcionario = new Data.Funcionario
                        {
                            pessoa = new Data.Pessoa
                            {
                                idPessoa = _data.funcionario.funcionarioEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value,
                                nomeRazaoSocial = _data.funcionario.funcionarioEmpresaRelacionamento.pessoaRelacionamento.nomeRazaoSocial.value
                            }
                        };
                        ((Data.Convite)_base).tituloSocio = new Data.TituloSocio
                        {
                            idTituloSocio = _data.tituloSocio.idTituloSocio.value,
                        };
                        ((Data.Convite)_base).convidado = new Data.Convidado
                        {
                            idEmpresaRelacionamento = _data.convidado.convidadoEmpresaRelacionamento.idEmpresaRelacionamento.value,
                        };
                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.Convite(), _data, level);


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
