using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProvider.DataModel
{
    public class Capterra
    {
        public string tags { get; set; }
        public string name { get; set; }
        public string twitter { get; set; }

        public Capterra(string tags, string name, string twitter)
        {
            this.tags = tags;
            this.name = name;
            this.twitter = twitter;
        }

        public Capterra(Dictionary<string, string> data)
        {
            tags = data["tags"];
            name = data["name"];
            twitter = data["twitter"];
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Capterra capterra = (Capterra)obj;
            return this.tags == capterra.tags
                && this.twitter == capterra.twitter
                && this.name == capterra.name;
        }

        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}", tags, twitter, name).GetHashCode();
        }
    }
}
