using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS.CRUD
{
    public class PdvCompra : WS.CRUD.Base
    {
        public PdvCompra(long? idEmpresa, EJB.EntityManager.EntityManager entityManager) : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PdvCompra input = (Data.PdvCompra)parametros["Key"];
            Tables.PdvCompra bd = new Tables.PdvCompra();

            bd.idPdvCompra.isNull = true;
            bd.dataCompra.value = input.dataCompra;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.cpfCnpj.value = input.cpfCnpj;
            bd.statusCompra.value = input.statusCompra;
            bd.numeroComanda.value = input.numeroComanda;

            if (input.pessoaFisicaJuridica != null)
                bd.pessoaFisicaJuridica.idEmpresaRelacionamento.value = input.pessoaFisicaJuridica.idEmpresaRelacionamento;
            else { }

            if (input.requisicaoInterna != null)
                bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            else { }

            if (input.pdvEstacao != null)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.contasAReceber != null)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else { }

            if (input.pos != null && input.pos.idPos > 0)
                bd.pos.idPos.value = input.pos.idPos;
            else { }

            this.m_EntityManager.persist(bd);

            ((Data.PdvCompra)parametros["Key"]).idPdvCompra = (int)bd.idPdvCompra.value;

            if (input.pdvCompraCupons != null)
            {
                WS.CRUD.PdvCompraCupom pdvCompraCuponsCRUD = new WS.CRUD.PdvCompraCupom(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraCupons.Length; i++)
                {
                    input.pdvCompraCupons[i].pdvCompra = new Data.PdvCompra();
                    input.pdvCompraCupons[i].pdvCompra.idPdvCompra = bd.idPdvCompra.value;
                    _parameters.Add("Key", input.pdvCompraCupons[i]);
                    pdvCompraCuponsCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraCuponsCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.pdvCompraStatus != null)
            {
                WS.CRUD.PdvCompraStatus pdvCompraStatusCRUD = new WS.CRUD.PdvCompraStatus(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraStatus.Length; i++)
                {
                    input.pdvCompraStatus[i].pdvCompra = new Data.PdvCompra();
                    input.pdvCompraStatus[i].pdvCompra.idPdvCompra = bd.idPdvCompra.value;
                    _parameters.Add("Key", input.pdvCompraStatus[i]);
                    pdvCompraStatusCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraStatusCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PdvCompra input = (Data.PdvCompra)parametros["Key"];
            Tables.PdvCompra bd = (Tables.PdvCompra)this.m_EntityManager.find
            (
                typeof(Tables.PdvCompra),
                new Object[]
                {
                    input.idPdvCompra
                }
            );
            bd.dataCompra.value = input.dataCompra;
            bd.numeroDocumento.value = input.numeroDocumento;
            bd.cpfCnpj.value = input.cpfCnpj;
            bd.statusCompra.value = input.statusCompra;
            bd.numeroComanda.value = input.numeroComanda;

            if (input.pessoaFisicaJuridica != null)
                bd.pessoaFisicaJuridica.idEmpresaRelacionamento.value = input.pessoaFisicaJuridica.idEmpresaRelacionamento;
            else { }

            if (input.requisicaoInterna != null && input.requisicaoInterna.idRequisicaoInterna > 0)
                bd.requisicaoInterna.idRequisicaoInterna.value = input.requisicaoInterna.idRequisicaoInterna;
            else { }

            if (input.pdvEstacao != null && input.pdvEstacao.idPdvEstacao > 0)
                bd.pdvEstacao.idPdvEstacao.value = input.pdvEstacao.idPdvEstacao;
            else { }

            if (input.contasAReceber != null && input.contasAReceber.idContasAReceber > 0)
                bd.contasAReceber.idContasAReceber.value = input.contasAReceber.idContasAReceber;
            else
                bd.contasAReceber.idContasAReceber.isNull = true;

            if (input.pos != null && input.pos.idPos > 0)
                bd.pos.idPos.value = input.pos.idPos;
            else { }

            this.m_EntityManager.merge(bd);

            if (input.pdvCompraCupons != null)
            {
                WS.CRUD.PdvCompraCupom pdvCompraCuponsCRUD = new WS.CRUD.PdvCompraCupom(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraCupons.Length; i++)
                {
                    input.pdvCompraCupons[i].pdvCompra = new Data.PdvCompra();
                    input.pdvCompraCupons[i].pdvCompra.idPdvCompra = bd.idPdvCompra.value;
                    _parameters.Add("Key", input.pdvCompraCupons[i]);
                    if (input.pdvCompraCupons[i].operacao == ENum.eOperacao.NONE)
                        input.pdvCompraCupons[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvCompraCuponsCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraCuponsCRUD = null;
                _parameters = null;
            }
            else { }

            if (input.pdvCompraStatus != null)
            {
                WS.CRUD.PdvCompraStatus pdvCompraStatusCRUD = new WS.CRUD.PdvCompraStatus(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.pdvCompraStatus.Length; i++)
                {
                    input.pdvCompraStatus[i].pdvCompra = new Data.PdvCompra();
                    input.pdvCompraStatus[i].pdvCompra.idPdvCompra = bd.idPdvCompra.value;
                    _parameters.Add("Key", input.pdvCompraStatus[i]);
                    if (input.pdvCompraStatus[i].operacao == ENum.eOperacao.NONE)
                        input.pdvCompraStatus[i].operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    pdvCompraStatusCRUD.atualizar(_parameters);
                    _parameters.Clear();
                }

                pdvCompraStatusCRUD = null;
                _parameters = null;
            }
            else { }

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PdvCompra bd = new Tables.PdvCompra();

            bd.idPdvCompra.value = ((Data.PdvCompra)parametros["Key"]).idPdvCompra;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PdvCompra)bd).idPdvCompra.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PdvCompra)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PdvCompra)input).idPdvCompra = ((Tables.PdvCompra)bd).idPdvCompra.value;
                    ((Data.PdvCompra)input).pessoaFisicaJuridica = (Data.EmpresaRelacionamento)(new WS.CRUD.EmpresaRelacionamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.EmpresaRelacionamento(),
                        ((Tables.PdvCompra)bd).pessoaFisicaJuridica,
                        level + 1
                    );
                    ((Data.PdvCompra)input).requisicaoInterna = (Data.RequisicaoInterna)(new WS.CRUD.RequisicaoInterna(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.RequisicaoInterna(),
                        ((Tables.PdvCompra)bd).requisicaoInterna,
                        level /* Pegar todas as situacoes */
                    );

                    ((Data.PdvCompra)input).contasAReceber = (Data.ContasAReceber)(new WS.CRUD.ContasAReceber(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.ContasAReceber(),
                        ((Tables.PdvCompra)bd).contasAReceber,
                        level /* Pegar todas as situacoes */
                    );

                    ((Data.PdvCompra)input).pdvEstacao = (Data.PdvEstacao)(new WS.CRUD.PdvEstacao(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.PdvEstacao(),
                        ((Tables.PdvCompra)bd).pdvEstacao,
                        level + 1
                    );

                    ((Data.PdvCompra)input).pos = (Data.Pos)(new WS.CRUD.Pos(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Pos(),
                        ((Tables.PdvCompra)bd).pos,
                        level + 1
                    );

                    ((Data.PdvCompra)input).dataCompra = ((Tables.PdvCompra)bd).dataCompra.value;
                    ((Data.PdvCompra)input).numeroDocumento = ((Tables.PdvCompra)bd).numeroDocumento.value;
                    ((Data.PdvCompra)input).cpfCnpj = ((Tables.PdvCompra)bd).cpfCnpj.value;
                    ((Data.PdvCompra)input).statusCompra = ((Tables.PdvCompra)bd).statusCompra.value;
                    ((Data.PdvCompra)input).numeroComanda = ((Tables.PdvCompra)bd).numeroComanda.value;

                    try
                    {
                        double
                            total = 0;

                        if (((Tables.PdvCompra)bd).pdvCompraCupons != null)
                            foreach (var item in ((Tables.PdvCompra)bd).pdvCompraCupons.Where(X => X.statusCupom.value.ToLower() != "c"))
                                if (item.pdvCompraCupomItem != null)
                                    foreach (var j in item.pdvCompraCupomItem)
                                        total = Convert.ToDouble((total + Convert.ToDouble((j.quantidade.value * j.valor.value).ToString("0.00")) - j.desconto.value).ToString("0.00"));
                                else { }
                        else { }

                        ((Data.PdvCompra)input).total = total;
                    }
                    catch
                    {
                        ((Data.PdvCompra)input).total = 0;
                    }

                    if (level < 1)
                    {
                        if (((Tables.PdvCompra)bd).pdvCompraCupons != null)
                        {
                            System.Collections.Generic.List<Data.PdvCompraCupom> _list = new System.Collections.Generic.List<Data.PdvCompraCupom>();

                            foreach (Tables.PdvCompraCupom _item in ((Tables.PdvCompra)bd).pdvCompraCupons)
                            {
                                _list.Add
                                (
                                    (Data.PdvCompraCupom)
                                    (new WS.CRUD.PdvCompraCupom(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvCompraCupom(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                        ((Data.PdvCompra)input).pdvCompraCupons = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvCompra)input).pdvCompraCupons != null)
                            {
                                System.Collections.Generic.List<Data.PdvCompraCupom> _list = new System.Collections.Generic.List<Data.PdvCompraCupom>();

                                foreach (Data.PdvCompraCupom _item in ((Data.PdvCompra)input).pdvCompraCupons)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvCompra)input).pdvCompraCupons = _list.ToArray();
                                else
                                    ((Data.PdvCompra)input).pdvCompraCupons = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        if (((Tables.PdvCompra)bd).pdvCompraStatus != null)
                        {
                            System.Collections.Generic.List<Data.PdvCompraStatus> _list = new System.Collections.Generic.List<Data.PdvCompraStatus>();

                            foreach (Tables.PdvCompraStatus _item in ((Tables.PdvCompra)bd).pdvCompraStatus)
                            {
                                _list.Add
                                (
                                    (Data.PdvCompraStatus)
                                    (new WS.CRUD.PdvCompraStatus(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvCompraStatus(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.PdvCompra)input).pdvCompraStatus = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvCompra)input).pdvCompraStatus != null)
                            {
                                System.Collections.Generic.List<Data.PdvCompraStatus> _list = new System.Collections.Generic.List<Data.PdvCompraStatus>();

                                foreach (Data.PdvCompraStatus _item in ((Data.PdvCompra)input).pdvCompraStatus)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvCompra)input).pdvCompraStatus = _list.ToArray();
                                else
                                    ((Data.PdvCompra)input).pdvCompraStatus = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }

                        if (((Tables.PdvCompra)bd).pdvCompraTaxaServico != null)
                        {
                            System.Collections.Generic.List<Data.PdvCompraTaxaServico> _list = new System.Collections.Generic.List<Data.PdvCompraTaxaServico>();

                            foreach (Tables.PdvCompraTaxaServico _item in ((Tables.PdvCompra)bd).pdvCompraTaxaServico)
                            {
                                _list.Add
                                (
                                    (Data.PdvCompraTaxaServico)
                                    (new WS.CRUD.PdvCompraTaxaServico(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.PdvCompraTaxaServico(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                        ((Data.PdvCompra)input).pdvCompraTaxaServico = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.PdvCompra)input).pdvCompraTaxaServico != null)
                            {
                                System.Collections.Generic.List<Data.PdvCompraTaxaServico> _list = new System.Collections.Generic.List<Data.PdvCompraTaxaServico>();

                                foreach (Data.PdvCompraTaxaServico _item in ((Data.PdvCompra)input).pdvCompraTaxaServico)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.PdvCompra)input).pdvCompraTaxaServico = _list.ToArray();
                                else
                                    ((Data.PdvCompra)input).pdvCompraTaxaServico = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
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
            Data.PdvCompra result = (Data.PdvCompra)parametros["Key"];
            String queryString = "";
            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.idPdvCompra > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", result.idPdvCompra));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.idPdvCompra = @idPdvCompra";
                }
                else { }

                if (!String.IsNullOrEmpty(result.numeroDocumento))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroDocumento", result.numeroDocumento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.numeroDocumento = @numeroDocumento";
                }
                else { }

                if (!String.IsNullOrEmpty(result.statusCompra))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusCompra", result.statusCompra));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.statusCompra = @statusCompra";
                }
                else { }

                if (result.pessoaFisicaJuridica != null && result.pessoaFisicaJuridica.idEmpresaRelacionamento > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", result.pessoaFisicaJuridica.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.idEmpresaRelacionamento = @idEmpresaRelacionamento";
                }
                else { }

                if (result.requisicaoInterna != null && result.requisicaoInterna.idRequisicaoInterna > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idRequisicaoInterna", result.requisicaoInterna.idRequisicaoInterna));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.idRequisicaoInterna = @idRequisicaoInterna";
                }
                else { }

                if (result.pdvEstacao != null)
                {
                    if (result.pdvEstacao.idPdvEstacao > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", result.pdvEstacao.idPdvEstacao));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.idPdvEstacao = @idPdvEstacao";
                    }
                    else { }

                    if (result.pdvEstacao.departamentoOrigem != null && result.pdvEstacao.departamentoOrigem.idDepartamento > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoOrigem", result.pdvEstacao.departamentoOrigem.idDepartamento));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoes.idDepartamentoOrigem = @idDepartamentoOrigem";
                    }
                    else { }

                    if (result.pdvEstacao.departamento != null && result.pdvEstacao.departamento.idDepartamento > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", result.pdvEstacao.departamento.idDepartamento));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvEstacoes.idDepartamento = @idDepartamento";
                    }
                    else { }
                }
                else { }

                if (result.contasAReceber != null && result.contasAReceber.idContasAReceber > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", result.contasAReceber.idContasAReceber));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.idContasAReceber = @idContasAReceber";
                }
                else { }

                if (!String.IsNullOrEmpty(result.numeroComanda))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroComanda", result.numeroComanda));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pdvCompra.numeroComanda = @numeroComanda";
                }
                else { }

                queryString =
                (
                    "select \n" +
                    "   top 1 *\n" +
                    "from\n" +
                    "    pdvCompra pdvCompra\n " +
                    "inner join empresaRelacionamento empresaRelacionamento\n " +
                    "   on empresaRelacionamento.idEmpresaRelacionamento = pdvCompra.idEmpresaRelacionamento\n " +
                    "LEFT join requisicaoInterna requisicaoInterna\n " +
                    "   on requisicaoInterna.idRequisicaoInterna = pdvCompra.idRequisicaoInterna\n " +
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
                    Tables.PdvCompra _data in
                    (System.Collections.Generic.List<Tables.PdvCompra>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompra),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.PdvCompra)this.preencher
                    (
                        new Data.PdvCompra(),
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
                sqlOrderBy = "",
                sqlInner = "";

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

            Data.PdvCompra _input = (Data.PdvCompra)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                if (_input.idPdvCompra > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "PdvCompra.idPdvCompra = @idPdvCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvCompra", _input.idPdvCompra));
                    if (!sqlOrderBy.Contains("PdvCompra.idPdvCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "PdvCompra.idPdvCompra");
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

                if (_input.contasAReceber != null)
                {
                    if (_input.contasAReceber.idContasAReceber > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   contasAReceber.idContasAReceber = @idContasAReceber");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idContasAReceber", _input.contasAReceber.idContasAReceber));
                        if (!sqlOrderBy.Contains("contasAReceber.idContasAReceber"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "contasAReceber.idContasAReceber");
                        else { }
                    }
                    else { }
                }
                else { }

                if (_input.pessoaFisicaJuridica != null)
                {
                    if (_input.pessoaFisicaJuridica.idEmpresaRelacionamento > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", _input.pessoaFisicaJuridica.idEmpresaRelacionamento));
                        if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresaRelacionamento"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresaRelacionamento");
                        else { }
                    }
                    else { }

                    if (_input.pessoaFisicaJuridica.pessoa != null)
                    {
                        if (!String.IsNullOrEmpty(_input.pessoaFisicaJuridica.pessoa.nomeRazaoSocial))
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.nomeRazaoSocial like @nomeRazaoSocial");
                            fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + _input.pessoaFisicaJuridica.pessoa.nomeRazaoSocial + "%"));
                            if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                            else { }
                        }
                        else { }
                        if (_input.pessoaFisicaJuridica.pessoa.idPessoa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pessoa.idPessoa = @idPessoa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", _input.pessoaFisicaJuridica.pessoa.idPessoa));
                            if (!sqlOrderBy.Contains("pessoa.idPessoa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.idPessoa");
                            else { }
                        }
                        else { }
                    }
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.cpfCnpj))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvCompra.cpfCnpj = @cpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.cpfCnpj));
                    if (!sqlOrderBy.Contains("pdvCompra.cpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompra.cpfCnpj");
                    else { }
                }
                else { }

                if (!String.IsNullOrEmpty(_input.statusCompra))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvCompra.statusCompra = @statusCompra");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("statusCompra", _input.statusCompra));
                    if (!sqlOrderBy.Contains("pdvCompra.statusCompra"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompra.statusCompra");
                    else { }
                }
                else { }


                if (!String.IsNullOrEmpty(_input.numeroComanda))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvCompra.numeroComanda = @numeroComanda");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("numeroComanda", _input.numeroComanda));
                    if (!sqlOrderBy.Contains("pdvCompra.numeroComanda"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompra.numeroComanda");
                    else { }
                }
                else { }

                if (_input.pdvEstacao != null)
                {
                    if (_input.pdvEstacao.idPdvEstacao > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoes.idPdvEstacao = @idPdvEstacao");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPdvEstacao", _input.pdvEstacao.idPdvEstacao));
                        if (!sqlOrderBy.Contains("pdvEstacoes.idPdvEstacao"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idPdvEstacao");
                        else { }
                    }

                    if (_input.pdvEstacao.departamentoOrigem != null)
                    {
                        if (_input.pdvEstacao.departamentoOrigem.idDepartamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoes.idDepartamentoOrigem = @idDepartamentoOrigem");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamentoOrigem", _input.pdvEstacao.departamentoOrigem.idDepartamento));
                            if (!sqlOrderBy.Contains("pdvEstacoes.idDepartamentoOrigem"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idDepartamentoOrigem");
                            else { }
                        }
                        else { }
                    }

                    if (_input.pdvEstacao.departamento != null)
                    {
                        if (_input.pdvEstacao.departamento.idDepartamento > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvEstacoes.idDepartamento = @idDepartamento");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", _input.pdvEstacao.departamento.idDepartamento));
                            if (!sqlOrderBy.Contains("pdvEstacoes.idDepartamento"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvEstacoes.idDepartamento");
                            else { }
                        }
                        else { }

                        if (_input.pdvEstacao.departamento.idEmpresa > 0)
                        {
                            sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   departamento.idEmpresa = @idEmpresa");
                            fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.pdvEstacao.departamento.idEmpresa));
                            if (!sqlOrderBy.Contains("pdvEstacoes.idEmpresa"))
                                sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "departamento.idEmpresa");
                            else { }
                        }
                        else { }
                    }
                }

                if (_input.pos != null)
                {
                    if (_input.pos.idPos > 0)
                    {
                        sqlWhere += ((sqlWhere.Length > 0 ? " and\n" : "") + "   pdvCompra.idPos = @idPos");
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPos", _input.pos.idPos));
                        if (!sqlOrderBy.Contains("pdvCompra.idPos"))
                            sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pdvCompra.idPos");
                        else { }
                    }
                    else { }

                }
                else { }

                if
                (
                    (_input.pdvCompraCupons != null) &&
                    (_input.pdvCompraCupons.Length > 0)
                )
                {
                    sqlInner +=
                        (
                            " inner join pdvCompraCupom" +
                            "  on  pdvCompraCupom.idPdvCompra = pdvCompra.idPdvCompra "
                        );

                    if (_input.pdvCompraCupons[0].sequenciaCupom > 0)
                    {
                        sqlInner +=
                        (
                            " and pdvCompraCupom.sequenciaCupom = " + _input.pdvCompraCupons[0].sequenciaCupom.ToString()
                        );
                    }
                    else { }

                    if (!String.IsNullOrEmpty(_input.pdvCompraCupons[0].statusCupom))
                    {
                        sqlInner +=
                        (
                            " and pdvCompraCupom.statusCupom = '" + _input.pdvCompraCupons[0].statusCupom + "'"
                        );
                    }
                    else { }

                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "pdvCompra.* ") +
                    "from\n" +
                    "   pdvCompra pdvCompra with (nolock)\n" +
                    (sqlInner.Length > 0 ? sqlInner : "") +

                    "       inner join empresaRelacionamento empresaRelacionamento\n" +
                    "           on pdvCompra.idEmpresaRelacionamento = empresaRelacionamento.idEmpresaRelacionamento \n" +
                    "       LEFT join requisicaoInterna requisicaoInterna\n" +
                    "           on pdvCompra.idRequisicaoInterna = requisicaoInterna.idRequisicaoInterna \n" +
                    "       inner join pessoa pessoa\n" +
                    "           on (empresaRelacionamento.idPessoaRelacionamento = pessoa.idPessoa OR pdvCompra.cpfCnpj = pessoa.cpfCnpj) \n" +
                    "       inner join pdvEstacoes pdvEstacoes\n" +
                    "           on (pdvEstacoes.idPdvEstacao = pdvCompra.idPdvEstacao)\n" +
                    "       left join contasAReceber contasAReceber\n" +
                    "           on (contasAReceber.idContasAReceber = pdvCompra.idContasAReceber)\n" +
                    "       left join departamento departamentoOrigem on (pdvEstacoes.idDepartamentoOrigem = departamentoOrigem.idDepartamento)\n " +
                    "       left join departamento departamento on (pdvEstacoes.idDepartamento = departamento.idDepartamento) \n " +
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
            Data.PdvCompra input = (Data.PdvCompra)parametros["Key"];
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
                    typeof(Tables.PdvCompra),
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
                    Tables.PdvCompra _data in
                    (System.Collections.Generic.List<Tables.PdvCompra>)this.m_EntityManager.list
                    (
                        typeof(Tables.PdvCompra),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    Data.Base _base = new Data.Base();
                    if (mode == "Roll")
                    {
                        _base = new Data.PdvCompra();
                        ((Data.PdvCompra)_base).idPdvCompra = _data.idPdvCompra.value;
                        ((Data.PdvCompra)_base).contasAReceber = new Data.ContasAReceber { idContasAReceber = _data.contasAReceber.idContasAReceber.value };
                        ((Data.PdvCompra)_base).dataCompra = _data.dataCompra.value;
                        ((Data.PdvCompra)_base).cpfCnpj = _data.cpfCnpj.value;
                        ((Data.PdvCompra)_base).numeroComanda = _data.numeroComanda.value;
                        ((Data.PdvCompra)_base).numeroDocumento = _data.numeroDocumento.value;
                        ((Data.PdvCompra)_base).statusCompra = _data.statusCompra.value;
                        ((Data.PdvCompra)_base).pdvEstacao = new Data.PdvEstacao { idPdvEstacao = _data.pdvEstacao.idPdvEstacao.value, descricao = _data.pdvEstacao.descricao.value };
                        ((Data.PdvCompra)_base).statusCompra = _data.statusCompra.value;
                        ((Data.PdvCompra)_base).pessoaFisicaJuridica = new Data.EmpresaRelacionamento { idEmpresaRelacionamento = _data.pessoaFisicaJuridica.idEmpresaRelacionamento.value, pessoa = new Data.Pessoa { nomeRazaoSocial = _data.pessoaFisicaJuridica.pessoaRelacionamento.nomeRazaoSocial.value } };

                        if (_data.pdvCompraTaxaServico != null)
                        {
                            List<Data.PdvCompraTaxaServico> taxas = new List<Data.PdvCompraTaxaServico>();
                            foreach (Tables.PdvCompraTaxaServico item in _data.pdvCompraTaxaServico)
                            {
                                Data.PdvCompraTaxaServico _item = new Data.PdvCompraTaxaServico
                                {
                                    idPdvCompraTaxaServico = item.idPdvCompraTaxaServico.value,
                                    pdvCompra = new Data.PdvCompra
                                    {
                                        idPdvCompra = item.pdvCompra.idPdvCompra.value
                                    },
                                    valor = item.valor.value
                                };
                                taxas.Add(_item);
                            }
                            ((Data.PdvCompra)_base).pdvCompraTaxaServico = taxas.ToArray();
                        }

                        try
                        {
                            double total = 0;

                            if (_data.pdvCompraCupons != null)
                                foreach (var item in _data.pdvCompraCupons.Where(X => X.statusCupom.value.ToLower() != "c"))
                                    if (item.pdvCompraCupomItem != null)
                                        foreach (var j in item.pdvCompraCupomItem)
                                            total = Convert.ToDouble((total + Convert.ToDouble((j.quantidade.value * j.valor.value).ToString("0.00")) - j.desconto.value).ToString("0.00"));
                                    else { }
                            else { }

                            ((Data.PdvCompra)_base).total = total;
                        }
                        catch
                        {
                            ((Data.PdvCompra)_base).total = 0;
                        }




                    }
                    else
                        _base = (Data.Base)this.preencher(new Data.PdvCompra(), _data, level);

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
