using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playtika.ApplicantTestTask.Core
{
    public interface IResultWriter: IDisposable
    {
        void WriteLine(string text);
    }
}
