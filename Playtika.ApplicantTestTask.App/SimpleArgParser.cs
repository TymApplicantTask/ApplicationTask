using Microsoft.Practices.Unity;
using Playtika.ApplicantTestTask.Core;

namespace Playtika.ApplicantTestTask.App
{
    internal class SimpleArgParser
    {
        private IUnityContainer _container;
        private readonly bool _isValid;

        public SimpleArgParser(string[] args, IUnityContainer _container)
        {
            this._container = _container;

            if (args == null || args.Length < 2)
            {
                _isValid = false;
                return;
            }

            RootFolder = args[0]?? string.Empty;
            ProcessorName = args[1] ?? string.Empty;

            _isValid = _container.Resolve<IDirectoryReader>().IsFolderExists(RootFolder);
            _isValid = _isValid  && _container.IsRegistered<DataProcessor>(ProcessorName);

            if (args.Length > 2)
            {
                DestFileName = args[2];
            } 
        }

        public bool IsValid { get { return _isValid; } }

        public string RootFolder { get; private set; }

        public string ProcessorName { get; private set; }

        public string DestFileName { get; private set; } = "results.txt";
    }
}