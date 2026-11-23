using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesLib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    internal class EncryptedAttribute : Attribute
    {
        public EncryptedAttribute(EncryptionAlgorithm algorithm = EncryptionAlgorithm.DES)
        {
            EncryptionAlgorithm = algorithm;
        }

        public EncryptionAlgorithm EncryptionAlgorithm
        {
            get;
            set;
        }
    }
}
