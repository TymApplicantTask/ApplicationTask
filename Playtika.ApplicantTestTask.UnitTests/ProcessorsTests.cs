using Playtika.ApplicantTestTask.Core;
using Playtika.ApplicantTestTask.Logic.DataProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtika.ApplicantTestTask.UnitTests
{
    using NUnit.Framework;

    [TestFixture(typeof(AllDataProcessor))]
    [TestFixture(typeof(CppDataProcessor))]
    [TestFixture(typeof(Reversed1DataProcessor))]
    [TestFixture(typeof(Reversed2DataProcessor))]
    public class ProcessorsTests<T> where T: DataProcessor, new()
    {
        [Test]
        public void TryProcessReturnsFalseTest()
        {
            T t = new T();
            string strResult;
            bool res = t.TryProcess("", out strResult);

            Assert.False(res);
        }

    }
}
