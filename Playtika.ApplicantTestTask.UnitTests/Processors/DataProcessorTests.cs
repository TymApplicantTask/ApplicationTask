using Playtika.ApplicantTestTask.Core;
using Playtika.ApplicantTestTask.Logic.DataProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtika.ApplicantTestTask.UnitTests.Processors
{
    using NUnit.Framework;

    [TestFixture]
    public class ConcreteProcessorTests
    {
        [Test]
        [TestCase(typeof(AllDataProcessor), true, @"AppTask\ApplicationTask\myFile.cpp")]
        [TestCase(typeof(CppDataProcessor), true, @"AppTask\ApplicationTask\myFile.cpp/")]
        [TestCase(typeof(Reversed1DataProcessor), true, @"myFile.cpp\ApplicationTask\AppTask")]
        [TestCase(typeof(Reversed2DataProcessor), true, @"ppc.eliFym\ksaTnoitacilppA\ksaTppA")]
        public void CorrectnessOfProcessingTest(Type t, bool expectedResultState, string expectedResult)
        {
            string root = @"C:\Development\AppTask";
            string input = @"C:\Development\AppTask\ApplicationTask\myFile.cpp";            
            var test = Activator.CreateInstance(t) as DataProcessor;            
            test.RootFolder = root;

            string result;
            bool state = test.TryProcess(input, out result);

            Assert.AreEqual(expectedResultState, state);
            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        [TestCase(@"C:\AppTask\ApplicationTask\myFile.cppp")]
        [TestCase(@"C:\AppTask\ApplicationTask\myFile.my")]
        public void CppDataProcessorSkipNotCppFiles(string input)
        {
            CppDataProcessor test = new CppDataProcessor();

            string result;
            bool state = test.TryProcess(input, out result);

            Assert.False(state);
        }

    }
}

