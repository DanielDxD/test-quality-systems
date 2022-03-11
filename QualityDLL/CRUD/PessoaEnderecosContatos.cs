using System;

namespace WS.CRUD
{
    public class PessoaEnderecosContatos : WS.CRUD.Base
    {
        public PessoaEnderecosContatos(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object listar(System.Collections.Hashtable parametros)
        {
            Data.PessoaEnderecosContatos input = (Data.PessoaEnderecosContatos)parametros["Key"];
            System.Collections.Generic.List<Data.Base> result = new System.Collections.Generic.List<Data.Base>();
            string mode = (string)(parametros["Mode"] == null ? "" : parametros["Mode"]);
            int level = (int)(parametros["Level"] == null ? 0 : parametros["Level"]);

            System.Collections.Hashtable makeSelectParams = new System.Collections.Hashtable();
            makeSelectParams["numRows"] = (parametros["Top"] == null ? 0 : (int)parametros["Top"]);
            makeSelectParams["where"] = (parametros["Filter"] == null ? "" : (String)parametros["Filter"]);
            makeSelectParams["orderBy"] = (parametros["Order"] == null ? "" : (String)parametros["Order"]);
            makeSelectParams["offSet"] = (parametros["Offset"] == null ? -1 : parametros["Offset"]);

            Report.Base report = (Report.Base)parametros["Report"];

            parametros["Key"] = new Data.PessoaEnderecoContato { idPessoa = input.idPessoa };

            WS.CRUD.PessoaEnderecoContato pessoaEnderecoContatoCRUD = new WS.CRUD.PessoaEnderecoContato(this.m_IdEmpresaCorrente, this.m_EntityManager);

            try
            {
                Data.PessoaEnderecosContatos pecs = new Data.PessoaEnderecosContatos { idPessoa = input.idPessoa };

                System.Collections.Generic.List<Data.EnderecoContato> ecs = new System.Collections.Generic.List<Data.EnderecoContato>();

                foreach (Data.PessoaEnderecoContato pec in (Data.Base[])pessoaEnderecoContatoCRUD.listar(parametros))
                {
                    Data.EnderecoContato ec = new Data.EnderecoContato { tipo = pec.tipoEnderecoContato };

                    ec.endereco = pec.pessoaEndereco;

                    if ((ec.endereco.logradouro == null) || ((ec.endereco.logradouro != null) && (ec.endereco.logradouro.idLogradouro == 0)))
                        ec.endereco.logradouro = ec.endereco.endereco.logradouro;
                    else { }

                    if ((ec.endereco.bairro == null) || ((ec.endereco.bairro != null) && (ec.endereco.bairro.idBairro == 0)))
                        ec.endereco.bairro = ec.endereco.endereco.bairro;
                    else { }

                    ec.contato = pec.pessoaContato;

                    ecs.Add(ec);
                }

                pecs.enderecosContatos = ecs.ToArray();
                result.Add(pecs);
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
