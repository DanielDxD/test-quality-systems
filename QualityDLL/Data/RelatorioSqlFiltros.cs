using System;
using Utils.Pagina.Attributes;

namespace Data
{
    //[Serializable]
    public class RelatorioSqlFiltros : Base
    {
        public RelatorioSqlFiltros()
            : base()
        {
        }

        [
            TFieldAttributeKey(true, true),
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID", 55)
        ]
        private int m_IdRelatorioSqlFiltro;
        public int idRelatorioSqlFiltro
        {
            get { return this.m_IdRelatorioSqlFiltro; }
            set { this.m_IdRelatorioSqlFiltro = value; }
        }


        [
            TFieldAttributeData(6, true),
            TFieldAttributeGridDisplay("ID Relatório", 55)
        ]
        private int m_IdRelatorioSql;
        public int idRelatorioSql
        {
            get { return this.m_IdRelatorioSql; }
            set { this.m_IdRelatorioSql = value; }
        }

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Descrição", 270)
        ]
        private String m_Descricao;
        public String descricao
        {
            get { return this.m_Descricao; }
            set { this.m_Descricao = value; }
        }


        private String m_orderCampos;
        public String orderCampos
        {
            get { return this.m_orderCampos; }
            set { this.m_orderCampos = value; }
        }


        private String m_filterCampos;
        public String filterCampos
        {
            get { return this.m_filterCampos; }
            set { this.m_filterCampos = value; }
        }

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("Tipo", 270)
        ]
        private String m_Tipo;
        public String tipo
        {
            get { return this.m_Tipo; }
            set { this.m_Tipo = value; }
        }

        [
            TFieldAttributeData(50, true),
            TFieldAttributeGridDisplay("KeyValue", 270)
        ]
        private String m_KeyValue;
        public String keyValue
        {
            get { return this.m_KeyValue; }
            set { this.m_KeyValue = value; }
        }

        [
           TFieldAttributeData(50, true),
           TFieldAttributeGridDisplay("classBase", 270)
       ]
        private String m_ClassBase;
        public String classBase
        {
            get { return this.m_ClassBase; }
            set { this.m_ClassBase = value; }
        }

        [
           TFieldAttributeData(50, true),
           TFieldAttributeGridDisplay("campos", 270)
        ]
        private String m_Campos;
        public String campos
        {
            get { return this.m_Campos; }
            set { this.m_Campos = value; }
        }
        
        private bool m_Required;
        public bool required
        {
            get { return this.m_Required; }
            set { this.m_Required = value; }
        }
    }
}