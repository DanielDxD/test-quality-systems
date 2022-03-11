using System;
using System.Collections.Generic;
using System.Linq;
namespace WS.CRUD
{
    public class Usuario : WS.CRUD.Base
    {
        public Usuario(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.Usuario input = (Data.Usuario)parametros["Key"];
            Tables.Usuario bd =
            (
                parametros["Return"] != null ?
                (Tables.Usuario)parametros["Return"] :
                 new Tables.Usuario()
            );

            System.Collections.Hashtable _parametros = new System.Collections.Hashtable();

            if (input.funcionario)
            {
                //Incluir/Alterar Funcionario
                _parametros.Add("Key", input);

                if (input.idEmpresaRelacionamento == 0)
                {
                    _parametros.Add("Return", bd.funcionario);
                    input = (Data.Usuario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).incluir(_parametros);
                }
                else
                {
                    _parametros.Add
                    (
                        "Return",
                        (Tables.Funcionario)this.m_EntityManager.find
                        (
                            typeof(Tables.Funcionario),
                            new Object[]
                            {
                                input.idEmpresaRelacionamento
                            }
                        )
                    );
                    input = (Data.Usuario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);
                }

                bd.pessoa.pessoa.idPessoa.value = ((Tables.Funcionario)_parametros["Return"]).funcionarioEmpresaRelacionamento.pessoaRelacionamento.idPessoa.value;
            }
            else
            {
                //Incluir/Alterar PessoaFisica
                _parametros.Add("Key", input.pessoa);

                input.pessoa = (Data.PessoaFisica)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);

                bd.pessoa.pessoa.idPessoa.value = input.pessoa.idPessoa;
            }

            _parametros.Clear();
            _parametros = null;

            bd.idUsuario.isNull = true;
            bd.usuario.value = input.nomeUsuario;
            bd.senhaDinamica.value = input.senhaDinamica;
            if (input.senhaDinamica)
                bd.senha.value = "";
            else
                bd.senha.value = input.senha;
            bd.ativo.value = input.ativo;
            bd.nomeCSS.value = input.nomeCSS;
            if (input.funcionario)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.idEmpresaRelacionamento;
            else
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.persist(bd);

            ((Data.Usuario)parametros["Key"]).idUsuario = (int)bd.idUsuario.value;

            //Processa UsuarioPerfil
            if (input.perfils != null)
            {
                WS.CRUD.UsuarioPerfil usuarioPerfilCRUD = new WS.CRUD.UsuarioPerfil(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.perfils.Length; i++)
                {
                    Data.UsuarioPerfil up = new Data.UsuarioPerfil();
                    up.idUsuario = bd.idUsuario.value;
                    up.perfil = input.perfils[i];
                    _parameters.Add("Key", up);
                    usuarioPerfilCRUD.incluir(_parameters);

                    _parameters.Clear();
                }

                usuarioPerfilCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa UsuarioEmpresa
            if (input.usuarioEmpresas != null)
            {
                WS.CRUD.UsuarioEmpresa usuarioEmpresaCRUD = new WS.CRUD.UsuarioEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.usuarioEmpresas.Length; i++)
                {
                    input.usuarioEmpresas[i].idUsuario = new Data.Usuario();
                    input.usuarioEmpresas[i].idUsuario.idUsuario = bd.idUsuario.value;
                    _parameters.Add("Key", input.usuarioEmpresas[i]);
                    usuarioEmpresaCRUD.incluir(_parameters);

                    _parameters.Clear();
                }

                usuarioEmpresaCRUD = null;
                _parameters = null;
            }
            else { }

            String signature = Utils.Utils.RecordSign(input, 4);

            this.m_EntityManager.execute
            (
                "update usuario set assinatura = '" + signature + "' where idUsuario = @idUsuario",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger
                    (
                        "idUsuario",
                        input.idUsuario
                    )
                }
            );

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.Usuario input = (Data.Usuario)parametros["Key"];
            Tables.Usuario bd =
            (
                parametros["Return"] != null ?
                (Tables.Usuario)parametros["Return"] :
                (Tables.Usuario)this.m_EntityManager.find
                (
                    typeof(Tables.Usuario),
                    new Object[]
                    {
                        input.idUsuario
                    }
                )
            );

