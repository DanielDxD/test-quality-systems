using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class PessoaFisica: Pessoa
	{
		public PessoaFisica(): base()
		{
            this.pfpj = "F";
        }

        [
            TFieldAttributeEditDisplay("Dt Nascimento", 120),
            TFieldAttributeData(10, false)
        ]
		private DateTime m_DataNascimento;
		public DateTime dataNascimento
		{
			get{return this.m_DataNascimento;}
			set{this.m_DataNascimento = value;}
		}

        [
            TFieldAttributeEditDisplay("Sexo", 123),
            TFieldAttributeData(1, true),
            TFieldAttributeSubfield("ItemGenerico:F_Feminino;M_Masculino")
        ]
        private String m_Sexo;
		public String sexo
		{
			get{return this.m_Sexo;}
			set{this.m_Sexo = value;}
		}

        [
            TFieldAttributeEditDisplay("RG-Número", 123),
            TFieldAttributeData(15, false)
        ]
        private String m_RgNumero;
		public String rgNumero
		{
			get{return this.m_RgNumero;}
			set{this.m_RgNumero = value;}
		}

        [
            TFieldAttributeEditDisplay("RG-Emissor", 123),
            TFieldAttributeData(5, false)
        ]
        private String m_RgEmissor;
		public String rgEmissor
		{
			get{return this.m_RgEmissor;}
			set{this.m_RgEmissor = value;}
		}

        [
            TFieldAttributeEditDisplay("RG-Dt Emissão", 123),
            TFieldAttributeData(10, false)
        ]
        private DateTime m_RgDataEmissao;
		public DateTime rgDataEmissao
		{
			get{return this.m_RgDataEmissao;}
			set{this.m_RgDataEmissao = value;}
		}

        [
            TFieldAttributeEditDisplay("TE-Número", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_TeNumero;
		public String teNumero
		{
			get{return this.m_TeNumero;}
			set{this.m_TeNumero = value;}
		}

        [
            TFieldAttributeEditDisplay("TE-Zona", 123),
            TFieldAttributeData(5, false)
        ]
        private int m_TeZona;
		public int teZona
		{
			get{return this.m_TeZona;}
			set{this.m_TeZona = value;}
		}

        [
            TFieldAttributeEditDisplay("TE-Seção", 123),
            TFieldAttributeData(5, false)
        ]
        private int m_TeSecao;
		public int teSecao
		{
			get{return this.m_TeSecao;}
			set{this.m_TeSecao = value;}
		}

        [
            TFieldAttributeEditDisplay("CNH", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_CnhNumero;
		public String cnhNumero
		{
			get{return this.m_CnhNumero;}
			set{this.m_CnhNumero = value;}
		}

        [
            TFieldAttributeEditDisplay("Reservista", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_ReservistaNumero;
		public String reservistaNumero
		{
			get{return this.m_ReservistaNumero;}
			set{this.m_ReservistaNumero = value;}
		}

        [
            TFieldAttributeEditDisplay("Profissao", 123),
            TFieldAttributeData(15, false)
        ]
        private String m_ProfissaoNome;
		public String profissaoNome
		{
			get{return this.m_ProfissaoNome;}
			set{this.m_ProfissaoNome = value;}
		}

        [
            TFieldAttributeEditDisplay("CTPS", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_Ctps;
		public String ctps
		{
			get{return this.m_Ctps;}
			set{this.m_Ctps = value;}
		}

        [
            TFieldAttributeEditDisplay("PIS/PASEP", 123),
            TFieldAttributeData(20, false)
        ]
        private String m_Pispasep;
		public String pispasep
		{
			get{return this.m_Pispasep;}
			set{this.m_Pispasep = value;}
		}

        [
            TFieldAttributeEditDisplay("Estado Civil", 123),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idEstadoCivil:descricao")
        ]
        private EstadoCivil m_IdEstadoCivil;
		public EstadoCivil estadoCivil
		{
			get{return this.m_IdEstadoCivil;}
			set{this.m_IdEstadoCivil = value;}
		}

        [
            TFieldAttributeEditDisplay("Escolaridade", 123),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idEscolaridade:descricao")
        ]
        private Escolaridade m_IdEscolaridade;
		public Escolaridade escolaridade
		{
			get{return this.m_IdEscolaridade;}
			set{this.m_IdEscolaridade = value;}
		}

        [
            TFieldAttributeEditDisplay("Naturalidade", 123),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idCidade:descricao")
        ]
        private Cidade m_IdCidadeNaturalidade;
		public Cidade cidadeNaturalidade
		{
			get{return this.m_IdCidadeNaturalidade;}
			set{this.m_IdCidadeNaturalidade = value;}
        }

        [
            TFieldAttributeEditDisplay("Profissão", 123),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idProfissao:descricao")
        ]
        private Profissao m_IdProfissao;
        public Profissao profissao
        {
            get { return this.m_IdProfissao; }
            set { this.m_IdProfissao = value; }
        }

        [
            TFieldAttributeEditDisplay("Nacionalidade", 123),
            TFieldAttributeData(6, false),
            TFieldAttributeSubfield("idNacionalidade:descricao")
        ]
        private Nacionalidade m_IdNacionalidade;
        public Nacionalidade nacionalidade
        {
            get { return this.m_IdNacionalidade; }
            set { this.m_IdNacionalidade = value; }
        }

        public override string ToString()
        {
            return this.idPessoa.ToString();
        }
    }
}
