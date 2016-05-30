using Playtika.ApplicantTestTask.Core;
using System;
using System.IO;
using System.Linq;

namespace Playtika.ApplicantTestTask.Logic.DataProcessors
{
    public class Reversed2DataProcessor : DataProcessor
    {
        protected override bool TryProcessInput(string input, out string result)
        {
            result =  new string(GetRelativePath(Path.GetFullPath(input)).Reverse().ToArray());

            return true;
        }
    }
}