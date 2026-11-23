using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVoucher.MO.BOL
{
    public class TWStarbucksVoucherImporter : IVoucherImporter
    {
        public string CheckTransferData()
        {
            throw new NotImplementedException();
        }

        public DataTable ImportVoucher(DataTable dataTable, DateTime? expiryDate, int? availableStartDate, int? availableEndDate)
        {
            throw new NotImplementedException();
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
