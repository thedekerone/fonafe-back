using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Model.Financiera
{
    public class FlujoCaja
    {
        public int idFlujoCaja { get; set; }
        public string Empresa { get; set; }
        public string A__o { get; set; }
        public string Mes { get; set; }
        public string Operativo { get; set; }
        public string Acum { get; set; }
    }
}
