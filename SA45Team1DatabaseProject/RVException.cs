using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA45Team1DatabaseProject
{
    class RVException : ApplicationException
    {
        public RVException() : base()    {
        }

        public RVException(string message) : base(message)   {
        }

        public RVException(string message, Exception innerExc) 
            : base(message, innerExc)   {
        }

    }
}
