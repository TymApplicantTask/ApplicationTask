using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtika.ApplicantTestTask.Core
{
    public interface IDirectoryReader
    {
        bool IsFolderExists(string folderName);
        IEnumerable<string> GetFolders(string folder);
        IEnumerable<string> GetFiles(string folder);
        Task<IEnumerable<string>> GetFoldersAsync(string folder);
        Task<IEnumerable<string>> GetFilesAsync(string folder);
    }
}
