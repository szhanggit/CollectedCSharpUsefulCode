using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace XmlToList
{
    public class DataProvider
    {
        public DataProvider()
        {

        }

        public int GetProcessingId()
        {
            int? ProcessingId = 0;
            int result = 0;
            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                ProcessingId = connection.QuerySingleOrDefault<int?>(ScriptManager.GetProcessingId());
            }

            if (!ProcessingId.HasValue)
            {
                result = int.MaxValue;
            }
            else
            {
                result = ProcessingId.Value;
            }

            return result;
        }

        public List<SampleData> GetSampleData(int step, int ProcessingId)
        {
            List<SampleData> _list = new List<SampleData>();

            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                _list = connection.Query<SampleData>(ScriptManager.GetSampleData(step, ProcessingId)).ToList();
            }

            return _list;
        }

        public SampleData CheckSampleData(int MessageId)
        {
            SampleData sd = new SampleData();

            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                sd = connection.QuerySingleOrDefault<SampleData>(ScriptManager.CheckSampleData(MessageId));
            }

            return sd;
        }        

        public void InsertCheckingResult(int MessageId, int MessageLocalId, int Status, string MissingTag, string MissingVal, string OrderNumber)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                connection.Execute(ScriptManager.InsertCheckResult(MessageId, MessageLocalId, Status, MissingTag, MissingVal, OrderNumber));
            }
        }

        public string GetOrderNumber(int MessageLocalId)
        {
            string OrderNumber = string.Empty;

            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.MODB)))
            {
                OrderNumber = connection.QuerySingleOrDefault<string>(ScriptManager.GetOrderNumber(MessageLocalId));
            }

            return OrderNumber;
        }

        public List<CheckParaData> GetCheckParaData()
        {
            List<CheckParaData> _list = new List<CheckParaData>();

            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                _list = connection.Query<CheckParaData>(ScriptManager.GetCheckParaData()).ToList();
            }

            return _list;
        }

        public VoucherInfo GetVoucherInfo(int MessageLocalId)
        {
            VoucherInfo vi = new VoucherInfo();

            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.MODB)))
            {
                vi = connection.QuerySingleOrDefault<VoucherInfo>(ScriptManager.GetVoucherInfo(MessageLocalId));
            }

            return vi;
        }

        public void UpdateCheckingResult(int Id, string ClientName, string ProductCode)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                connection.Execute(ScriptManager.UpdateCheckResult(Id, ClientName, ProductCode));
            }
        }

        public void UpdateCheckingResultWithMissingTag(int Id, string ClientName, string ProductCode, string MissingTag)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                connection.Execute(ScriptManager.UpdateCheckResultWithMissingTag(Id, ClientName, ProductCode, MissingTag));
            }
        }

        public void CorrectCheckingResult(int Id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionManager.Instance.GetConnection(ApplicationConstant.DIVEDB)))
            {
                connection.Execute(ScriptManager.CorrectCheckResult(Id));
            }
        }
    }
}
