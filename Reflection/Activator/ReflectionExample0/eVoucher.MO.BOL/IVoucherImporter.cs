using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public interface IVoucherImporter
    {
        DataTable ImportVoucher(DataTable dataTable, DateTime? expiryDate, int? availableStartDate, int? availableEndDate);
        DataTable ImportVoucher(string sessionId);
        string CheckTransferData();
        void TransferVoucher(string productCode, string reservationCode, string sessionId, string subSessionId, int availableStartDate, int availableEndDate, DateTime? expiryDate);
    }
}
