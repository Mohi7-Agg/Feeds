using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public class FileProvider : IFileProvider
    {
        public FileInfo GetFile(string path)
        {
            FileInfo fInfo = new FileInfo(path);
            return fInfo;
        }
    }
}
