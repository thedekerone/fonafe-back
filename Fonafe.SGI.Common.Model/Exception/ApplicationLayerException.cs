using Fonafe.SGI.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Common.Exception
{
    public class ApplicationLayerException<T> : GenericException<T>
        where T : class
    {
        public bool IsCustomException { get; set; }
        public ApplicationLayerException(string message, System.Exception e) : base(message, e) { }
        public ApplicationLayerException(System.Exception e) : base(e) { }
        public ApplicationLayerException(string message)
            : base(message)
        {
            this.IsCustomException = true;
        }
    }
}
