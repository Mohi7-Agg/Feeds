using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public static class Constants
    {
        public enum ProviderEnum
        {
            Capterra,
            SoftwareAdvice
        }

        public enum FileType
        {
            JSON, YAML
        }

        public enum SourceType
        {
            DIRECTORY, WEB
        }
    }
}
