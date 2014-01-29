using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Registration;
using System.ComponentModel.Composition.Hosting;
using DALEK.Core;
using System.Reflection;
using System.Xml;

namespace DALEK.Shell
{
    class Program
    {
        private static CompositionContainer _container;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            Compose();
        }

        private void Compose()
        {
            RegistrationBuilder conventions = new RegistrationBuilder();

            conventions
                .ForTypesDerivedFrom<ITxn>()
                .SetCreationPolicy(CreationPolicy.NonShared);

            conventions
                .ForType<TxnProcessor>()
                .Export()
                .ImportProperties(
                    propertyFilter => propertyFilter.Name.Equals("Plugins"),
                    (propertyInfo, importBuilder) =>
                    {
                        importBuilder.AsMany();
                    }
                )
                .ImportProperties(
                    propertyFilter => propertyFilter.Name.Equals("Transactions"),
                    (propertyInfo, importBuilder) =>
                    {
                        importBuilder.AsMany();
                    }
                )
                .SetCreationPolicy(CreationPolicy.NonShared);

            DirectoryCatalog dirCatalog = new DirectoryCatalog(@"..\Modules", conventions);
            AssemblyCatalog assCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly(), conventions);
            AggregateCatalog catalog = new AggregateCatalog(dirCatalog, assCatalog);

            _container = new CompositionContainer(catalog, true);
            _container.SatisfyImportsOnce(this);

            Enumerable.Range(1, 1).AsParallel().ForAll(p => 
            {
                TxnProcessor processor = _container.GetExportedValue<TxnProcessor>();

                foreach (var item in processor.Plugins)
                {
                    ITxn txn = item.Value;
                    txn.Validate(processor.Id);
                }

                ITxn kenoSell = _container.GetExports<ITxn, ITxnMetadata>()
                                          .Single(q => q.Metadata.Type == TxnType.Keno && q.Metadata.Action == TxnAction.Sell)
                                          .Value;
                
                kenoSell.Validate(processor.Id);
            });

            Console.ReadLine();
        }
    }
}
