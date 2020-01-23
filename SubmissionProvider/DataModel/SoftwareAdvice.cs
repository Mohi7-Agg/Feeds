using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider.DataModel
{
    public class SoftwareAdvice
    {
        public string title { get; set; }

        public string twitter { get; set; }

        public string[] categories { get; set; }

        public SoftwareAdvice(string title, string twitter, string[] categories)
        {
            this.title = title;
            this.twitter = twitter;
            this.categories = categories;
        }

        public SoftwareAdvice(JObject obj)
        {
            title = (string)obj.SelectToken("title");
            twitter = (string)obj.SelectToken("twitter");
            categories = ((JArray)obj.SelectToken("categories")).Select(c => c.ToString()).ToArray();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            SoftwareAdvice softwareAdvice = (SoftwareAdvice)obj;
            return this.title == softwareAdvice.title
                && this.twitter == softwareAdvice.twitter
                && this.categories.SequenceEqual(softwareAdvice.categories);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}", title, twitter, categories).GetHashCode();
        }
    }
}
