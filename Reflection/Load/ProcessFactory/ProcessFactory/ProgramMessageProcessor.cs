using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    public class ProgramMessageProcessor : IProcessor
    {
        public bool CheckProcessor(ESBMessageType messageType)
        {
            return messageType == ESBMessageType.Program;
        }

        public bool ProcessMessage(string message)
        {
            return true;
        }
    }
}
