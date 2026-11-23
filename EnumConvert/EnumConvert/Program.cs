using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionRequestIn transactionRequestIn = new TransactionRequestIn();
            TransactionRequest transactionRequest = new TransactionRequest();
            transactionRequestIn.Encoding = "UTF8";// UTF8;big5;ASCII


            TransactionEncoding transactionEncoding = TransactionEncoding.ASCII;

            if (!string.IsNullOrEmpty(transactionRequestIn.Encoding))
            {
                //Enum.TryParse<TransactionEncoding>(transactionRequestIn.Encoding.ToUpperInvariant(), out transactionEncoding);
                bool flag = Enum.TryParse<TransactionEncoding>(transactionRequestIn.Encoding.ToUpperInvariant(), true, out transactionEncoding);
            }

            transactionRequest.Encoding = transactionEncoding;
        }
    }
}
