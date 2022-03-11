using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{

    public class GridColumnModel
    {
        public bool key { get; set; }
        public string name { get; set; }
        public string descricao { get; set; }
        public string format { get; set; }
        public string subField { get; set; }
        public int order { get; set; }
        public bool showField { get; set; }
    }
}
