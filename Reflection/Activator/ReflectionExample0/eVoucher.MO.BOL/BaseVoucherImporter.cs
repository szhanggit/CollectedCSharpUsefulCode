using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public delegate DataTable CheckImportData(int programId, string sessionId);
    public abstract class BaseVoucherImporter : IVoucherImportChecker
    {
        protected CheckImportData CheckingData;
        protected VoucherImportTemplateType GroupName { get; set; }
        protected string BufferTableName { get; set; }
        protected string[] ColumnArray { get; set; }
        protected string[] ColumnRegexArray { get; set; }
        public bool CheckImporter(VoucherImportTemplateType importType)
        {
            return importType == GroupName;
        }

        public string CheckTransferData()
        {
            throw new NotImplementedException();
        }

        public DataTable ImportVoucher(DataTable dataTable, DateTime? expiryDate, int? availableStartDate, int? availableEndDate)
        {
            DataTable result = new DataTable("resultDataTable");
            result = CheckingData?.Invoke(1, "sessionId");
            if (result != null && result.Rows.Count > 0)
            {
                return result;
            }

            return new DataTable();
        }

        public DataTable ImportVoucher(string sessionId)
        {
            throw new NotImplementedException();
        }

        public void TransferVoucher(string productCode, string reservationCode, string sessionId, string subSessionId, int availableStartDate, int availableEndDate, DateTime? expiryDate)
        {
            throw new NotImplementedException();
        }
    }
}
