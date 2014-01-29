using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Registration;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace DALEK.Core
{
    public enum TxnAction
    {
        Sell,
        Pay,
        Enquiry,
        System,
    }
}
