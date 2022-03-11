using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class PdvCompraStatus : Base
    {
        public PdvCompraStatus() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdPdvCompraStatus;
        public int idPdvCompraStatus
        {
            get { return this.m_IdPdvCompraStatus; }
            set { this.m_IdPdvCompraStatus = value; }
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

        [
            TFieldAttributeGridDisplay("Status", 255),
            TFieldAttributeData(50, true)
        ]
        private String m_StatusVenda;
        public String statusVenda
        {
            get { return this.m_StatusVenda; }
            set { this.m_StatusVenda = value; }
        }

        private Funcionario m_IdFuncionario;
        public Funcionario funcionario
        {
            get { return this.m_IdFuncionario; }
            set { this.m_IdFuncionario = value; }
        }
    }
}
