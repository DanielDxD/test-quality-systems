using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class BaseModel
    {
        public bool GenerateGrid { get; set; }
        public int startRowIndex { get; set; }
        public int totalRows { get; set; }
        public int idEmpresa { get; set; }
        public int maxRowsPerPage { get; set; }
        public ENum.eOperacao operacao { get; set; }
    }

    public class ResultBase
    {
        public string status { get; set; }
        public int totalRows { get; set; }
        public int maxRowsPerPage { get; set; }
        public int startRowIndex { get; set; }
        public object results { get; set; }
        public GridModel grid { get; set; }
    }
}
