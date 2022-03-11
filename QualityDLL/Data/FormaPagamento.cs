using System;
using Utils.Pagina.Attributes;

namespace Data
{
	//[Serializable]
	public class FormaPagamento: Base
	{
		public FormaPagamento(): base()
		{
		}

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeData(6, true)
        ]
        private int m_IdFormaPagamento;
		public int idFormaPagamento
		{
			get{return this.m_IdFormaPagamento;}
			set{this.m_IdFormaPagamento = value;}
		}

        [
            TFieldAttributeGridDisplay("Descrição", 280),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
		public String descricao
		{
			get{return this.m_Descricao;}
			set{this.m_Descricao = value;}
        }

        [
            TFieldAttributeGridDisplay("Tipo", 123),
            TFieldAttributeData(2, true),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;1_Dinheiro;2_Cartão de Crédito;3_Cartão de Débito;4_Cheque à vista;5_Cheque Pré-Datado;51_Cartão Pré-Pago;52_Cartao Pós-Pago")
        ]
        private int m_Tipo;
        public int tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        [
            TFieldAttributeGridDisplay("Código Fiscal", 123),
            TFieldAttributeData(2, false),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;1_1 - Dinheiro;2_2 - Cheque;3_3 - Cartão de Crédito;4_4 - Cartão de Débito;5_5 - Crédito da Loja;10_10 - Vale Alimentação;11_11 - Vale Refeição;12_12 - Vale Presente;13_13 - Vale Combustível;14_14 - Duplicata Mercantil;15_15 - Boleto Bancário;90_90 - Sem Pagamento;99_99 - Outro")
        ]
        private int m_CodigoFiscal;
        public int codigoFiscal
        {
            get { return this.m_CodigoFiscal; }
            set { this.m_CodigoFiscal = value; }
        }

        [
            TFieldAttributeGridDisplay("Bandeira do Cartão", 130),
            TFieldAttributeData(2, false),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;1_Visa;2_MasterCard;3_American Express;4_SoroCred;5_Diners Club;6_Elo;7_HiperCard;8_Aura;9_Cabal;99_Outro")
        ]
        private int m_IdBandeiraCartao;
        public int idBandeiraCartao
        {
            get { return this.m_IdBandeiraCartao; }
            set { this.m_IdBandeiraCartao = value; }
        }

        [
            TFieldAttributeGridDisplay("Habilitar Valor Digitado", 150),
            TFieldAttributeData(2, false),
            TFieldAttributeSubfield("ItemGenerico:_Selecione;1_Sim;0_Não")
        ]
        private string m_HabilitarValorDigitadoFechamento;
        public string habilitarValorDigitadoFechamento
        {
            get { return this.m_HabilitarValorDigitadoFechamento; }
            set { this.m_HabilitarValorDigitadoFechamento = value; }
        }

        public override string ToString()
        {
            return this.m_IdFormaPagamento.ToString();
        }
    }
}
