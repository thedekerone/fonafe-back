using System;
using System.Text;

namespace Fonafe.SGI.Infraestructura.Const
{
    public class EmpresaFinancieraConst
    {

        public static string GET_FLUJO_CAJA = selFlujoCaja();

        static string selFlujoCaja()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT Empresa,A__o, Mes, Operativo, Acum ").
            Append(" FROM").
            Append(" `pe-gob-fonafe-rdv-01-noprd.oracle_fonafeweb_raw.flujo_caja` f").
             Append(" limit 200");
            //Append(" WHERE").
            //Append(" f.Empresa = ?");
            return sql.ToString();
        }
    }
}
