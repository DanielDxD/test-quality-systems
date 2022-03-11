using System;

namespace WS.CRUD
{
    public class DepartamentoFuncionario : WS.CRUD.Base
    {
        public DepartamentoFuncionario(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.DepartamentoFuncionario input = (Data.DepartamentoFuncionario)parametros["Key"];
            Tables.DepartamentoFuncionario bd = new Tables.DepartamentoFuncionario();

            bd.idDepartamentoFuncionario.isNull = true;

            if (input.departamento != null)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            if (input.funcionario != null)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }
            bd.dataInicio.value = input.dataInicio;
            bd.dataTermino.value = input.dataTermino;
            bd.responsavel.value = input.responsavel;

            this.m_EntityManager.persist(bd);

            ((Data.DepartamentoFuncionario)parametros["Key"]).idDepartamentoFuncionario = (int)bd.idDepartamentoFuncionario.value;

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.DepartamentoFuncionario input = (Data.DepartamentoFuncionario)parametros["Key"];
            Tables.DepartamentoFuncionario bd = (Tables.DepartamentoFuncionario)this.m_EntityManager.find
            (
                typeof(Tables.DepartamentoFuncionario),
                new Object[]
                {
                    input.idDepartamentoFuncionario
                }
            );

            if (input.departamento != null)
                bd.departamento.idDepartamento.value = input.departamento.idDepartamento;
            else { }
            if (input.funcionario != null)
                bd.funcionario.funcionarioEmpresaRelacionamento.idEmpresaRelacionamento.value = input.funcionario.idEmpresaRelacionamento;
            else { }
            bd.dataInicio.value = input.dataInicio;
            bd.dataTermino.value = input.dataTermino;
            bd.responsavel.value = input.responsavel;

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.DepartamentoFuncionario bd = new Tables.DepartamentoFuncionario();

            bd.idDepartamentoFuncionario.value = ((Data.DepartamentoFuncionario)parametros["Key"]).idDepartamentoFuncionario;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.DepartamentoFuncionario)bd).idDepartamentoFuncionario.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.DepartamentoFuncionario)input).operacao = ENum.eOperacao.NONE;

                    ((Data.DepartamentoFuncionario)input).idDepartamentoFuncionario = ((Tables.DepartamentoFuncionario)bd).idDepartamentoFuncionario.value;
                    ((Data.DepartamentoFuncionario)input).departamento = (Data.Departamento)(new WS.CRUD.Departamento(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Departamento(),
                        ((Tables.DepartamentoFuncionario)bd).departamento,
                        level + 1
                    );
                    ((Data.DepartamentoFuncionario)input).funcionario = (Data.Funcionario)(new WS.CRUD.Funcionario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Funcionario(),
                        ((Tables.DepartamentoFuncionario)bd).funcionario,
                        level + 1
                    );
                    ((Data.DepartamentoFuncionario)input).dataInicio = ((Tables.DepartamentoFuncionario)bd).dataInicio.value;
                    ((Data.DepartamentoFuncionario)input).dataTermino = ((Tables.DepartamentoFuncionario)bd).dataTermino.value;
                    ((Data.DepartamentoFuncionario)input).responsavel = ((Tables.DepartamentoFuncionario)bd).responsavel.value;
                }
                else { }
            }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.DepartamentoFuncionario result = (Data.DepartamentoFuncionario)parametros["Key"];
            String queryString = "";

            try
            {

                System.Collections.Generic.List<EJB.TableBase.TField> fieldKeys = new System.Collections.Generic.List<EJB.TableBase.TField>();
                string whereKeys = "";

                if ((result.departamento != null) && (result.departamento.idDepartamento > 0))
                {
                    fieldKeys.Add(new EJB.TableBase.TFieldInteger("idDepartamento", result.departamento.idDepartamento));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "departamentoFuncionario.idDepartamento= @idDepartamento";
                }
                else { }

                if (result.responsavel)
                {
                    //fieldKeys.Add(new EJB.TableBase.TFieldBoolean("ativo", result.ativo));
                    whereKeys += (whereKeys.Length > 0 ? " and " : "") + "departamentoFuncionario.responsavel = 1";
                }
                else { }

                if(result.funcionario != null)
                {
                    if(result.funcionario.idEmpresaRelacionamento > 0)
                    {
                        fieldKeys.Add(new EJB.TableBase.TFieldInteger("idEmpresaRelacionamento", result.funcionario.idEmpresaRelacionamento));
                        whereKeys += (whereKeys.Length > 0 ? " and " : "") + "departamentoFuncionario.idFuncionario= @idEmpresaRelacionamento";
                    }
                    else { }
                }
                else { }

                queryString =
                (
                    "select top 1\n" +
                    "    *\n" +
                    "from \n" + 
                    "    departamentoFuncionario departamentoFuncionario \n" +
                    "        inner join departamento \n" +
                    "            on	departamento.idDepartamento = departamentoFuncionario.idDepartamento \n" +
                    "        left join funcionario \n" +
                    "            on	funcionario.idFuncionario = departamentoFuncionario.idFuncionario \n" +
                    "        left join empresaRelacionamento empresaRelacionamento \n" +
                    "            on	empresaRelacionamento.idEmpresaRelacionamento = funcionario.idFuncionario \n" +
                    "        left join pessoa pessoa\n" +
                    "            on	empresaRelacionamento.idPessoaRelacionamento = pessoa.idPessoa \n" +
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
                    Tables.DepartamentoFuncionario _data in
                    (System.Collections.Generic.List<Tables.DepartamentoFuncionario>)this.m_EntityManager.list
                    (
                        typeof(Tables.DepartamentoFuncionario),
                        queryString,
                        fieldKeys.ToArray()
                    )
                )
                {
                    result = (Data.DepartamentoFuncionario)this.preencher
                    (
                        new Data.DepartamentoFuncionario(),
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.DepartamentoFuncionario input = (Data.DepartamentoFuncionario)parametros["Key"];
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
                    typeof(Tables.DepartamentoFuncionario),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.DepartamentoFuncionario _data in
                    (System.Collections.Generic.List<Tables.DepartamentoFuncionario>)this.m_EntityManager.list
                    (
                        typeof(Tables.DepartamentoFuncionario),
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
                    _base = (Data.Base)this.preencher(new Data.DepartamentoFuncionario(), _data, level);

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
