using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public interface IProvider
    {
        void GetFile(string path);

        void ParseFile(IFileParser fileParser);

    }
}
