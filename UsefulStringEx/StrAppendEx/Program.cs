using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrAppendEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ids = new List<int> { 2,3,4,9,28,7,5,93,59,34};
            var sb = new StringBuilder();
            ids.ForEach(x =>
            {
                sb.Append(string.Format(@"INSERT INTO [dbo].[EXT_IN_EMVCancelRCN]
                   ([EMV_ClientOrderLineId]
                    ,[CreatedOn])
                     VALUES
                    ({0}
                    ,getdate());", x));
            });

            Console.WriteLine(sb.ToString());
            Console.ReadKey();
        }
    }
}
