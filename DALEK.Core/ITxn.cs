using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEK.Core
{
    public interface ITxn
    {
        string TxnName { get; }

        void Validate(Guid Id);
        void Update();
        void Response();
        void Fail();
    }
}