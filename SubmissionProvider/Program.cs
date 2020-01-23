using SubmissionProvider.Interfaces;
using System;
using SubmissionProvider.Exceptions;
using System.Runtime.CompilerServices;

namespace SubmissionProvider
{
    public class Program
    {
        static void Main(string[] args)
        {

            ILogger logger = ConsoleLogger.Instance;
            FileParserFactory fileParserFactory = new FileParserFactory();
            FeedProvider feedProvider = new FeedProvider(logger, fileParserFactory);

            if (args.Length == 0)
            {
                logger.Log("Please provide file path ...");
                return;
            }

            string inputPath = args[0];

            try
            {
                feedProvider.ProcessFeeds(inputPath);
            }
            catch(InvalidFilePathException)
            {
                logger.Log("File not exists, Please provide valid Input Path ...");
            }
            catch (InvalidSourceFormatException ex)
            {
                logger.Log($"Bad File format {ex} ...");
            }
            catch (Exception ex)
            {
                logger.Log($"Critical Exception occure at {ex} ");
            }
        }
    }

}
