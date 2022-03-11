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
                    ".m_IdPessoa",
                    ".m_IdPessoa.m_CpfCnpj",
                    "m_Matricula"
                }
        ),
        TClassAttributeBusinessIdField("m_IdEmpresa")
    ]
    public class Funcionario : EmpresaRelacionamento
    {
        public Funcionario()
            : base()
        {
        }

        private String m_Cargo;
        public String cargo
        {
            get { return this.m_Cargo; }
            set { this.m_Cargo = value; }
        }

        [
            TFieldAttributeGridDisplay("Matricula", 90),
            TFieldAttributeData(15, false),
        ]
        private String m_Matricula;
        public String matricula
        {
            get { return this.m_Matricula; }
            set { this.m_Matricula = value; }
        }

        private double m_Comissao;
        public double comissao
        {
            get { return this.m_Comissao; }
            set { this.m_Comissao = value; }
        }

        private double m_SalarioBase;
        public double salarioBase
        {
            get { return this.m_SalarioBase; }
            set { this.m_SalarioBase = value; }
        }

        private Data.DepartamentoFuncionario[] m_DepartamentosFuncionario;
        public Data.DepartamentoFuncionario[] departamentosFuncionario
        {
            get { return this.m_DepartamentosFuncionario; }
            set { this.m_DepartamentosFuncionario = value; }
        }

        private int m_IdDepartamentoAtual;
        public int idDepartamentoAtual
        {
            get { return this.m_IdDepartamentoAtual; }
            set { this.m_IdDepartamentoAtual = value; }
        }
        private bool m_Responsavel;
        public bool responsavel
        {
            get { return this.m_Responsavel; }
            set { this.m_Responsavel = value; }
        }

        private DateTime m_DtaInicioDepartamento;
        public DateTime dataInicioDepartamento
        {
            get { return this.m_DtaInicioDepartamento; }
            set { this.m_DtaInicioDepartamento = value; }
        }

        public override string ToString()
        {
            return this.idEmpresaRelacionamento.ToString();
        }
    }
}
