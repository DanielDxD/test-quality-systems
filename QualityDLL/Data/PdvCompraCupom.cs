using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompraCupom : Base
    {
        public PdvCompraCupom() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvCompraCupom;
        public int idPdvCompraCupom
        {
            get { return this.m_IdPdvCompraCupom; }
            set { this.m_IdPdvCompraCupom = value; }
        }

        private PdvCompra m_pdvCompra;
        public PdvCompra pdvCompra
        {
            get { return m_pdvCompra; }
            set { this.m_pdvCompra = value; }
        }

        [
            TFieldAttributeGridDisplay("Data", 255 + 155),
            TFieldAttributeData(50, true)
        ]
        private DateTime m_data;
        public DateTime data
        {
            get { return this.m_data; }
            set { this.m_data = value; }
        }

        private int m_sequenciaCupom;
        public int sequenciaCupom
        {
            get { return this.m_sequenciaCupom; }
            set { this.m_sequenciaCupom = value; }
        }

        private bool m_impresso;
        public bool impresso
        {
            get { return this.m_impresso; }
            set { this.m_impresso = value; }
        }


        [
            TFieldAttributeGridDisplay("Status", 255),
            TFieldAttributeData(50, true)
        ]
        private String m_StatusCupom;
        public String statusCupom
        {
            get { return this.m_StatusCupom; }
            set { this.m_StatusCupom = value; }
        }

        [
            TFieldAttributeGridDisplay("ID Requisição", 255),
            TFieldAttributeData(50, true)
        ]
        private RequisicaoInterna m_requisicaoInterna;
        public RequisicaoInterna requisicaoInterna
        {
            get { return this.m_requisicaoInterna; }
            set { this.m_requisicaoInterna = value; }
        }

        private PdvCompraCupomItem[] m_PdvCompraCupomItem;
        public PdvCompraCupomItem[] pdvCompraCupomItem
        {
            get { return this.m_PdvCompraCupomItem; }
            set { this.m_PdvCompraCupomItem = value; }
        }

        private Funcionario m_idFuncionario;
        public Funcionario funcionario
        {
            get { return this.m_idFuncionario; }
            set { this.m_idFuncionario = value; }
        }

        private Pos m_IdPos;
        public Pos pos
        {
            get { return this.m_IdPos; }
            set { this.m_IdPos = value; }
        }
    }
}
