using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SubmissionProvider
{
    public class JsonParser : IFileParser
    {
        public object ParseFile (string path)
        {
            string data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject(data);
           
        }
    }
}
