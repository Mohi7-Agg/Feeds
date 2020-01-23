using SubmissionProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider
{
    public sealed class ConsoleLogger : ILogger
    {
        private static ConsoleLogger _instance;

        private static Object obj = new object();
        private ConsoleLogger()
        {

        }

        public static ConsoleLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (obj)
                    {
                        _instance = new ConsoleLogger();
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
