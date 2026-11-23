using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    public class MediaMessageProcessor : IProcessor
    {
        public bool CheckProcessor(ESBMessageType processorType)
        {
            return processorType == ESBMessageType.Media;
        }

        public bool ProcessMessage(string message)
        {
            return true;
        }
    }
}
