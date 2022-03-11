using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class Perfil : Base
    {
        public Perfil() : base()
        {
        }

        [
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeEditDisplay("ID", 80),
            TFieldAttributeData(6, true),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPerfil;
        public int idPerfil
        {
            get { return this.m_IdPerfil; }
            set { this.m_IdPerfil = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 295),
            TFieldAttributeEditDisplay("Descrição", 80),
            TFieldAttributeData(50, true),
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("Administrador", 120),
            TFieldAttributeEditDisplay("Administrador", 80),
            TFieldAttributeData(4, true),
            TFieldAttributeFormat("checkbox", "checkbox")
        ]
        private bool m_Administrador;
        public bool administrador
        {
            get { return this.m_Administrador; }
            set { this.m_Administrador = value; }
        }

        //idPerfil
        private PerfilMenu[] m_PerfilMenus;
        public PerfilMenu[] perfilMenus
        {
            get { return this.m_PerfilMenus; }
            set { this.m_PerfilMenus = value; }
        }

        private RelatorioPerfil[] m_RelatorioPerfil;
        public RelatorioPerfil[] relatorioPerfil
        {
            get { return this.m_RelatorioPerfil; }
            set { this.m_RelatorioPerfil = value; }
        }

        public override string ToString()
        {
            return this.idPerfil.ToString();
        }
    }
}
