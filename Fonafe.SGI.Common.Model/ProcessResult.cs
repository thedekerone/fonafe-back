
using Fonafe.SGI.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Common
{
    public class ProcessResult<T> where T : class
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ProcessResult()
        {
            this.IsSuccess = true;

        }
        /// <summary>
        /// Indicador del estado de la operación
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// Excepción generada en caso de error
        /// </summary>
        public IGenericException Exception { get; set; }
        /// <summary>
        /// Resultado del proceso
        /// </summary>
        public T Result { get; set; }
    }
}
