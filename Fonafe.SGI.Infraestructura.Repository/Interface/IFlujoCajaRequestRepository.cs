using Fonafe.SGI.Domain.Model.Financiera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Repository.Interface
{
  public interface IFlujoCajaRequestRepository
    {
        Task<IList<FlujoCaja>> ListFlujoCaja();
    }
}
