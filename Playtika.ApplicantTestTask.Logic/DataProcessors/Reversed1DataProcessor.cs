using Playtika.ApplicantTestTask.Core;
using System.IO;
using System.Linq;

namespace Playtika.ApplicantTestTask.Logic.DataProcessors
{
    public class Reversed1DataProcessor : DataProcessor
    {
        private static readonly string _directorySeparatorChar = Path.AltDirectorySeparatorChar.ToString();

        protected override bool TryProcessInput(string input, out string result)
        {
            result = string.Join(
                _directorySeparatorChar,
                GetRelativePath(Path.GetFullPath(input)).Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Reverse());

            return true;
        }
    }
}