using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToList
{
    public static class ApplicationConstant
    {
        public const string LocalSqlServer = "LocalSqlServer";
        public const string LocalDevConn = "d_ev_le";
        public const string AuthorizationContext = "d_ev_authorizationContext";
        public const string MODB = "MODB";
        public const string DIVEDB = "DIVEDB";
        public const string PreAuthorizationExpireJob = "PreAuthorizationExpireJob";
        public const string AbnormalAccountActivityJob = "AbnormalAccountActivityJob";
        public const string ExpireAccountJob = "ExpireAccountJob";
        public const string AbnormalAccountFilter = "AbnormalAccountFilter";
        public const string ClearStatisticsJob = "ClearStatisticsJob";
        public const string ClearCompositeJob = "ClearCompositeJob";
        public const string BATCH = "Batch";
        public const string BATCHSERVICE = "BatchService";
        public const string BatchTimeOut = "BatchTimeOut";
        public const string FailScanningJob = "FailScanningJob";
        public const string CleanAccountJob = "CleanAccountJob";
        public const string ResetFailNumberJob = "ResetFailNumberJob";
        public const string DetectFraudTransactionJob = "DetectFraudTransactionJob";
        public const string StabilityScanningJob = "StabilityScanningJob";
        public const string AdoraSweeperJob = "AdoraSweeperJob";
        public const string InsertExpireAccountJob = "InsertExpireAccountJob";
        public const string ProcesTextFileJob = "ProcesTextFileJob";
        public const string ProcessCheckLEInitBalanceJob = "ProcessCheckLEInitBalanceJob";
        public const string ExportBillingBoxPartTwoInfoJob = "ExportBillingBoxPartTwoInfoJob";
        public const string MoveEmptyBeneficiaryInfoTransJob = "MoveEmptyBeneficiaryInfoTransJob";
        public const string DateFormat = "yyyyMMdd";
        public const string DateFormatConnect = "MM/dd/yyyy";
        public const string DateTimeFormat = "yyyyMMddHHmmssfff";

        public const string OutputDateFormat = "yyyy.MM.dd";
        public const string OutputDateTimeFormat = "yyyy.MM.dd HH:mm:ss";
        public const string COMMONDATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string BillingBoxPartOneFile = "{0}.1.bbx.zip";
        public const string BillingBoxPartTwoFile = "{0}.2.bbx.zip";
        public const string ServiceFeeBillingBoxFile = "{0}.servicefee.dat";
        public const string ClientBillingBoxFile = "{0}.client.dat";
        public const string ReimbursementBoxFileNew = "{0}.reimbursement.dat";
        public const string Data = "Data";

        public const char Comma = ',';
        public const char And = '&';
        public const char Underline = '_';
        public const char Question = '?';
        public const char Equal = '=';
        public const char Space = ' ';
        public const char Connect = '-';
        public const char BreakLine = '~';
        public const char Dot = '.';
        public const char LeftBracket = '{';
        public const char RightBracket = '}';
        public const char LeftParentheses = '(';
        public const char RightParentheses = ')';
        public const char BackSlash = '\\';
        public const char Slash = '/';
        public const char Percentage = '%';
        public const char Separator = '|';
        public const char Quotation = '"';
        public const char Zero = '0';
        public const string ZERO = "0";
        public const string PdfSuffix = ".pdf";
        public const string XlsSuffix = ".xls";
        public const string DoubleConnect = "--";
        public const string Colon = ";";
        public const string Dollar = "$";
        public const string DatDelimiter = "$|";

        public const string FootNoteTag = "{FOOTNOTE}";
        public const string FileProductPath = "FileProductPath";
        public const string FileOrderPath = "FileOrderPath";
        public const string RepeaterFlag = "$$repeater$$";
    }
}
