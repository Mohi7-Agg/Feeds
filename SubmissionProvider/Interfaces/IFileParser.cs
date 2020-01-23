using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public interface IFileParser
    {
        object ParseFile (string path);
    }
}
