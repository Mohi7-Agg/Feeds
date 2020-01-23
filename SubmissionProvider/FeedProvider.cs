using SubmissionProvider.DataModel;
using SubmissionProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static SubmissionProvider.Constants;
using SubmissionProvider.Utilities;
using SubmissionProvider.Exceptions;
using System.Runtime.CompilerServices;

namespace SubmissionProvider
{
   public class FeedProvider
    {
        private ILogger _logger;
        private FileParserFactory _fileParserFactory;
        public FeedProvider(ILogger logger, FileParserFactory fileParserFactory)
        {
            _logger = logger;
            _fileParserFactory = fileParserFactory;

        }


        public void ProcessFeeds(string path)
        {
            _logger.Log("Feed Processing started...");

            if (!File.Exists(path))
            {
                throw new InvalidFilePathException();
            }

            string[] sources = File.ReadAllLines(path);

            foreach (string source in sources)
            {
                _logger.Log($"Processing file {source} ...");

                if (!Validations.ValidateSource(source))
                {
                    throw new InvalidSourceFormatException(source);
                }
                else
                {
                    string[] sourceArr = source.Split(',');
                    string provider = sourceArr[0];
                    string sourcePath = sourceArr[1];
                    if( UpdateInventory(provider, sourcePath))
                        _logger.Log($"Successfully processed : {provider}...");
                }
            }
            _logger.Log("Feed Processing completed...");
        }
        public bool UpdateInventory(string provider, string path)
        {

            string extn = Path.GetExtension(path);
            string ext = extn.Substring(1).ToUpper();
            if (!Enum.TryParse(ext, out FileType fileType))
            {
                _logger.Log("Invalid File exension");
                return false;
            }

            if (!Enum.TryParse(provider, out ProviderEnum feedProvider))
            {
                _logger.Log("Invalid Feed Provider");
                return false;
            }

            if (!File.Exists(path))
            {
                throw new InvalidFilePathException();
            }

            IFileParser parser = _fileParserFactory.GetParser(fileType);


            switch (feedProvider)
            {
                case ProviderEnum.Capterra:
                    var capterraObject = parser.ParseFile(path);
                    List<Capterra> capterraList = GetCapterraList(capterraObject);
                    //Persist to DB

                    break;
                case ProviderEnum.SoftwareAdvice:
                    var saObject = parser.ParseFile(path);
                    List<SoftwareAdvice> saList = GetSoftwareAdviceList(saObject);
                    //Persist to DB
                    break;

            }
            return true;
        }
        internal List<Capterra> GetCapterraList(object data)
        {
            List<Capterra> result = new List<Capterra>();
            try
            {
                List<object> capteraObjList = (List<object>)data;
                foreach (var capterra in capteraObjList)
                {
                    var dict = ((Dictionary<object, object>)capterra).ToDictionary(k => k.Key.ToString(), k => k.Value.ToString());
                    result.Add(new Capterra(dict));
                }
            }
            catch (Exception ex)
            {
                _logger.Log($"Error Parsing Capterra Object {ex}");
            }
            return result;

        }
        internal List<SoftwareAdvice> GetSoftwareAdviceList(object data)
        {
            List<SoftwareAdvice> result = new List<SoftwareAdvice>();
            try
            {
                var resultObjects = (JArray)JObject.Parse(data.ToString()).SelectToken("products");

                foreach (JObject jObj in resultObjects)
                {
                    result.Add(new SoftwareAdvice(jObj));
                }
            }

            catch (Exception ex)
            {
                _logger.Log($"Error Parsing Software Advice Object {ex}");
            }
            return result;
        }
    }
}
