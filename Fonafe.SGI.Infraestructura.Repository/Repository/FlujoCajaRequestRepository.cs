using Fonafe.SGI.Domain.Model.Financiera;
using Fonafe.SGI.Domain.Repository.Interface;
using Fonafe.SGI.Infraestructura.Const;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.BigQuery.V2;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Repository.Repository
{
    public class FlujoCajaRequestRepository : IFlujoCajaRequestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _idProyectString;
        public FlujoCajaRequestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
           _connectionString = _configuration["AppSettings:ConnectionString"];
           _connectionString = _configuration["ASPNETCORE_IIS_PHYSICAL_PATH"]+ _connectionString;
           _idProyectString = _configuration["AppSettings:IdProyectoString"];
        }

        public async Task<IList<FlujoCaja>> ListFlujoCaja()
        {
            List<FlujoCaja> listEntidad = new List<FlujoCaja>();
            FlujoCaja objEntidad;
            var commandCredential = GoogleCredential.FromFile(_connectionString);
            using (var bigQueryClient = await BigQueryClient.CreateAsync(_idProyectString, commandCredential))
            {
                string query = EmpresaFinancieraConst.GET_FLUJO_CAJA;
                IEnumerable<BigQueryParameter> prm = null;
                BigQueryResults result = await bigQueryClient.ExecuteQueryAsync(query, prm);
                await foreach (var row in result.GetRowsAsync())
                {
                    objEntidad = new FlujoCaja();
                    objEntidad.Empresa = row["Empresa"].ToString();
                    objEntidad.A__o = row["A__o"].ToString();
                    objEntidad.Mes = row["Mes"].ToString();
                    objEntidad.Operativo = row["Operativo"].ToString();
                    objEntidad.Acum = row["Acum"].ToString();
                    listEntidad.Add(objEntidad);
                }
            }
            return listEntidad;
        }
    }
}


