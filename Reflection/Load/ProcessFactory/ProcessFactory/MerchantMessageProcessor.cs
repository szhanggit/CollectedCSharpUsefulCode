using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    public class MerchantMessageProcessor : IProcessor
    {
        public bool CheckProcessor(ESBMessageType processorType)
        {
            return processorType == ESBMessageType.Merchant;
        }

        public bool ProcessMessage(string message)
        {
            return true;
        }
    }
}
