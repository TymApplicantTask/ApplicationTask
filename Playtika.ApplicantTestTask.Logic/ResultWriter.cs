using Playtika.ApplicantTestTask.Core;
using System;
using System.IO;

namespace Playtika.ApplicantTestTask.Logic
{
    public class ResultWriter : IResultWriter, IDisposable
    {
        private TextWriter _writer;

        public ResultWriter(string fileName)
        {
            _writer = TextWriter.Synchronized(File.CreateText(fileName));
        }

        public void WriteLine(string text)
        {
            _writer.WriteLine(text);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool m_Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!m_Disposed)
            {
                if (disposing)
                {
                    _writer.Dispose();
                    _writer = null;
                }

                m_Disposed = true;
            }
        }

        ~ResultWriter()
        {
            Dispose(false);
        }

    }
}
