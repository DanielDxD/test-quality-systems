using System;
using System.Data;

namespace Data
{
    //[Serializable]
    public class MovimentoFiscalFila : Base
    {

        public MovimentoFiscalFila() : base()
        {
        }

        private int m_IdMovimentoFiscalFila;
        public int idMovimentoFiscalFila
        {
            get { return this.m_IdMovimentoFiscalFila; }
            set { this.m_IdMovimentoFiscalFila = value; }
        }

        private PdvCompra m_IdPdvCompra;
        public PdvCompra pdvCompra
        {
            get { return this.m_IdPdvCompra; }
            set { this.m_IdPdvCompra = value; }
        }

        private string m_StatusNfc;
        public String statusNfc
        {
            get { return this.m_StatusNfc; }
            set { this.m_StatusNfc = value; }
        }

        private int m_Ordem;
        public int ordem
        {
            get { return this.m_Ordem; }
            set { this.m_Ordem = value; }
        }

        public MovimentoFiscalFila AdicionarFila()
        {
            if (this.m_IdPdvCompra != null && this.m_IdPdvCompra.idPdvCompra > 0)
            {
                DataTable results = Utils.Utils.em.executeData(@"DECLARE
	@idPdvCompra INT = " + this.m_IdPdvCompra.idPdvCompra + @"

IF NOT EXISTS(SELECT 1 FROM movimentoFiscalFila WHERE idPdvCompra = @idPdvCompra AND statusNfc = 'pendente')
BEGIN
    DECLARE
        @proxOrdem INT = (SELECT IsNull(MAX(ordem), 0) + 1 FROM movimentoFiscalFila WHERE statusNfc = 'pendente')
    if @proxOrdem > 0
    BEGIN
        INSERT INTO movimentoFiscalFila(idPdvCompra, ordem, statusNfc) values(@idPdvCompra, @proxOrdem, 'pendente')
        SELECT IDENT_CURRENT('movimentoFiscalFila') AS idMovimentoFiscalFila, @idPdvCompra AS idPdvCompra, @proxOrdem AS ordem
    END
end
ELSE
    SELECT* FROM movimentoFiscalFila WHERE idPdvCompra = @idPdvCompra AND statusNfc = 'pendente'", null);

                if (results != null && results.Rows.Count > 0)
                {
                    MovimentoFiscalFila fila = new MovimentoFiscalFila
                    {
                        idMovimentoFiscalFila = Convert.ToInt32(results.Rows[0][0]),
                        pdvCompra = pdvCompra,
                        ordem = Convert.ToInt32(results.Rows[0][2])
                    };
                    return fila;
                }
            }
            return null;
        }

        public void AtualizaFila()
        {
            Utils.Utils.em.executeData("DELETE FROM movimentoFiscalFila WHERE idPdvCompra = " + this.m_IdPdvCompra.idPdvCompra.ToString() + " AND statusNfc = 'pendente'", null);
            Utils.Utils.em.executeData("UPDATE movimentoFiscalFila SET ordem = (ordem - 1) AND statusNfc = 'pendente'", null);
        }

        public void AtualizaFilaErro()
        {
            Utils.Utils.em.executeData("UPDATE movimentoFiscalFila SET statusNfc = 'erro' WHERE idPdvCompra = " + this.m_IdPdvCompra.idPdvCompra.ToString() + " AND statusNfc = 'pendente'", null);
            Utils.Utils.em.executeData("UPDATE movimentoFiscalFila SET ordem = IsNull((SELECT IsNull(MAX(ordem), 0) FROM movimentoFiscalFila WHERE statusNfc = 'erro'), 0) + 1 WHERE idPdvCompra = " + this.m_IdPdvCompra.idPdvCompra.ToString(), null);
        }

        public int GetOrdem()
        {
            DataTable results = Utils.Utils.em.executeData("SELECT ordem FROM movimentoFiscalFila WHERE idPdvCompra = " + this.m_IdPdvCompra.idPdvCompra.ToString() + " AND statusNfc = 'pendente'", null);
            if (results != null && results.Rows.Count > 0)
                return Convert.ToInt32(results.Rows[0][0].ToString());

            this.AdicionarFila();
            return this.GetOrdem();
        }
    }
}
