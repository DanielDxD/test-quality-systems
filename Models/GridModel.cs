using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Prova.Models
{
    public class GridModel
    {
        public string key { get; set; }
        private List<GridColumnModel> m_Columns { get; set; }
        public List<GridColumnModel> columns { get { return this.m_Columns; } set { this.m_Columns = value; } }

        public void AddColumn(Field field)
        {
            if (field != null && !String.IsNullOrEmpty(field.name))
            {
                if (((field.editDisplayText + field.gridDisplayText).Length == 0))
                    return;
                else { }

                if (this.columns == null)
                    this.columns = new List<GridColumnModel>();
                else { }

                GridColumnModel _cl = null;
                try
                {
                    _cl = this.columns.Where(T => T.name == field.name).ToList()[0];
                }
                catch
                {
                    int max = 0;
                    try
                    {
                        max = this.columns.Max(T => T.order);
                    }
                    catch { }

                    string subField = field.subFieldName;
                    if (!String.IsNullOrEmpty(subField))
                        subField = subField.Split(':')[1].Replace(".", "-");

                    _cl = new GridColumnModel
                    {
                        key = field.key,
                        name = field.name,
                        descricao = field.gridDisplayText,
                        format = field.viewFormat,
                        order = max + 1,
                        subField = (!String.IsNullOrEmpty(subField) && subField.Length > 0 ? field.name + "-" + subField : field.name),
                        showField = field.showField
                    };
                    this.columns.Add(_cl);
                }
            }
        }
    }

}
