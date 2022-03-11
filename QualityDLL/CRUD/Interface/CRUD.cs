using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for CRUD
/// </summary>

namespace WS.CRUD.Interface
{
    public interface CRUD
    {
        Object atualizar(System.Collections.Hashtable parametros);

        Object consultar(System.Collections.Hashtable parametros);

        Object listar(System.Collections.Hashtable parametros);

        int contar(System.Collections.Hashtable parametros);

        void bancoDeDados(EJB.EntityManager.EntityManager em);
    }
}