            System.Collections.Hashtable _parametros = new System.Collections.Hashtable();

            if (input.funcionario)
            {
                //Alterar Funcionario
                _parametros.Add("Key", input);
                _parametros.Add("Return", bd.funcionario);

                input = (Data.Usuario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).atualizar(_parametros);
            }
            else
            {
                //Alterar PessoaFisica
                _parametros.Add("Key", input.pessoa);
                _parametros.Add("Return", bd.pessoa);

                input.pessoa = (Data.PessoaFisica)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).alterar(_parametros);
            }

            _parametros.Clear();
            _parametros = null;

            bd.usuario.value = input.nomeUsuario;
            bd.senhaDinamica.value = input.senhaDinamica;
            if (input.senhaDinamica)
                bd.senha.value = "";
            else
            {
                if ((input.senha != null) && (input.senha.Length > 0))
                    bd.senha.value = input.senha;
                else { }
            }
            bd.ativo.value = input.ativo;
            bd.nomeCSS.value = input.nomeCSS;
            if (input.funcionario)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.idEmpresaRelacionamento;
            else
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull = true;

            this.m_EntityManager.merge(bd);

            //Processa UsuarioPerfil
            if (input.perfils != null)
            {
                WS.CRUD.UsuarioPerfil usuarioPerfilCRUD = new WS.CRUD.UsuarioPerfil(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.perfils.Length; i++)
                {
                    Data.UsuarioPerfil up = new Data.UsuarioPerfil();
                    up.idUsuario = bd.idUsuario.value;
                    up.perfil = input.perfils[i];
                    _parameters.Add("Key", up);

                    up.operacao = input.perfils[i].operacao;
                    if (up.operacao == ENum.eOperacao.NONE)
                        up.operacao = ENum.eOperacao.ALTERAR;
                    else { }
                    usuarioPerfilCRUD.atualizar(_parameters);

                    _parameters.Clear();
                }

                usuarioPerfilCRUD = null;
                _parameters = null;
            }
            else { }

            //Processa UsuarioEmpresa
            if (input.usuarioEmpresas != null)
            {
                WS.CRUD.UsuarioEmpresa usuarioEmpresaCRUD = new WS.CRUD.UsuarioEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager);
                System.Collections.Hashtable _parameters = new System.Collections.Hashtable();

                for (int i = 0; i < input.usuarioEmpresas.Length; i++)
                {
                    input.usuarioEmpresas[i].idUsuario = new Data.Usuario();
                    input.usuarioEmpresas[i].idUsuario.idUsuario = bd.idUsuario.value;
                    _parameters.Add("Key", input.usuarioEmpresas[i]);
                    usuarioEmpresaCRUD.atualizar(_parameters);
                    if (input.usuarioEmpresas[i].operacao != ENum.eOperacao.EXCLUIR)
                        input.usuarioEmpresas[i] = (Data.UsuarioEmpresa)usuarioEmpresaCRUD.consultar(_parameters);
                    else { }

                    _parameters.Clear();
                }

                usuarioEmpresaCRUD = null;
                _parameters = null;
            }
            else { }

            input.senha = bd.senha.value;

            String signature = Utils.Utils.RecordSign(input, 4);

            this.m_EntityManager.execute
            (
                "update usuario set assinatura = '" + signature + "' where idUsuario = @idUsuario",
                new EJB.TableBase.TField[]
                {
                    new EJB.TableBase.TFieldInteger
                    (
                        "idUsuario",
                        input.idUsuario
                    )
                }
            );

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.Usuario bd = new Tables.Usuario();

            bd.idUsuario.value = ((Data.Usuario)parametros["Key"]).idUsuario;

            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.Usuario)bd).idUsuario.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.Usuario)input).operacao = ENum.eOperacao.NONE;

                    ((Data.Usuario)input).idUsuario = ((Tables.Usuario)bd).idUsuario.value;
                    ((Data.Usuario)input).nomeUsuario = ((Tables.Usuario)bd).usuario.value;
                    ((Data.Usuario)input).senhaDinamica = ((Tables.Usuario)bd).senhaDinamica.value;
                    ((Data.Usuario)input).senha = ((Tables.Usuario)bd).senha.value;
                    ((Data.Usuario)input).ativo = ((Tables.Usuario)bd).ativo.value;
                    ((Data.Usuario)input).nomeCSS = ((Tables.Usuario)bd).nomeCSS.value;

                    if (!((Tables.Usuario)bd).funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull)
                    {
                        ((Data.Usuario)input).funcionario = true;
                        input = (Data.Usuario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            input,
                            ((Tables.Usuario)bd).funcionario,
                            level
                        );
                    }
                    else
                        ((Data.Usuario)input).pessoa = (Data.PessoaFisica)(new WS.CRUD.PessoaFisica(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                        (
                            new Data.PessoaFisica(),
                            ((Tables.Usuario)bd).pessoa,
                            level
                        );

                    if (level < 1)
                    {
                        System.Collections.Generic.List<Data.Perfil> _perfils = new System.Collections.Generic.List<Data.Perfil>();

                        //Preencher Perfils
                        foreach
                        (
                            System.Data.DataRow _dataRow in
                            this.m_EntityManager.executeData
                            (
                                (
                                    "select\n" +
                                    "   perfil.idPerfil,\n" +
                                    "	perfil.descricao descricaoPerfil,\n" +
                                    "	IsNull(perfil.administrador, 0) administrador,\n" +
                                    "	menu.idMenu,\n" +
                                    "	menu.descricao descricaoMenu,\n" +
                                    "	menu.idPagina,\n" +
                                    "	menu.opcao,\n" +
                                    "	IsNull(menu.idMenuPai, 0) idMenuPai,\n" +
                                    "	menu.ordem,\n" +
                                    "   menu.arquivoImagem,\n" +
                                    "	IsNull(perfilMenu.consultar, IsNull(perfil.administrador, 0)) consultar,\n" +
                                    "	IsNull(perfilMenu.incluir, IsNull(perfil.administrador, 0)) incluir,\n" +
                                    "	IsNull(perfilMenu.alterar, IsNull(perfil.administrador, 0)) alterar,\n" +
                                    "	IsNull(perfilMenu.excluir, IsNull(perfil.administrador, 0)) excluir,\n" +
                                    "	pagina.pagina,\n" +
                                    "	pagina.altura,\n" +
                                    "	pagina.largura,\n" +
                                    "   pagina.newLayout,\n " +
                                    "   pagina.gestaoNovo\n " +
                                    "from\n" +
                                    "	usuario\n" +
                                    "		inner join usuarioPerfil\n" +
                                    "			on	usuarioPerfil.idUsuario = usuario.idUsuario\n" +
                                    "		inner join\n" +
                                    "			(\n" +
                                    "				select\n" +
                                    "					menu.idMenu,\n" +
                                    "					perfil.idPerfil\n" +
                                    "				from\n" +
                                    "					perfil,\n" +
                                    "					menu\n" +
                                    "			) perfilMenuAll\n" +
                                    "			on perfilMenuAll.idPerfil = usuarioPerfil.idPerfil\n" +
                                    "		inner join perfil\n" +
                                    "			on	perfil.idPerfil = perfilMenuAll.idPerfil\n" +
                                    "		inner join menu\n" +
                                    "			on	menu.idMenu = perfilMenuAll.idMenu\n" +
                                    "		left join pagina\n" +
                                    "			on	pagina.idPagina = menu.idPagina\n" +
                                    "		left join perfilMenu\n" +
                                    "			on	perfilMenu.idPerfil = perfilMenuAll.idPerfil and\n" +
                                    "				perfilMenu.idMenu = perfilMenuAll.idMenu\n" +
                                    "where\n" +
                                    "	usuario.idUsuario = @idUsuario\n" +
                                    "order by\n" +
                                    "	perfil.idPerfil,\n" +
                                    "	IsNull(menu.idMenuPai, 0),\n" +
                                    "	menu.ordem,\n" +
                                    "	menu.idMenu"
                                ),
                                new EJB.TableBase.TField[]
                                {
                                    new EJB.TableBase.TFieldInteger("idUsuario", ((Tables.Usuario)bd).idUsuario.value)
                                }
                            ).Rows
                        )
                        {
                            Data.Perfil _perfil = null;

                            if
                            (
                                (_perfils.Count == 0) ||
                                (_perfils[_perfils.Count - 1].idPerfil != (int)_dataRow["idPerfil"])
                            )
                            {
                                _perfil = new Data.Perfil();
                                _perfil.idPerfil = (int)_dataRow["idPerfil"];
                                _perfils.Add(_perfil);
                            }
                            else
                                _perfil = _perfils[_perfils.Count - 1];

                            _perfil.descricao = (string)_dataRow["descricaoPerfil"];
                            _perfil.administrador = (bool)_dataRow["administrador"];

                            System.Collections.Generic.List<Data.PerfilMenu> _perfilMenus = new System.Collections.Generic.List<Data.PerfilMenu>();

                            if (_perfil.perfilMenus != null)
                                _perfilMenus.AddRange(_perfil.perfilMenus);
                            else { }

                            _perfilMenus.Add(new Data.PerfilMenu());
                            _perfilMenus[_perfilMenus.Count - 1].idMenu = (int)_dataRow["idMenu"];
                            _perfilMenus[_perfilMenus.Count - 1].descricao = (string)_dataRow["descricaoMenu"];
                            _perfilMenus[_perfilMenus.Count - 1].opcao = (string)_dataRow["opcao"];
                            _perfilMenus[_perfilMenus.Count - 1].menuPai = new Data.Menu();
                            _perfilMenus[_perfilMenus.Count - 1].menuPai.idMenu = (int)_dataRow["idMenuPai"];
                            _perfilMenus[_perfilMenus.Count - 1].ordem = (int)_dataRow["ordem"];
                            _perfilMenus[_perfilMenus.Count - 1].arquivoImagem = _dataRow.IsNull("arquivoImagem") ? null : (String)_dataRow["arquivoImagem"];

                            _perfilMenus[_perfilMenus.Count - 1].consultar = (bool)_dataRow["consultar"];
                            _perfilMenus[_perfilMenus.Count - 1].incluir = (bool)_dataRow["incluir"];
                            _perfilMenus[_perfilMenus.Count - 1].alterar = (bool)_dataRow["alterar"];
                            _perfilMenus[_perfilMenus.Count - 1].excluir = (bool)_dataRow["excluir"];

                            if (!_dataRow.IsNull("idPagina"))
                            {
                                _perfilMenus[_perfilMenus.Count - 1].pagina = new Data.Pagina();
                                _perfilMenus[_perfilMenus.Count - 1].pagina.idPagina = (int)_dataRow["idPagina"];
                                _perfilMenus[_perfilMenus.Count - 1].pagina.pagina = (string)_dataRow["pagina"];
                                _perfilMenus[_perfilMenus.Count - 1].pagina.altura = (int)_dataRow["altura"];
                                _perfilMenus[_perfilMenus.Count - 1].pagina.largura = (int)_dataRow["largura"];
                                _perfilMenus[_perfilMenus.Count - 1].pagina.newLayout = Utils.Utils.ToBoolean(_dataRow["newLayout"].ToString());
                                _perfilMenus[_perfilMenus.Count - 1].pagina.gestaoNovo = Utils.Utils.ToBoolean(_dataRow["gestaoNovo"].ToString());
                            }
                            else { }

                            _perfil.perfilMenus = (_perfilMenus.Count > 0 ? _perfilMenus.ToArray() : null);
                        }

                        ((Data.Usuario)input).perfils = (_perfils.Count > 0 ? _perfils.ToArray() : null);

                        /* Pegando relatorios do perfil */
                        if (((Data.Usuario)input).perfils != null)
                        {
                            string query = "SELECT idPerfil, idRelatorio, idRelatorioSql, idRelatorioPerfil FROM relatorioPerfil WHERE idPerfil IN(",
                                    ids = "";
                            foreach (Data.Perfil item in ((Data.Usuario)input).perfils)
                                ids += (ids.Length > 0 ? ", " : null) + item.idPerfil;
                            query += ids + ")";

                            try
                            {
                                List<Data.RelatorioPerfil> _rp = new List<Data.RelatorioPerfil>();
                                foreach
                                (
                                    System.Data.DataRow _dataRow in
                                    this.m_EntityManager.executeData(query, null).Rows)
                                {

                                    Data.Perfil _p = ((Data.Usuario)input).perfils.FirstOrDefault(X => X.idPerfil == Utils.Utils.ToInt(_dataRow[0].ToString()));
                                    if (_p != null)
                                    {
                                        if (_p.relatorioPerfil == null)
                                            _p.relatorioPerfil = new List<Data.RelatorioPerfil>().ToArray();
                                        else { }

                                        /* Relatorios gerais */
                                        {
                                            if (Utils.Utils.ToInt(_dataRow[1].ToString()) > 0 && _rp.FirstOrDefault(X => X.perfil != null && X.perfil.idPerfil == Utils.Utils.ToInt(_dataRow[0].ToString()) && X.relatorio != null && X.relatorio.idRelatorio == Utils.Utils.ToInt(_dataRow[1].ToString())) == null)
                                            {
                                                _rp.Add(new Data.RelatorioPerfil
                                                {
                                                    idRelatorioPerfil = Utils.Utils.ToInt(_dataRow[3].ToString()),
                                                    perfil = new Data.Perfil { idPerfil = Utils.Utils.ToInt(_dataRow[0].ToString()) },
                                                    relatorio = new Data.Relatorios { idRelatorio = Utils.Utils.ToInt(_dataRow[1].ToString()) }
                                                });
                                            }
                                            else { }

                                            if (Utils.Utils.ToInt(_dataRow[2].ToString()) > 0 && _rp.FirstOrDefault(X => X.perfil != null && X.perfil.idPerfil == Utils.Utils.ToInt(_dataRow[0].ToString()) && X.relatorioDinamico != null && X.relatorioDinamico.idRelatorioSql == Utils.Utils.ToInt(_dataRow[2].ToString())) == null)
                                            {
                                                _rp.Add(new Data.RelatorioPerfil
                                                {
                                                    idRelatorioPerfil = Utils.Utils.ToInt(_dataRow[3].ToString()),
                                                    perfil = new Data.Perfil { idPerfil = Utils.Utils.ToInt(_dataRow[0].ToString()) },
                                                    relatorioDinamico = new Data.RelatorioSql { idRelatorioSql = Utils.Utils.ToInt(_dataRow[2].ToString()) }
                                                });
                                            }
                                            else { }

                                        }
                                    }
                                    else { }
                                }

                                List<Data.Perfil> _pf = new List<Data.Perfil>(((Data.Usuario)input).perfils);
                                foreach (Data.Perfil item in _pf)
                                    item.relatorioPerfil = _rp.Where(X => X.perfil != null && X.perfil.idPerfil == item.idPerfil).ToArray();

                            }
                            catch { }

                        }
                        else { }
                    }
                    else { }

                    if (level < 1)
                    {
                        //Preencher UsuarioEmpresas
                        if (((Tables.Usuario)bd).usuarioEmpresas != null)
                        {
                            System.Collections.Generic.List<Data.UsuarioEmpresa> _list = new System.Collections.Generic.List<Data.UsuarioEmpresa>();

                            foreach (Tables.UsuarioEmpresa _item in ((Tables.Usuario)bd).usuarioEmpresas)
                            {
                                _list.Add
                                (
                                    (Data.UsuarioEmpresa)
                                    (new WS.CRUD.UsuarioEmpresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                                    (
                                        new Data.UsuarioEmpresa(),
                                        _item,
                                        level + 1
                                    )
                                );
                            }

                            ((Data.Usuario)input).usuarioEmpresas = _list.ToArray();
                            _list.Clear();
                            _list = null;
                        }
                        else
                        {
                            if (((Data.Usuario)input).usuarioEmpresas != null)
                            {
                                System.Collections.Generic.List<Data.UsuarioEmpresa> _list = new System.Collections.Generic.List<Data.UsuarioEmpresa>();

                                foreach (Data.UsuarioEmpresa _item in ((Data.Usuario)input).usuarioEmpresas)
                                {
                                    if (_item.operacao != ENum.eOperacao.EXCLUIR)
                                    {
                                        _item.operacao = ENum.eOperacao.NONE;
                                        _list.Add(_item);
                                    }
                                    else { }
                                }

                                if (_list.Count > 0)
                                    ((Data.Usuario)input).usuarioEmpresas = _list.ToArray();
                                else
                                    ((Data.Usuario)input).usuarioEmpresas = null;

                                _list.Clear();
                                _list = null;
                            }
                            else { }
                        }
                    }
                    else { }

                    //Verify Record Signature
                    //if (!((Tables.Usuario)bd).assinatura.isNull)
                    //    if (((Tables.Usuario)bd).assinatura.value != Utils.Utils.RecordSign(input, 4))
                    //        throw new Exception("Usuário - Assinatura Inválida.");
                    //    else { }
                    //else { }
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            /*Consultar Diferente */
            Data.Usuario result = (Data.Usuario)parametros["Key"];

            String queryString = "";

            try
            {
                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                //usuario
                if ((result.nomeUsuario != null) && (result.nomeUsuario.Length > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("usuario", result.nomeUsuario));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "usuario.usuario = @usuario";
                }
                else { }

                //ativo
                if (result.ativo)
                {
                    //fieldKeys.Add(new EJB.TableBase.TFieldBoolean("ativo", result.ativo));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "usuario.ativo = 1";
                }
                else { }

                //idPessoa
                if (result.pessoa != null)
                {
                    if (result.pessoa.idPessoa > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idPessoa", result.pessoa.idPessoa));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.idPessoa = @idPessoa";
                    }
                    else { }

                    //nomeRazaoSocial
                    if ((result.pessoa.nomeRazaoSocial != null) && (result.pessoa.nomeRazaoSocial.Length > 0))
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", "%" + result.pessoa.nomeRazaoSocial + "%"));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial LIKE @nomeRazaoSocial";
                    }
                    else { }
                }
                else { }

                if (result.idEmpresaRelacionamento > 0)
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", result.idEmpresaRelacionamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresaRelacionamento = @idEmpresaRelacionamento";
                }
                else { }

                if (String.IsNullOrEmpty(whereKeys))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUsuario", result.idUsuario));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "usuario.idUsuario = @idUsuario";
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    usuario.*\n" +
                    "from\n" +
                    "    usuario\n" +
                    "        inner join pessoa\n" +
                    "            on	pessoa.idPessoa = usuario.idPessoa\n" +
                    "        left join funcionario\n" +
                    "            on	funcionario.idFuncionario = usuario.idFuncionario\n" +
                    "        left join empresaRelacionamento\n" +
                    "            on	empresaRelacionamento.idEmpresaRelacionamento = funcionario.idFuncionario\n" +
                    (
                        (whereKeys.Length > 0) ?
                        (
                            "where\n" +
                            "    " + whereKeys + "\n"
                        ) :
                        ""
                    ) +
                    "order by\n" +
                    "	pessoa.nomeRazaoSocial\n"
                );

                foreach
                (
                    Tables.Usuario _data in
                    (System.Collections.Generic.List<Tables.Usuario>)this.m_EntityManager.list
                    (
                        typeof(Tables.Usuario),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.Usuario)this.preencher
                    (
                        new Data.Usuario(),
                        _data,
                        0
                    );
                }
            }
            catch (Exception e)
            {
                Utils.Utils.WriteLog(this.GetType().ToString() + ".consultar() -> " + e.ToString() + "[" + queryString + "]");
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

            Data.Usuario _input = (Data.Usuario)input;

            System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = (System.Collections.Generic.List<EJB.TableBase.TField>)_fieldKeys;

            EJB.TableBase.TTableBase table = (EJB.TableBase.TTableBase)classBase.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);

            if (table != null)
            {
                sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + " pessoa.pfPj = 'F'";

                if (_input.idEmpresa > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "empresaRelacionamento.idEmpresa = @idEmpresa");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresa", _input.idEmpresa));
                    if (!sqlOrderBy.Contains("empresaRelacionamento.idEmpresa"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "empresaRelacionamento.idEmpresa");
                    else { }
                }
                else { }

                if ((_input.nomeUsuario != null) && (_input.nomeUsuario.Length > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldString("usuario", _input.nomeUsuario));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "usuario.usuario = @usuario";
                }
                else { }

                //ativo
                if (_input.ativo)
                {
                    //fieldKeys.Add(new EJB.TableBase.TFieldBoolean("ativo", result.ativo));
                    sqlWhere += (sqlWhere.Length > 0 ? " and " : "") + "usuario.ativo = 1";
                }
                else { }

                if (_input.idUsuario > 0)
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "usuario.idUsuario = @idUsuario");
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idUsuario", _input.idUsuario));
                    if (!sqlOrderBy.Contains("usuario.idUsuario"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "usuario.idUsuario");
                    else { }
                }
                else { }

                if ((_input.pessoa != null) && (_input.pessoa.cpfCnpj != null) && (_input.pessoa.cpfCnpj.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.cpfCnpj like @cpfCnpj");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("cpfCnpj", _input.pessoa.cpfCnpj + '%'));
                    if (!sqlOrderBy.Contains("pessoa.cpfCnpj"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.cpfCnpj");
                    else { }
                }
                else { }

                if ((_input.pessoa != null) && (_input.pessoa.nomeRazaoSocial != null) && (_input.pessoa.nomeRazaoSocial.Length > 0))
                {
                    sqlWhere += ((sqlWhere.Length > 0 ? " and " : "") + "pessoa.nomeRazaoSocial COLLATE Latin1_General_CI_AI like @nomeRazaoSocial COLLATE Latin1_General_CI_AI");
                    fieldKeys.Add(new EJB.TableBase.TFieldString("nomeRazaoSocial", _input.pessoa.nomeRazaoSocial + '%'));
                    if (!sqlOrderBy.Contains("pessoa.nomeRazaoSocial"))
                        sqlOrderBy += ((sqlOrderBy.Length > 0 ? ", " : "") + "pessoa.nomeRazaoSocial");
                    else { }
                }
                else { }

                result =
                (
                    "select " + (onlyCount ? "" : (((numRows > 0) && (offSet < 0)) ? " top " + numRows.ToString() + " " : "")) +
                    "   " + (onlyCount ? " COUNT(1) " : "usuario.* ") +
                    "from\n" +
                    (
                        "usuario usuario\n" +
                        "	inner join pessoa pessoa\n" +
                        "		on	pessoa.idPessoa = usuario.idPessoa\n" +
                        "	left join funcionario funcionario\n" +
                        "		on	funcionario.idFuncionario = usuario.idFuncionario\n" +
                        "	left join empresaRelacionamento empresaRelacionamento\n" +
                        "		on	empresaRelacionamento.idEmpresaRelacionamento = funcionario.idFuncionario\n"
                ) +
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
            Data.Usuario input = (Data.Usuario)parametros["Key"];
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
                    typeof(Tables.Usuario),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.Usuario _data in
                    (System.Collections.Generic.List<Tables.Usuario>)this.m_EntityManager.list
                    (
                        typeof(Tables.Usuario),
                        _select,
                       _fieldKeys.ToArray()
                    )
                )
                {
                    try
                    {
                        Data.Base _base = null;

                        if (mode == "Roll")
                        {
                            _base = new Data.Usuario();
                            _base = (Data.Usuario)(object)_base;
                            ((Data.Usuario)_base).idUsuario = _data.idUsuario.value;
                            ((Data.Usuario)_base).nomeUsuario = _data.usuario.value;
                            ((Data.Usuario)_base).senha = _data.senha.value;
                            ((Data.Usuario)_base).pessoa = new Data.Pessoa { nomeRazaoSocial = _data.pessoa.pessoa.nomeRazaoSocial.value };
                            if (!_data.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.isNull)
                            {
                                ((Data.Usuario)_base).funcionario = true;
                            }
                        }
                        else
                            _base = (Data.Base)this.preencher(new Data.Usuario(), _data, level);

                        if (report != null)
                            report.ProcessRecord(_base);
                        else
                            result.Add(_base);
                    }
                    catch (Exception e)
                    {
                        Utils.Utils.WriteLog(this.GetType().ToString() + ".listar() -> " + e.ToString());
                    }
                }

                if (report != null)
                    /*report.ProcessRecord(null);*/
                    Console.WriteLine("Relatorio");
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
