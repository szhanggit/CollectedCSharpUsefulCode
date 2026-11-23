using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessFactory
{
    public enum ESBMessageType
    {
        Program = 1,
        Media = 2,
        Client = 3,
        Template = 4,
        GenerateTransaction = 5,
        Quotation = 6,
        SOC = 7,
        Merchant = 8,
        Shop = 9
    }
    public interface IProcessor
    {
        bool CheckProcessor(ESBMessageType processorType);
        bool ProcessMessage(string message);
    }
}
