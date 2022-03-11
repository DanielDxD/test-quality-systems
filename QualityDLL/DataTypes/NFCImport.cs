using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class NFCImport : Data.NotaFiscalE
    {
        public new List<Produtos> notaFiscalEItems { get; set; }
    }

    public class Produtos : Data.NotaFiscalEItem
    {
        public bool isMissing { get; set; }
        public string novoCodigoNfe { get; set; }
    }
}
