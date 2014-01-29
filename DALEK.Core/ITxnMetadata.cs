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

namespace DALEK.Core
{
    public interface ITxnMetadata
    {
        TxnType Type { get; }
        TxnAction Action { get; }
        string Name { get; }
        string Version { get; }
    }
}
