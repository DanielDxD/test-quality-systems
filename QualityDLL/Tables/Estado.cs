using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Estado")]
	public class Estado: TTableBase
	{
		[TColumn("idEstado", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idEstado = new TFieldInteger();
		public TFieldInteger idEstado
		{
			get{return this.m_idEstado;}
		}

		[TColumn("uf", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_uf = new TFieldString();
		public TFieldString uf
		{
			get{return this.m_uf;}
        }

        [TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_descricao = new TFieldString();
        public TFieldString descricao
        {
            get { return this.m_descricao; }
        }


        [TColumn("aliquotaInter", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaInter = new TFieldDouble();
        public TFieldDouble aliquotaInter
        {
            get { return this.m_aliquotaInter; }
        }

        [TColumn("aliquotaIntra", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_aliquotaIntra = new TFieldDouble();
        public TFieldDouble aliquotaIntra
        {
            get { return this.m_aliquotaIntra; }
        }

        [TColumn("fcp", System.Data.SqlDbType.Decimal, false, false)]
        private TFieldDouble m_fcp = new TFieldDouble();
        public TFieldDouble fcp
        {
            get { return this.m_fcp; }
        }

        [
            TColumn("idPais", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idPais->idPais"})
		]
		private Pais m_idPais = null;
		public Pais pais
		{
			get
			{
				if(this.m_idPais == null)
				{
                    this.m_idPais = new Pais();

					foreach (TJoin attribute in this.m_idPais.GetType().GetCustomAttributes(typeof(TJoin), false))
					{
						System.Collections.Generic.List<Object> _keys = new System.Collections.Generic.List<object>();

						bool existNullKey = false;

						for (int i = 0; i < attribute.count; i++)
						{
                            if (this.fieldByColumnName(attribute.column(i)).isNull)
								existNullKey = true;
							else
                                _keys.Add(this.fieldByColumnName(attribute.column(i)));
						}

						if (!existNullKey)
						{
							this.m_idPais.connectionString = this.connectionString;
							this.m_idPais.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPais.selfFill();

				return this.m_idPais;
			}
		}
	}
}
