using System;
using Playtika.ApplicantTestTask.Core;
using System.IO;

namespace Playtika.ApplicantTestTask.Logic.DataProcessors
{
    public class CppDataProcessor : DataProcessor
    {
        protected override bool TryProcessInput(string input, out string result)
        {
            if (!Path.GetExtension(input).Equals(".cpp", StringComparison.InvariantCultureIgnoreCase))
            {
                result = string.Empty;
                return false;
            }

            result = GetRelativePath(Path.GetFullPath(input)) + "/";
            return true;
        }
    }
}