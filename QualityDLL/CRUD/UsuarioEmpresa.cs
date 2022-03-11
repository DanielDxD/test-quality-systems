using System;

namespace WS.CRUD
{
    public class UsuarioEmpresa : WS.CRUD.Base
    {
        public UsuarioEmpresa(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }

        public override Object incluir(System.Collections.Hashtable parametros)
        {
            Data.UsuarioEmpresa input = (Data.UsuarioEmpresa)parametros["Key"];
            Tables.UsuarioEmpresa bd = new Tables.UsuarioEmpresa();

            if (input.idUsuario != null)
                bd.idUsuario.idUsuario.value = input.idUsuario.idUsuario;
            else { }
            if (input.idEmpresa != null)
                bd.idEmpresa.idEmpresa.value = input.idEmpresa.idEmpresa;
            else { }

            this.m_EntityManager.persist(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override Object alterar(System.Collections.Hashtable parametros)
        {
            Data.UsuarioEmpresa input = (Data.UsuarioEmpresa)parametros["Key"];
            Tables.UsuarioEmpresa bd = (Tables.UsuarioEmpresa)this.m_EntityManager.find
            (
                typeof(Tables.UsuarioEmpresa),
                new Object[]
                {
                    input.idUsuario.idUsuario,
                    input.idEmpresa.idEmpresa
                }
            );

            if (input.idUsuario != null)
                bd.idUsuario.idUsuario.value = input.idUsuario.idUsuario;
            else { }
            if (input.idEmpresa != null)
                bd.idEmpresa.idEmpresa.value = input.idEmpresa.idEmpresa;
            else { }

            this.m_EntityManager.merge(bd);

            return input; //this.preencher(input, bd, 0);
        }

        public override void excluir(System.Collections.Hashtable parametros)
        {
            Tables.UsuarioEmpresa bd = new Tables.UsuarioEmpresa();

            bd.idUsuario.idUsuario.value = ((Data.UsuarioEmpresa)parametros["Key"]).idUsuario.idUsuario;
            bd.idEmpresa.idEmpresa.value = ((Data.UsuarioEmpresa)parametros["Key"]).idEmpresa.idEmpresa;
            this.m_EntityManager.remove(bd);
        }

        public override Object preencher(Data.Base input, EJB.TableBase.TTableBase bd, int level)
        {
            if (bd != null)
                if
                (
                    !((Tables.UsuarioEmpresa)bd).idUsuario.idUsuario.isNull &&
                    !((Tables.UsuarioEmpresa)bd).idEmpresa.idEmpresa.isNull
                )
                {
                    //
                    //Dados Basicos
                    //
                    ((Data.UsuarioEmpresa)input).operacao = ENum.eOperacao.NONE;

                    ((Data.UsuarioEmpresa)input).idUsuario = (Data.Usuario)(new WS.CRUD.Usuario(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Usuario(),
                        ((Tables.UsuarioEmpresa)bd).idUsuario,
                        level + 1
                    );
                    ((Data.UsuarioEmpresa)input).idEmpresa = (Data.Empresa)(new WS.CRUD.Empresa(this.m_IdEmpresaCorrente, this.m_EntityManager)).preencher
                    (
                        new Data.Empresa(),
                        ((Tables.UsuarioEmpresa)bd).idEmpresa,
                        level + 1
                    );
                }
                else { }
            else { }

            return input;
        }

        public override Object consultar(System.Collections.Hashtable parametros)
        {
            Data.UsuarioEmpresa result = (Data.UsuarioEmpresa)parametros["Key"];

            try
            {
                result = (Data.UsuarioEmpresa)this.preencher
                (
                    new Data.UsuarioEmpresa(),
                    this.m_EntityManager.find
                    (
                        typeof(Tables.UsuarioEmpresa),
                        new Object[]
                        {
                            result.idUsuario.idUsuario,
                            result.idEmpresa.idEmpresa
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
    }
}
