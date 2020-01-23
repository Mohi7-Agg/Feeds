using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubmissionProvider.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubmissionProviderTest
{
    [TestClass]
    public class ValidationsTest
    {
        [TestMethod]
        public void ValidateSource()
        {
            string source = @"Capterra,D:\SubmissionProvider\feed-products\Capterra.yaml";
            Assert.IsTrue(Validations.ValidateSource(source) == true);

            source = @"D:\SubmissionProvider\feed-products\Capterra.yaml";
            Assert.IsTrue(Validations.ValidateSource(source) == false);
        }
    }
}
