using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public static class ScriptManager
    {
        public static string GetProcessingId()
        {
            string sql = string.Empty;
            sql = $"select min(MessageId) as Id from CheckPara20210127 with(nolock)";

            return sql;
        }

        public static string GetSampleData(int step, int ProcessingId)
        {
            string sql = string.Empty;
            sql = $"select top({step}) em.Id as MessageId, em.MessageLocalId, em.CreatedOn as CreateOn, em.[Parameters] as Parameters, emt.Body as EmailTemplate " +
                $"from EmailMessage em with(nolock) " +
                $"inner join Task t with(nolock) on em.TaskId = t.Id " +
                $"inner join EmailMessageTemplate emt with(nolock) on t.EmailTemplateId = emt.Id " +
                $"where em.Id < {ProcessingId} order by em.Id desc";

            return sql;
        }

        public static string GetSingleSampleData(int MessageId)
        {
            string sql = string.Empty;
            sql = $"select top(1) em.Id as MessageId, em.MessageLocalId, em.CreatedOn as CreateOn, em.[Parameters] as Parameters, emt.Body as EmailTemplate " +
                $"from EmailMessage em with(nolock) " +
                $"inner join Task t with(nolock) on em.TaskId = t.Id " +
                $"inner join EmailMessageTemplate emt with(nolock) on t.EmailTemplateId = emt.Id " +
                $"where em.Id < {MessageId}";

            return sql;
        }

        public static string CheckSampleData(int MessageId)
        {
            string sql = string.Empty;
            sql = $"select top(1) em.Id as MessageId, em.MessageLocalId, em.CreatedOn as CreateOn, em.[Parameters] as Parameters, emt.Body as EmailTemplate " +
                $"from EmailMessage em with(nolock) " +
                $"inner join Task t with(nolock) on em.TaskId = t.Id " +
                $"inner join EmailMessageTemplate emt with(nolock) on t.EmailTemplateId = emt.Id " +
                $"where em.Id = {MessageId}";

            return sql;
        }

        public static string InsertCheckResult(int MessageId, int MessageLocalId, int Status, string MissingTag, string MissingVal, string OrderNumber)
        {
            string sql = string.Empty;
            sql = $"insert into CheckPara20210127 ([MessageId], [MessageLocalId], [Status], [MissingTag], [MissingVal], [OrderNumber]) " +
                $"values({MessageId}, {MessageLocalId}, {Status}, '{MissingTag}', '{MissingVal}', '{OrderNumber}'); ";

            return sql;
        }

        public static string GetOrderNumber(int MessageLocalId)
        {
            string sql = string.Empty;
            sql = $"select top(1) o.OrderNumber " +
                $"from Voucher v WITH(nolock) " +
                $"join OrderBeneficiaryInfo obi WITH(nolock) on obi.Id = v.BeneficiaryInfoId " +
                $"join OrderLine ol WITH(nolock) on ol.Id = obi.OrderLineId " +
                $"join[Order] o WITH(NOLOCK) ON o.Id = ol.OrderId " +
                $"JOIN dbo.ClientQuotationProduct cqp WITH(nolock) ON ol.ClientQuotationProductId = cqp.Id " +
                $"JOIN dbo.ClientQuotation cq WITH(NOLOCK) ON cqp.ClientQuotationId = cq.Id " +
                $"JOIN dbo.Client c WITH(NOLOCK) ON cq.ClientId = c.Id " +
                $"JOIN dbo.ProductVersion pv WITH(NOLOCK) ON cqp.ProductVersionId = pv.Id " +
                $"JOIN dbo.Product p WITH(NOLOCK) ON p.Id = pv.ProductId " +
                $"where v.Id in (select dtmv.VoucherId from DistributionTask dt with(nolock) " +
                $"inner join [DistributionTaskMessage] dtm with(nolock) on dt.Id = dtm.DistributionTaskId " +
                $"inner join [DistributionTaskMessageVoucher] dtmv with(nolock) on dtmv.DistributionTaskMessageId = dtm.Id " +
                $"where dtm.Id = {MessageLocalId})";

            return sql;
        }

        public static string GetCheckParaData()
        {
            string sql = string.Empty;
            sql = $"select Id as CheckParaId, MessageId as MessageId, MessageLocalId as MessageLocalId, [Status] as Status, MissingTag, MissingVal, OrderNumber from CheckPara20210127 with(nolock) " +
                $"where[Status] in (1, 3) AND MessageLocalId > 10 AND OrderNumber != '' AND Id = 76 ";// AND Email is null

            return sql;
        }

        public static string GetVoucherInfo(int MessageLocalId)
        {
            string sql = string.Empty;
            sql = $"select top(1) o.OrderNumber, ol.Id as orderlineId, v.VoucherNumber as VoucherNumber, obi.Id as OrderBeneficiaryInfoId, obi.Email as Email, c.[Name] as ClientName, p.ProductCode " +
                $"from Voucher v WITH(nolock) " +
                $"join OrderBeneficiaryInfo obi WITH(nolock) on obi.Id = v.BeneficiaryInfoId " +
                $"join OrderLine ol WITH(nolock) on ol.Id = obi.OrderLineId " +
                $"join[Order] o WITH(NOLOCK) ON o.Id = ol.OrderId " +
                $"JOIN dbo.ClientQuotationProduct cqp WITH(nolock) ON ol.ClientQuotationProductId = cqp.Id " +
                $"JOIN dbo.ClientQuotation cq WITH(NOLOCK) ON cqp.ClientQuotationId = cq.Id " +
                $"JOIN dbo.Client c WITH(NOLOCK) ON cq.ClientId = c.Id " +
                $"JOIN dbo.ProductVersion pv WITH(NOLOCK) ON cqp.ProductVersionId = pv.Id " +
                $"JOIN dbo.Product p WITH(NOLOCK) ON p.Id = pv.ProductId " +
                $"where v.Id in (select dtmv.VoucherId from DistributionTask dt with(nolock) " +
                $"inner join [DistributionTaskMessage] dtm with(nolock) on dt.Id = dtm.DistributionTaskId " +
                $"inner join [DistributionTaskMessageVoucher] dtmv with(nolock) on dtmv.DistributionTaskMessageId = dtm.Id " +
                $"where dtm.Id = {MessageLocalId})";

            return sql;
        }

        public static string UpdateCheckResult(int Id, string ClientName, string ProductCode)
        {
            string sql = string.Empty;
            sql = $"update CheckPara20210127 " +
                $"set ClientName = '{ClientName}', " +
                $"ProductCode = '{ProductCode}' " +
                $"where Id = {Id} ";

            return sql;
        }

        public static string UpdateCheckResultWithMissingTag(int Id, string ClientName, string ProductCode, string MissingTag)
        {
            string sql = string.Empty;
            sql = $"update CheckPara20210127 " +
                $"set ClientName = N'{ClientName}', " +
                $"ProductCode = '{ProductCode}', " +
                $"MissingTag = '{MissingTag}' " +
                $"where Id = {Id} ";

            return sql;
        }

        public static string CorrectCheckResult(int CheckParaId)
        {
            string sql = string.Empty;
            sql = $"update CheckPara20210127 " +
                $"set [Status] = 0 " +
                $"where Id = {CheckParaId} ";

            return sql;
        }
    }
}
