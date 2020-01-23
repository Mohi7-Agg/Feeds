using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public interface IFileProvider
    {
        FileInfo GetFile(string path);
    }
}
