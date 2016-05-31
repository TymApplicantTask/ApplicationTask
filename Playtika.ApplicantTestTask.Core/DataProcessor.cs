using System;
using System.IO;

namespace Playtika.ApplicantTestTask.Core
{
    public abstract class DataProcessor
    {
        private string _rootFolder;
        private Uri _root;

        public DataProcessor()
        {
            RootFolder = string.Empty;
        }

        public string RootFolder
        {
            get { return _rootFolder; }
            set
            {
                try
                {
                    _rootFolder = value;
                    _root = new Uri(value);
                }
                catch
                {
                    _root = null;
                    _rootFolder = string.Empty;
                }
            }
        }

        public bool TryProcess(string input, out string result)
        {
            if (string.IsNullOrEmpty(input))
            {
                result = string.Empty;
                return false;
            }

            return TryProcessInput(input, out result);
        }

        protected abstract bool TryProcessInput(string input, out string result);

        protected string GetRelativePath(string currentFolder)
        {
            if (_root == null)
            {
                return currentFolder;
            }

            Uri cur = new Uri(currentFolder);
            return _root.MakeRelativeUri(cur).ToString().Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }
    }
}
