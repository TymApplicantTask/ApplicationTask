using Playtika.ApplicantTestTask.Core;
using System.IO;

namespace Playtika.ApplicantTestTask.Logic.DataProcessors
{
    public class AllDataProcessor : DataProcessor
    {
        protected override bool TryProcessInput(string input, out string result)
        {
            result = GetRelativePath(Path.GetFullPath(input));
            return true;
        }
    }
}