using Fonafe.SGI.Common;
using Fonafe.SGI.Common.Exception;
using Fonafe.SGI.Domain.Model.Financiera;
using Fonafe.SGI.Domain.Repository.Interface;
using Fonafe.SGI.Domain.Repository.Repository;
using Fonafe.SGI.Domain.Service.Inteface.Financial;
using Microsoft.Extensions.Configuration;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Service.Service.Financial
{
    public class FlujoCajaRequestService : IFlujoCajaRequestService
    {
        private readonly IFlujoCajaRequestRepository _iflujoCajaRequestRepository;
       // private readonly IConfiguration _configuration;
        public FlujoCajaRequestService(IConfiguration _configuration)
        {
            _iflujoCajaRequestRepository = new FlujoCajaRequestRepository(_configuration);
        }

        public async Task<ProcessResult<List<FlujoCaja>>> ListFlujoCaja(FlujoCaja obj)
        {
            var resultadoProceso = new ProcessResult<List<FlujoCaja>>();
            try
            {
                var lista = await _iflujoCajaRequestRepository.ListFlujoCaja();
                resultadoProceso.Result = lista.ToList();
            }
            catch (Exception ex)
            {
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<FlujoCajaRequestService>(ex);
            }
            return resultadoProceso;
        }

    }
}
