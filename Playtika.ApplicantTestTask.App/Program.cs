using Microsoft.Practices.Unity;
using Playtika.ApplicantTestTask.Core;
using Playtika.ApplicantTestTask.Logic;
using Playtika.ApplicantTestTask.Logic.DataProcessors;
using System;

namespace Playtika.ApplicantTestTask.App
{
    class Program
    {
        private static IUnityContainer _container= new UnityContainer();
        
        static int Main(string[] args)
        {
            InitializeContainer();

            var argParser = new SimpleArgParser(args, _container);
            
            if (!argParser.IsValid)
            {
                Console.WriteLine("Invalid command line params");
                return -1;
            }

            _container.RegisterType<Engine>("basic engine",
                new InjectionConstructor(
                    new ResolvedParameter<IDirectoryReader>(),
                    new ResolvedParameter<DataProcessor>(argParser.ProcessorName),
                    new ResolvedParameter<IResultWriter>()));

            var parameter = new ParameterOverride("fileName", argParser.DestFileName);

            using (var engine = _container.Resolve<Engine>("basic engine", parameter))
            {
                engine.Run(argParser.RootFolder);
            }

            return 0;
        }

        private static void InitializeContainer()
        {
            _container.RegisterType<IDirectoryReader, DirectoryReader>();
            _container.RegisterType<DataProcessor, AllDataProcessor>(ProcessingTypes.All);
            _container.RegisterType<DataProcessor, CppDataProcessor>(ProcessingTypes.Cpp);
            _container.RegisterType<DataProcessor, Reversed1DataProcessor>(ProcessingTypes.Reversed1);
            _container.RegisterType<DataProcessor, Reversed2DataProcessor>(ProcessingTypes.Reversed2);
            _container.RegisterType<IResultWriter, ResultWriter>(new PerResolveLifetimeManager());
        }
    }
}
