using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class RelatorioSql : Base
    {
        public RelatorioSql() : base()
        {
        }

        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55),
            TFieldAttributeKey(true, true)
        ]
        private int m_IdRelatorioSql;
        public int idRelatorioSql
        {
            get { return this.m_IdRelatorioSql; }
            set { this.m_IdRelatorioSql = value; }
        }

        [
            TFieldAttributeGridDisplay("Descrição", 255 + 155),
            TFieldAttributeData(50, true)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }

        [
            TFieldAttributeGridDisplay("", 0),
            TFieldAttributeData(6, true),
        ]
        private string m_Consulta;
        public string consulta
        {
            get { return this.m_Consulta; }
            set { this.m_Consulta = value; }
        }

        private RelatorioSqlFiltros m_Filtro;
        public RelatorioSqlFiltros filtro
        {
            get { return this.m_Filtro; }
            set { this.m_Filtro = value; }
        }

        private RelatorioSqlFiltros[] m_Filtros;
        public RelatorioSqlFiltros[] filtros
        {
            get { return this.m_Filtros; }
            set { this.m_Filtros = value; }
        }

        public override string ToString()
        {
            return this.m_IdRelatorioSql.ToString();
        }
    }
}
