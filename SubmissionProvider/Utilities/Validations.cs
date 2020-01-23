using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider.Utilities
{
    public static class Validations
    {
        public static bool ValidateSource(string source)
        {
            string[] sourceArr = source.Split(',');
            if (sourceArr.Length != 2)
                return false;

            return true;
        }
    }
}
