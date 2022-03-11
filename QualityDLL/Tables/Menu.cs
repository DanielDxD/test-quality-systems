using System;
using EJB.Attributes;
using EJB.TableBase;

namespace Tables
{
	[TTable("Menu")]
	public class Menu: TTableBase
	{
		[TColumn("idMenu", System.Data.SqlDbType.Int, true, true)]
		private TFieldInteger m_idMenu = new TFieldInteger();
		public TFieldInteger idMenu
		{
			get{return this.m_idMenu;}
		}

		[TColumn("descricao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_descricao = new TFieldString();
		public TFieldString descricao
		{
			get{return this.m_descricao;}
		}

		[TColumn("opcao", System.Data.SqlDbType.VarChar, false, false)]
		private TFieldString m_opcao = new TFieldString();
		public TFieldString opcao
		{
			get{return this.m_opcao;}
		}

		[TColumn("ordem", System.Data.SqlDbType.Int, false, false)]
		private TFieldInteger m_ordem = new TFieldInteger();
		public TFieldInteger ordem
		{
			get{return this.m_ordem;}
		}

        [TColumn("arquivoImagem", System.Data.SqlDbType.VarChar, false, false)]
        private TFieldString m_ArquivoImagem = new TFieldString();
        public TFieldString arquivoImagem
        {
            get { return this.m_ArquivoImagem; }
        }

        [TColumn("idMenuPai", System.Data.SqlDbType.Int, false, false)]
        private TFieldInteger m_idMenuPai = new TFieldInteger();
        public TFieldInteger idMenuPai
        {
            get { return this.m_idMenuPai; }
        }

		[
			TColumn("idPagina", System.Data.SqlDbType.Int, false, false),
			TJoin(new String[]{"idPagina->idPagina"})
		]
		private Pagina m_idPagina = null;
		public Pagina pagina
		{
			get
			{
				if(this.m_idPagina == null)
				{
                    this.m_idPagina = new Pagina();

					foreach (TJoin attribute in this.m_idPagina.GetType().GetCustomAttributes(typeof(TJoin), false))
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
							this.m_idPagina.connectionString = this.connectionString;
							this.m_idPagina.keyFields = _keys.ToArray();
						}
						else { }
					}
				}
				else { }

				this.m_idPagina.selfFill();

				return this.m_idPagina;
			}
		}
	}
}
