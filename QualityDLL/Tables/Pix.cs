using System;
using EJB.Attributes;
using EJB.TableBase;
namespace Tables
{
    [TTable("Pix")]
    public class Pix : TTableBase
    {
        [TColumn("idPix", System.Data.SqlDbType.BigInt, true, true)]
        private TFieldInteger m_IdPix = new TFieldInteger();
        public TFieldInteger idPix
        {
            get { return this.m_IdPix; }
        }

        [TColumn("status", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Status = new TFieldString();
        public TFieldString status
        {
            get { return this.m_Status; }
        }

        [TColumn("expiracao", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Expiracao = new TFieldInteger();
        public TFieldInteger expiracao
        {
            get { return this.m_Expiracao; }
        }

        [TColumn("criacao", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_Criacao = new TFieldDatetime();
        public TFieldDatetime criacao
        {
            get { return this.m_Criacao; }
        }

        [TColumn("dataConciliacaoQuality", System.Data.SqlDbType.DateTime, false, false)]
        private TFieldDatetime m_DataConciliacaoQuality = new TFieldDatetime();
        public TFieldDatetime dataConciliacaoQuality
        {
            get { return this.m_DataConciliacaoQuality; }
        }

        [TColumn("valor", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDecimal m_Valor = new TFieldDecimal();
        public TFieldDecimal valor
        {
            get { return this.m_Valor; }
        }

        [TColumn("chave", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Chave = new TFieldString();
        public TFieldString chave
        {
            get { return this.m_Chave; }
        }

        [TColumn("solicitacaoPagador", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_SolicitacaoPagador = new TFieldString();
        public TFieldString solicitacaoPagador
        {
            get { return this.m_SolicitacaoPagador; }
        }

        [TColumn("location", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Location = new TFieldString();
        public TFieldString location
        {
            get { return this.m_Location; }
        }

        [TColumn("textoImagemQRcode", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_TextoImagemQRcode = new TFieldString();
        public TFieldString textoImagemQRcode
        {
            get { return this.m_TextoImagemQRcode; }
        }

        [TColumn("txid", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_Txid = new TFieldString();
        public TFieldString txid
        {
            get { return this.m_Txid; }
        }

        [TColumn("revisao", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_Revisao = new TFieldInteger();
        public TFieldInteger revisao
        {
            get { return this.m_Revisao; }
        }

        [TColumn("devedorNome", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_DevedorNome = new TFieldString();
        public TFieldString devedorNome
        {
            get { return this.m_DevedorNome; }
        }

        [TColumn("devedorCpfCnpj", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_DevedorCpfCnpj = new TFieldString();
        public TFieldString devedorCpfCnpj
        {
            get { return this.m_DevedorCpfCnpj; }
        }

        [
         TList(typeof(PixTransacao)),
         TJoin(new String[] { "idPix->idPix" })
        ]
        private Object m_PixTransacoes = null;
        public System.Collections.Generic.List<PixTransacao> pixTransacoes
        {
            get
            {
                if (this.m_PixTransacoes != null)
                {
                    if
                    (
                     !typeof(System.Collections.Generic.List<>).MakeGenericType
                     (
                      new Type[] { typeof(PixTransacao) }
                     ).IsInstanceOfType(this.m_PixTransacoes)
                    )
                    {
                        EJB.EntityManager.EntityManager em = (EJB.EntityManager.EntityManager)((EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PixTransacoes)[0])).value;

                        EJB.TableBase.TField[] _keys = new TField[((System.Collections.Generic.List<TBase>)this.m_PixTransacoes).Count - 1];

                        for (int i = 1; i < ((System.Collections.Generic.List<TBase>)this.m_PixTransacoes).Count; i++)
                            _keys[i - 1] = (EJB.TableBase.TField)((EJB.TableBase.TBase)((System.Collections.Generic.List<TBase>)this.m_PixTransacoes)[i]);

                        this.m_PixTransacoes = em.list(typeof(PixTransacao), _keys);
                    }
                    else { }
                }
                else { }

                return (System.Collections.Generic.List<PixTransacao>)this.m_PixTransacoes;
            }
        }


    }
}
