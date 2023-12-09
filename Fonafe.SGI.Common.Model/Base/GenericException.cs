using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Common.Base
{
    public abstract class GenericException<T> : System.Exception, IGenericException
        where T : class
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(T));

        protected GenericException(string message, System.Exception e)
            : base(message, e)
        {

        }

        protected GenericException(System.Exception e)
            : base("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e)
        {

        }

        protected GenericException(string message)
            : base(message)
        {

        }
    }
}
