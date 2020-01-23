using SubmissionProvider.DataModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SubmissionProvider
{
    public class YamlParser: IFileParser
    {
        public object ParseFile (string path)
        {
            using (var r = new StreamReader(path))
            {
                return new Deserializer().Deserialize(r);
            }
                

        }
    }
}
