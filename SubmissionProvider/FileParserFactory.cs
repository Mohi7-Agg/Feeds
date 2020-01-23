using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SubmissionProvider.Constants;

namespace SubmissionProvider
{
    public class FileParserFactory
    {
        public IFileParser GetParser(FileType fileType)
        {
            if (fileType == FileType.JSON)
                return new JsonParser();
            else if (fileType == FileType.YAML)
                return new YamlParser();

            return null;

        }
    }
}
