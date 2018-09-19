using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundamentalsProject.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class GggGenericException : Exception
    {
        public GggGenericException(Exception exception)
        {
            throw new Exception("GggGenericException", exception);
        }
    }
}
