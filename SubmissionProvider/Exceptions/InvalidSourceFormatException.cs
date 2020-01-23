using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider.Exceptions
{
    public class InvalidSourceFormatException : Exception
    {
        public InvalidSourceFormatException(string msg)
        {
            throw new Exception(msg);
        }        
    }
}
