using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    [
        TClassAttributeFields
        (
            new String[]
                {
                    ".m_IdEmpresaRelacionamento",
                    ".m_IdPessoa"
                }
        ),
        TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class Convidado : EmpresaRelacionamento
    {
        public Convidado() : base()
        {
        }

    }
}
