using System;

namespace WS.CRUD
{
    public class PessoaEnderecoFinalidadeEndereco : WS.CRUD.Base
    {
        public PessoaEnderecoFinalidadeEndereco(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoFinalidadeEndereco input = (Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"];
            Tables.PessoaEnderecoFinalidadeEndereco bd = new Tables.PessoaEnderecoFinalidadeEndereco();

            bd.pessoaEnderecoContatoFinalidade.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;

            if ((input.finalidadeEndereco != null) && (input.finalidadeEndereco.idFinalidadeEndereco > 0))
                bd.finalidadeEndereco.idFinalidadeEndereco.value = input.finalidadeEndereco.idFinalidadeEndereco;
            else { }

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoFinalidadeEndereco input = (Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"];
            Tables.PessoaEnderecoFinalidadeEndereco bd = (Tables.PessoaEnderecoFinalidadeEndereco)this.m_EntityManager.find
            (
                typeof(Tables.PessoaEnderecoFinalidadeEndereco),
                new Object[]
                {
                    input.idPessoaEnderecoContato,
                    input.finalidadeEndereco.idFinalidadeEndereco
                }
            );

            bd.pessoaEnderecoContatoFinalidade.pessoaEnderecoContato.idPessoaEnderecoContato.value = input.idPessoaEnderecoContato;
            if ((input.finalidadeEndereco != null) && (input.finalidadeEndereco.idFinalidadeEndereco > 0))
                bd.finalidadeEndereco.idFinalidadeEndereco.value = input.finalidadeEndereco.idFinalidadeEndereco;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.PessoaEnderecoFinalidadeEndereco bd = new Tables.PessoaEnderecoFinalidadeEndereco();

            bd.pessoaEnderecoContatoFinalidade.pessoaEnderecoContato.idPessoaEnderecoContato.value = ((Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"]).idPessoaEnderecoContato;
            bd.finalidadeEndereco.idFinalidadeEndereco.value = ((Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"]).finalidadeEndereco.idFinalidadeEndereco;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
            {
                if
                (
                    !((Tables.PessoaEnderecoFinalidadeEndereco)bd).pessoaEnderecoContatoFinalidade.pessoaEnderecoContato.idPessoaEnderecoContato.isNull &&
                    !((Tables.PessoaEnderecoFinalidadeEndereco)bd).finalidadeEndereco.idFinalidadeEndereco.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.PessoaEnderecoFinalidadeEndereco)input).operacao = ENum.eOperacao.NONE;

                    ((Data.PessoaEnderecoFinalidadeEndereco)input).idPessoaEnderecoContato = ((Tables.PessoaEnderecoFinalidadeEndereco)bd).pessoaEnderecoContatoFinalidade.pessoaEnderecoContato.idPessoaEnderecoContato.value;
                    ((Data.PessoaEnderecoFinalidadeEndereco)input).finalidadeEndereco = (Data.FinalidadeEndereco)(new WS.CRUD.FinalidadeEndereco(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.FinalidadeEndereco(),
                        ((Tables.PessoaEnderecoFinalidadeEndereco)bd).finalidadeEndereco,
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
            Data.PessoaEnderecoFinalidadeEndereco result = (Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"];

            try
            {
                result = (Data.PessoaEnderecoFinalidadeEndereco)this.preencher
                (
                    new Data.PessoaEnderecoFinalidadeEndereco(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.PessoaEnderecoFinalidadeEndereco),
                        new Object[]
                        {
                            result.idPessoaEnderecoContato,
                            result.finalidadeEndereco.idFinalidadeEndereco
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

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecoFinalidadeEndereco input = (Data.PessoaEnderecoFinalidadeEndereco)parametros["Key"];
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
                    typeof(Tables.PessoaEnderecoFinalidadeEndereco),
                    input,
                    _fieldKeys,
                    makeSelectParams
                );

                makeSelectParams.Clear();
                makeSelectParams = null;

                foreach
                (
                    Tables.PessoaEnderecoFinalidadeEndereco _data in
                    (System.Collections.Generic.List<Tables.PessoaEnderecoFinalidadeEndereco>)this.m_EntityManager.list
                    (
                        typeof(Tables.PessoaEnderecoFinalidadeEndereco),
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
                    _base = (Data.Base)this.preencher(new Data.PessoaEnderecoFinalidadeEndereco(), _data, level);

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
