using System;
using Playtika.ApplicantTestTask.Core;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Playtika.ApplicantTestTask.App
{
    internal class Engine : IDisposable
    {
        private readonly IDirectoryReader _directoryReader;
        private readonly DataProcessor _processor;
        private readonly IResultWriter _writer;
        private readonly ConcurrentQueue<string> _folderQueue;

        public Engine(IDirectoryReader directoryReader, DataProcessor processor, IResultWriter resultWriter)
        {
            _directoryReader = directoryReader;
            _processor = processor;
            _writer = resultWriter;
            _folderQueue = new ConcurrentQueue<string>();
        }

        internal void Run(string rootFolder)
        {
            _processor.RootFolder = rootFolder;
            _folderQueue.Enqueue(rootFolder);
            List<Task> tasks = new List<Task>();

            while (true)
            {
                string curFolder;

                if (_folderQueue.TryDequeue(out curFolder))
                {
                    tasks.Add(ProcessFolder(curFolder));
                }
                else
                {
                    if (!tasks.Any())
                    {
                        break;
                    }

                    Task.WaitAll(tasks.ToArray());
                    tasks.Clear();
                }                
            }
        }

        private async Task ProcessFolder(string folder)
        {
            IEnumerable<string> folders = await _directoryReader.GetFoldersAsync(folder);

            foreach (var f in folders)
            {
                _folderQueue.Enqueue(f);
            }

            var files = await _directoryReader.GetFilesAsync(folder);

            foreach (var f in files)
            {
                string result;

                if (_processor.TryProcess(f, out result))
                {
                    _writer.WriteLine(result);
                }
            }
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
                }

                m_Disposed = true;
            }
        }

        ~Engine()
        {
            Dispose(false);
        }
    }
}