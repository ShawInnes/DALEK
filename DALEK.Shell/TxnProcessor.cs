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

namespace DALEK.Shell
{
    public class TxnProcessor
    {
        public IEnumerable<ITxn> Transactions { get; set; }

        public IEnumerable<Lazy<ITxn, ITxnMetadata>> Plugins { get; set; }

        public Guid Id { get; set; }

        public TxnProcessor()
        {
            Id = Guid.NewGuid();
        }
    }
}
