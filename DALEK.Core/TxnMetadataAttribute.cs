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
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TxnMetadataAttribute : ExportAttribute, ITxnMetadata
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public TxnType Type { get; private set; }
        public TxnAction Action { get; private set; }

        /// <summary>
        /// Initializes a new instance of the TxnMetadataAttribute class.
        /// </summary>
        public TxnMetadataAttribute(string name, string version, TxnType type, TxnAction action)
            : base(typeof(ITxn))
        {
            Action = action;
            Type = type;
            Name = name;
            Version = version;
        }
    }
}
