using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableToStringEx
{
    public class DatHelper
    {
        public DatHelper()
        {

        }

        public string ChangeDataTableToString(DataTable data)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (DataRow row in data.Rows)
            {
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    strBuilder.Append(row.ItemArray[i]);
                    strBuilder.Append(BatchConstant.DatDelimiter);
                }
                //strBuilder.Remove(strBuilder.Length - 1, 1);
                strBuilder.Append("\r\n");
            }

            return strBuilder.ToString();
        }
    }
}
