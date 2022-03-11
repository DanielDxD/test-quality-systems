using System;

namespace WS.CRUD
{
    public class ConfiguracoesGlobais : WS.CRUD.Base
    {
        public ConfiguracoesGlobais(long? idEmpresa, EJB.EntityManager.EntityManager entityManager)
            : base(idEmpresa, entityManager)
        {
        }
    }
}
