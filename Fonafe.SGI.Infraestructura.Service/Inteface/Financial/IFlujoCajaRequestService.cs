using Fonafe.SGI.Common;
using Fonafe.SGI.Domain.Model.Financiera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Service.Inteface.Financial
{
   public interface IFlujoCajaRequestService
    {
        Task<ProcessResult<List<FlujoCaja>>> ListFlujoCaja(FlujoCaja obj);
    }
}
