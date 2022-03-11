using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class PdvCompraCupom : WS.CRUD.Base
    {
        public PdvCompraCupom(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupom input = (Data.PdvCompraCupom)parametros["Key"];
            Tables.PdvCompraCupom bd = new Tables.PdvCompraCupom();

            bd.idPdvCompraCupom.isNull = true;
            bd.data.value = input.data;
            bd.impresso.value = input.impresso;
            bd.sequenciaCupom.value = input.sequenciaCupom;
            if (input.pdvCompra != null)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }

            if (input.pos != null && input.pos.idPos > 0)
                bd.pos.idPos.value = input.pos.idPos;
            else
                bd.pos.idPos.isNull = true;

            bd.statusCupom.value = input.statusCupom;


            //Incluir/Alterar RequisicaoInterna
            if (input.requisicaoInterna != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.requisicaoInterna);
                _parametros.Add("Return", bd.requisicaoInterna);

                input.requisicaoInterna = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }
            else { }

            if (input.requisicaoInterna != null && input.requisicaoInterna.idRequisicaoInterna > 0)
                bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            else
                bd.requisicaoInterna.idRequisicaoInterna.isNull = true;

            bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;

            this.m_EntityManager.persist(bd);

            ((Data.PdvCompraCupom)parametros["Key"]).idPdvCompraCupom = (int)bd.idPdvCompraCupom.value;

            if (input.pdvCompraCupomItem != null)
            {
                WS.CRUD.PdvCompraCupomItem pdvCompraCupomItensCRUD = new WS.CRUD.PdvCompraCupomItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraCupomItem.Length; i++)
                {
                    input.pdvCompraCupomItem[i].pdvCompraCupom = new Data.PdvCompraCupom
                    {
                        idPdvCompraCupom = input.idPdvCompraCupom,
                        requisicaoInterna = input.requisicaoInterna
                    };
                    input.pdvCompraCupomItem[i].pdvCompraCupom.operacao = ENum.eOperacao.NONE;
                    _parameters.Add("Key", input.pdvCompraCupomItem[i]);
                    pdvCompraCupomItensCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraCupomItensCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupom input = (Data.PdvCompraCupom)parametros["Key"];
            Tables.PdvCompraCupom bd = (Tables.PdvCompraCupom)this.m_EntityManager.find
            (
                typeof(Tables.PdvCompraCupom),
                new Object[]
                {
                    input.idPdvCompraCupom
                }
            );

            //Alterar Requisição Interna;
            if (input.requisicaoInterna != null)
            {
                System.Collections.Hashtable _parametros = new System.Collections.Hashtable();
                _parametros.Add("Key", input.requisicaoInterna);
                _parametros.Add("Return", bd.requisicaoInterna);

                input.requisicaoInterna = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                _parametros.Clear();
                _parametros = null;
            }

            if (input.requisicaoInterna != null && input.requisicaoInterna.idRequisicaoInterna > 0)
                bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            else
                bd.requisicaoInterna.idRequisicaoInterna.isNull = true;

            if (input.data.Ticks > 0)
                bd.data.value = input.data;
            else { }
            bd.impresso.value = input.impresso;

            if (input.sequenciaCupom > 0)
                bd.sequenciaCupom.value = input.sequenciaCupom;
            else { }

            if (input.pdvCompra != null)
                bd.pdvCompra.idPdvCompra.value = input.pdvCompra.idPdvCompra;
            else { }

            if (!String.IsNullOrEmpty(input.statusCupom))
                bd.statusCupom.value = input.statusCupom;
            else { }

            if (input.pos != null && input.pos.idPos > 0)
                bd.pos.idPos.value = input.pos.idPos;
            else
                bd.pos.idPos.isNull = true;

            this.m_EntityManager.merge(bd);

            if (input.pdvCompraCupomItem != null)
            {
                WS.CRUD.PdvCompraCupomItem pdvCompraCupomItensCRUD = new WS.CRUD.PdvCompraCupomItem(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraCupomItem.Length; i++)
                {
                    input.pdvCompraCupomItem[i].pdvCompraCupom = new Data.PdvCompraCupom
                    {
                        idPdvCompraCupom = input.idPdvCompraCupom,
                        requisicaoInterna = input.requisicaoInterna
                    };
                    input.pdvCompraCupomItem[i].pdvCompraCupom.operacao = ENum.eOperacao.NONE;
                    _parameters.Add("Key", input.pdvCompraCupomItem[i]);
                    if (input.pdvCompraCupomItem[i].operacao == ENum.eOperacao.NONE)
                        input.pdvCompraCupomItem[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvCompraCupomItensCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraCupomItensCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvCompraCupom bd = new Tables.PdvCompraCupom();

            bd.idPdvCompraCupom.value = ((Data.PdvCompraCupom)parametros["Key"]).idPdvCompraCupom;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvCompraCupom)bd).idPdvCompraCupom.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvCompraCupom)input).operacao = ENum.eOperacao.NONE;
                    ((Data.PdvCompraCupom)input).idPdvCompraCupom = ((Tables.PdvCompraCupom)bd).idPdvCompraCupom.value;
                    ((Data.PdvCompraCupom)input).impresso = ((Tables.PdvCompraCupom)bd).impresso.value;

                    if (level < 1)
                    {
                        ((Data.PdvCompraCupom)input).pdvCompra = (Data.PdvCompra)(new WS.CRUD.PdvCompra(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PdvCompra(),
                            ((Tables.PdvCompraCupom)bd).pdvCompra,
                            level + 1
                        );
                    }
                    else { }

                    ((Data.PdvCompraCupom)input).requisicaoInterna = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.PdvCompraCupom)bd).requisicaoInterna,
                        level /* Pegar todas as situacoes */
                    );

                    ((Data.PdvCompraCupom)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.PdvCompraCupom)bd).funcionario,
                        level
                    );

                    ((Data.PdvCompraCupom)input).pos = (Data.Pos)(new WS.CRUD.Pos(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pos(),
                        ((Tables.PdvCompraCupom)bd).pos,
                        level
                    );


                    ((Data.PdvCompraCupom)input).data = ((Tables.PdvCompraCupom)bd).data.value;
                    ((Data.PdvCompraCupom)input).sequenciaCupom = ((Tables.PdvCompraCupom)bd).sequenciaCupom.value;
                    ((Data.PdvCompraCupom)input).statusCupom = ((Tables.PdvCompraCupom)bd).statusCupom.value;

                    if (level < 2)
                    {
                        //Preencher PdvCompraCupomItems
                        if (((Tables.PdvCompraCupom)bd).pdvCompraCupomItem != null)
                        {
                            System.Collections.Generic.List<Data.PdvCompraCupomItem> _list = new System.Collections.Generic.List<Data.PdvCompraCupomItem>();

                            foreach (Tables.PdvCompraCupomItem _item in ((Tables.PdvCompraCupom)bd).pdvCompraCupomItem)
                            {
                                _list.Add
                                (
                                    (Data.PdvCompraCupomItem)
                                    (new WS.CRUD.PdvCompraCupomItem(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvCompraCupomItem(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.PdvCompraCupom)input).pdvCompraCupomItem = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvCompraCupom)input).pdvCompraCupomItem != null)
                            {
                                System.Collections.Generic.List<Data.PdvCompraCupomItem> _list = new System.Collections.Generic.List<Data.PdvCompraCupomItem>();

                                foreach (Data.PdvCompraCupomItem _item in ((Data.PdvCompraCupom)input).pdvCompraCupomItem)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvCompraCupom)input).pdvCompraCupomItem = _list.ToArray();
                                else
                                    ((Data.PdvCompraCupom)input).pdvCompraCupomItem = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                }
                else { }

            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompraCupom result = (Data.PdvCompraCupom)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if (result.idPdvCompraCupom > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupom", result.idPdvCompraCupom));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.idPdvCompraCupom = @idPdvCompraCupom";
                }
                else { }
                if ((result.pdvCompra != null && result.pdvCompra.idPdvCompra > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", result.pdvCompra.idPdvCompra));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.idPdvCompra = @idPdvCompra";
                }
                else { }


                if (result.data.Ticks > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldDatetime("data", result.data));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.data = @data";
                }
                else { }

                if (result.sequenciaCupom > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("sequenciaCupom", result.sequenciaCupom));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.sequenciaCupom = @sequenciaCupom";
                }
                else { }

                if (!String.IsNullOrEmpty(result.statusCupom))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusCupom", result.statusCupom));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.statusCupom = @statusCupom";
                }
                else { }

                if (result.requisicaoInterna != null && result.requisicaoInterna.idRequisicaoInterna > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInterna", result.requisicaoInterna.idRequisicaoInterna));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompraCupom.idRequisicaoInterna = @idRequisicaoInterna";
                }
                else { }

                queryString =
                (
                    "select \n" +
                    "    *\n" +
                    "from \n" +
                    "    pdvCompraCupom pdvCompraCupom\n" +
                    "inner join pdvCompra pdvCompra\n " +
                    "   on pdvCompra.idPdvCompra = pdvCompraCupom.idPdvCompra\n" +
                    "inner join empresaRelacionamento empresaRelacionamento\n " +
                    "   on empresaRelacionamento.idEmpresaRelacionamento = pdvCompra.idEmpresaRelacionamento\n " +
                    "left join requisicaoInterna requisicaoInterna\n " +
                    "   on requisicaoInterna.idRequisicaoInterna = pdvCompraCupom.idRequisicaoInterna\n " +
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
                    Tables.PdvCompraCupom _data in
                    (System.Collections.Generic.List<Tables.PdvCompraCupom>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraCupom),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvCompraCupom)this.preencher
                    (
                        new Data.PdvCompraCupom(),
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

            Data.PdvCompraCupom _input = (Data.PdvCompraCupom)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvCompraCupom > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    PdvCompraCupom.idPdvCompraCupom = @idPdvCompraCupom");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompraCupom", _input.idPdvCompraCupom));
                    if (!sqlOrderBy.Contains("PdvCompraCupom.idPdvCompraCupom"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraCupom.idPdvCompraCupom");
                    else { }
                }
                else { }

                if (_input.sequenciaCupom > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    PdvCompraCupom.sequenciaCupom = @sequenciaCupom");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("sequenciaCupom", _input.sequenciaCupom));
                    if (!sqlOrderBy.Contains("PdvCompraCupom.sequenciaCupom"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraCupom.sequenciaCupom");
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

                    if (_input.pdvCompra.pdvEstacao != null)
                    {

                        if (_input.pdvCompra.pdvEstacao.departamento != null && _input.pdvCompra.pdvEstacao.departamento.idDepartamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "    pdvEstacoes.idDepartamento = @idDepartamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.pdvCompra.pdvEstacao.departamento.idDepartamento));
                            if (!sqlOrderBy.Contains("pdvEstacoes.idDepartamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idDepartamento");
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if(_input.funcionario != null)
                    {
                        if(_input.funcionario.idEmpresaRelacionamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresaRelacionamentoFuncionario.idEmpresaRelacionamento = @idEmpresaRelacionamentoFuncionario");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamentoFuncionario", _input.funcionario.idEmpresaRelacionamento));
                            if (!sqlOrderBy.Contains("empresaRelacionamentoFuncionario.idEmpresaRelacionamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamentoFuncionario.idEmpresaRelacionamento");
                            else { }
                        }
                        else { }

                        if(_input.funcionario.pessoa != null)
                        {
                            if (_input.funcionario.pessoa.idPessoa > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoaFuncionario.idPessoa = @idPessoaFuncionario");
                                fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoaFuncionario", _input.funcionario.pessoa.idPessoa));
                                if (!sqlOrderBy.Contains("pessoaFuncionario.idPessoa"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoaFuncionario.idPessoa");
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.pdvCompra.pessoaFisicaJuridica != null)
                    {
                        if (_input.pdvCompra.pessoaFisicaJuridica.idEmpresaRelacionamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.pdvCompra.pessoaFisicaJuridica.idEmpresaRelacionamento));
                            if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresaRelacionamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresaRelacionamento");
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.pdvCompra.pessoaFisicaJuridica != null)
                    {
                        if (_input.pdvCompra.pessoaFisicaJuridica.pessoa != null)
                        {
                            if (_input.pdvCompra.pessoaFisicaJuridica.pessoa.idPessoa > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.idPessoa = @idPessoa");
                                fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pdvCompra.pessoaFisicaJuridica.pessoa.idPessoa));
                                if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }

                    if (_input.pdvCompra.pdvEstacao != null)
                    {
                        if (_input.pdvCompra.pdvEstacao.idPdvEstacao > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoes.idPdvEstacao = @idPdvEstacao");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvCompra.pdvEstacao.idPdvEstacao));
                            if (!sqlOrderBy.Contains("pdvEstacoes.idPdvEstacao"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idPdvEstacao");
                            else { }
                        }

                        if (_input.pdvCompra.pdvEstacao.departamentoOrigem != null)
                        {
                            if (_input.pdvCompra.pdvEstacao.departamentoOrigem.idDepartamento > 0)
                            {
                                sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoes.idDepartamentoOrigem = @idDepartamentoOrigem");
                                fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoOrigem", _input.pdvCompra.pdvEstacao.departamentoOrigem.idDepartamento));
                                if (!sqlOrderBy.Contains("pdvEstacoes.idDepartamentoOrigem"))
                                    sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idDepartamentoOrigem");
                                else { }
                            }
                        }
                    }

                }
                else { }

                if(_input.pos != null)
                {
                    if(_input.pos.idPos > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   PdvCompraCupom.idPos = @idPos");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPos", _input.pos.idPos));
                        if (!sqlOrderBy.Contains("PdvCompraCupom.idPos"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompraCupom.idPos");
                        else { }
                    }
                    else { }
                }
                else { }


                if (_input.requisicaoInterna != null)
                {
                    if (_input.requisicaoInterna.idRequisicaoInterna > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   requisicaoInterna.idRequisicaoInterna = @idRequisicaoInterna");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInterna", _input.requisicaoInterna.idRequisicaoInterna));
                        if (!sqlOrderBy.Contains("requisicaoInterna.idRequisicaoInterna"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "requisicaoInterna.idRequisicaoInterna");
                        else { }
                    }
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.statusCupom))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvCompraCupom.statusCupom = @statusCupom");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusCupom", _input.statusCupom));
                    if (!sqlOrderBy.Contains("pdvCompraCupom.statusCupom"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompraCupom.statusCupom");
                    else { }
                }
                else { }


                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvCompraCupom.* ") +
                    "from \n" +
                    "   pdvCompraCupom pdvCompraCupom\n" +
                    "       inner join pdvCompra\n" +
                    "           on pdvCompraCupom.idPdvCompra = pdvCompra.idPdvCompra" +
                    "       inner join empresaRelacionamento empresaRelacionamento\n" +
                    "           on pdvCompra.idEmpresaRelacionamento = empresaRelacionamento.idEmpresaRelacionamento \n" +
                    "       LEFT join empresaRelacionamento empresaRelacionamentoFuncionario\n" +
                    "           on pdvCompraCupom.idFuncionario = empresaRelacionamentoFuncionario.idEmpresaRelacionamento \n" +
                    "       LEFT join pessoa pessoaFuncionario\n" +
                    "           on (empresaRelacionamentoFuncionario.idPessoaRelacionamento = pessoaFuncionario.idPessoa) \n" +
                    "       left join requisicaoInterna requisicaoInterna\n" +
                    "           on pdvCompraCupom.idRequisicaoInterna = requisicaoInterna.idRequisicaoInterna \n" +
                    "       inner join pessoa pessoa\n" +
                    "           on (empresaRelacionamento.idPessoaRelacionamento = pessoa.idPessoa OR pdvCompra.cpfCnpj = pessoa.cpfCnpj) \n" +
                    "       inner join pdvEstacoes pdvEstacoes\n" +
                    "           on (pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao)\n" +
                    "       left join departamento departamentoOrigem on (pdvEstacoes.idDepartamentoOrigem = departamentoOrigem.idDepartamento)\n " +
                    "       left join departamento departamento on (pdvEstacoes.idDepartamentoOrigem = departamento.idDepartamento) \n " +

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
            Data.PdvCompraCupom input = (Data.PdvCompraCupom)parametros["Key"];
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
                    typeof(Tables.PdvCompraCupom),
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
                    Tables.PdvCompraCupom _data in
                    (System.Collections.Generic.List<Tables.PdvCompraCupom>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompraCupom),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();

                    _base = (Data.Base)this.preencher(new Data.PdvCompraCupom(), _data, level);

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
