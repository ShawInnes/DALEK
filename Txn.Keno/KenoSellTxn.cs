using DALEK.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Txn.Keno
{
    [TxnMetadata("KenoSellTxn", "1.0.0", TxnType.Keno, TxnAction.Sell)]
    public class KenoSellTxn : ITxn
    {
        public string TxnName { get { return "KenoSellTxn"; } }

        public void Validate(Guid Id)
        {
            Console.WriteLine("{0} Validate {1}", TxnName, Id);
        }

        public void Update()
        {
            Console.WriteLine("{0} Update", TxnName);
        }

        public void Response()
        {
            Console.WriteLine("{0} Response", TxnName);
        }

        public void Fail()
        {
            Console.WriteLine("{0} Fail", TxnName);
        }
    }
}
