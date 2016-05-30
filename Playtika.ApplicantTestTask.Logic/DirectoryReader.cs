using Playtika.ApplicantTestTask.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtika.ApplicantTestTask.Logic
{
    public class DirectoryReader : IDirectoryReader
    {
        public IEnumerable<string> GetFiles(string folder)
        {
            return Directory.EnumerateFiles(folder);
        }

        public Task<IEnumerable<string>> GetFilesAsync(string folder)
        {
            return Task.Run(() => GetFiles(folder));
        }

        public IEnumerable<string> GetFolders(string folder)
        {
            return Directory.EnumerateDirectories(folder);
        }

        public Task<IEnumerable<string>> GetFoldersAsync(string folder)
        {
            return Task.Run(() => GetFolders(folder));
        }

        public bool IsFolderExists(string folderName)
        {
            return Directory.Exists(folderName);
        }
    }
}
