using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReadingEx
{
    public class CommonConsts
    {
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

        public const string TAX = "Tax";
        public const string MACHINEKEY = "MachineKey";
        public const string CHANNEL = "Channel";

        public const string Seq_OrderNumber = "Seq_OrderNumber";
        public const string Seq_Merchant_IdentityCode = "Seq_Merchant_IdentityCode";
        public const string Seq_Shop_IdentityCode = "Seq_Shop_IdentityCode";
        public const string SEQ_BATCHTRANSACTIONNUMBER = "Seq_BatchTransactionNumber";
        public const string Seq_Memo_BatchNo = "Seq_MemoBatchNo";
        public const byte Merchant_IdentityCode_Length = 15;
        public const char IdentityCode_PaddingChar = '0';
        public const byte Shop_IdentityCode_Length = 10;

        public const string FeeName_SMSFee = "SMS Fee";
        public const string FeeName_SystemProcessFee = "System Process Fee";
        public const string FeeName_OnDemandPrinting = "On Demand Printing";
        public const string FeeName_EmailFee = "Email Fee";
        public const string FeeName_EmailSMSFee = "Email+SMS Fee";

        public const string SyncAuthJob = "SyncAuthJob";
        public const string SyncDistJob = "SyncDistJob";
        public const string ScanDistJob = "ScanDistJob";

        public const string DateFormat = "yyyyMMdd";
        public const string DateFormatConnect = "MM/dd/yyyy";
        public const string DateTimeFormat = "yyyyMMddHHmmssfff";

        public const string OutputDateFormat = "yyyy.MM.dd";
        public const string OutputDateTimeFormat = "yyyy.MM.dd HH:mm:ss";
        public const string COMMONDATETIMEFORMAT = "yyyy-MM-dd HH:mm:ss";

        public const string CONSUMERCODE = "ConsumerCode";
        public const string SENDER = "Sender";
        public const string SENDERDISPLAYNAME = "SenderDisplayName";
        public const string SERVICEPROVIDERCODE = "ServiceProviderCode";
        public const string SERVICEPROVIDERNAME = "ServiceProviderName";
        public const string MESSAGETYPE = "MessageType";
        public const string ISDEFAULT = "IsDefault";
        public const string WalletImage1 = "WalletImage1";
        public const string WalletImage2 = "WalletImage2";
        public const string SCVBannerImage1 = "SCVBannerImage1";
        public const string EMPTY_RESERVATION_CODE = "#N/A";

        public static readonly DateTime SqlMinDateTime = new DateTime(1900, 1, 1);
        public static readonly DateTime SqlMaxDateTime = new DateTime(3999, 1, 1);

        public const string CT_ProductName = "{PRODUCT_NAME}";
        public const string CT_Name = "{Name}";
        public const string CT_VoucherNumber = "{VOUCHER_NUMBER}";
        public const string CT_ExpiryDate = "{END_DATE}";
        public const string CT_Breakline = "{BREAKLINE}";
        public const string WEB_NEWLINE = "<br/>";
        public const string TAG_SERIALNUMBER = "{SerialNumber}";
        public const string CT_ShortUrl = "{ShortUrl}";
        public const string CT_ShortUrlAuthCode = "{ShortUrlAuthCode}";
        public const string CT_FixFootnote = "{FixFootnote}";
        public const string CT_PinCode = "{PinCode}";
        public const string CT_GUIDURL = "{GUID_URL}";
        public const string TAG_EMAILSUBJECT = "{EmailSubject}";
        public const string TAG_GREETINGS = "{Greetings}";
        public const string TAG_EmailHeaderLogo = "{Client_logo_header}";
        public const string TAG_EmailFooterLogo = "{Client_logo_footer}";
        public const string TAG_SMSGREETINGS = "{SMSGreetings}";
        public const string TAG_STARBUCKSDOWNLOADURL = "{Starbucks.DownloadURL}";
        public const string TAG_STARBUCKSAUTHCODE = "{Starbucks.AuthCode}";
        public const string TAG_STARBUCKSEXPIRYDATE = "{Starbucks.ExpiryDate}";
        public const string TAG_STARBUCKSQRCODE = "{Starbucks.QRCode}";
        public const string TAG_FV = "{FV}";
        public const string CT_CSURL = "{CSURL}";
        public const string TAG_BANNERIMAGE = "{BANNER_IMAGE}";
        public const string TAG_BannerImage_FV = "{BANNER_IMAGE_FV}";
        public const string ROLENAME_Admin = "Admin";
        public const string ROLENAME_VoucherManager = "VoucherManager";
        public const string ROLENAME_PRODUCTMANAGER = "ProductManager";
        public const string ROLENAME_PRODUCTLEADER = "ProductLeader";

        public const string ROLENAME_MAM = "MAM";
        public const string ROLENAME_OperationStaff = "OperationStaff";
        public const string ROLENAME_OperationLeader = "OperationLeader";

        public const string ROLENAME_FINANCESTAFF = "FinanceStaff";
        public const string ROLENAME_FINANCELEADER = "FinanceLeader";
        public const string ROLENAME_SALELEADER = "SaleLeader";
        public const string ROLENAME_READONLY = "ReadOnly";
        public const string SHORTURLBASE = "ShortUrlBase";
        public const string BARCODE1 = "Barcode1";
        public const string BARCODE2 = "Barcode2";
        public const string BARCODE3 = "Barcode3";
        public const string BARCODE4 = "Barcode4";
        public const string CODE = "code";
        public const string SCALE = "scale";
        public const string CodeType = "CodeType";
        public const string DisplayText = "DisplayText";
        public const string CACHENODEID = "CacheNodeId";
        public const string TAG_VOUCHERLOOPSERIAL = "{VoucherLoopSerial}";
        public const string CREATEDFROM = "CreatedFrom";
        public const string CREATEDTO = "CreatedTo";
        public const string TERM = "term";
        public const string BatchMemoList = "BatchMemoList.aspx";

        public const string ClientPortalQuotationNumber = "ClientPortalQuotationNumber";

        public const string VoucherNumberPrefix_711 = "711";
        public const string VoucherNumberPrefix_FMI = "FMI";

        public const string MinimumValue_Eight = "8.5714";
        public const string MinimumValue_Thirteen = "13.3333";
        public const string MinimumValue_Three = "3.8095";

        public const string MarginAnalysis = "MarginAnalysis";

        public const string BillingBoxPartOneFile = "{0}.1.bbx.zip";
        public const string BillingBoxPartTwoFile = "{0}.2.bbx.zip";
        public const string ServiceFeeBillingBoxFile = "{0}.servicefee.dat";
        public const string ClientBillingBoxFile = "{0}.client.dat";
        public const string QuotationBillingBoxFile = "{0}.quotation.dat";
        public const string MerchantBillingBoxFile = "{0}.merchant.dat";
        public const string ShopBillingBoxFile = "{0}.shop.dat";
        public const string ReimbursementBoxFileNew = "{0}.reimbursement.dat";
        public const string TrashRecordExcelFile = "TrashRecordExcel_{0}_{1}001.csv";
        public const string TrashRecordZipFile = "TrashRecord_{0}_{1}001.zip";

        public const string REGEX_VOUCHERVALIDATION = @"^[A-Za-z0-9]{1,50}$";
        public const string REGEX_VOUCHERVALIDATION_IN_AMAZON = @"^[A-Za-z0-9\-]{1,50}$";
        public const string REGEX_MERCHANTCODEVALIDATION = @"^\d{1,50}$";
        public const string REGEX_SHOPCODEVALIDATION = @"^[A-Za-z0-9]{1,50}$";
        public const string REGEX_TERMINALCODEVALIDATION = @"^\d{1,50}$";
        public const string REGEX_RESERVATIONCODE = @"^[a-zA-Z0-9]{1,20}$";

        public const string RepeaterFlag = "$$repeater$$";
        public const string RepeaterEndFlag = "$$repeaterend$$";
        public const string SplitterFlag = "$$splitter$$";
        public const string INTableTag = "{IN.Table}";
        public const string INSVTableTag = "{IN.SV.TABLE}";
        public const string INSVSMSTag = "{IN.SV.SMS}";
        public const string INSMSTag = "{IN.SMS}";
        public const string OrderNumberTag = "{OrderNumber}";
        public const string MessageEncodingTag = "{MessageEncoding}";
        public const string SMSSenderNameTag = "{SMSSenderName}";
        public const string SmsEntityIdTag = "{SMSEntityId}";
        public const string Netcore = "NetCore";

        public const string GrGroupName = "gr.";
        public const string StarBucksGroupName = "starbucks.";
        public const string SeGroupName = "se.";
        public const string FmGroupName = "fm.";
        public const string SwGroupName = "sw.";
        public const string SevenElevenGroupName = "sevenEleven.";
        public const string IQiYiGroupName = "IQiYi.";
        public const string FMBardCodeOneGroupName = "FMBC1.";
        public const string HlGroupName = "hl.";
        public const string PacificCoffeeGroupName = "Pacific.";
        public const string INGroupName = "IN.";
        public const string SGGroupName = "SG.";
        public const string QRCodeGroupName = "QRCode.";
        public const string REGEX_BALANCEAVAILABLE = @"^\d{1,10}$";
        public const string REGEX_BARCODEVALIDATION = @"^[A-Za-z0-9]{1,50}$";
        public const string REGEX_VOUCHERALIAS = @"^[A-Za-z0-9]{10,11}$";
        public const string REGEX_AUTHCODE = @"^[A-Za-z0-9]{4}$";
        public const string REGEX_DateTime = @"^([0-1]?[0-9]/[0-3]?[0-9]/[0-9]{4}|[0-9]{4}/[0-1]?[0-9]/[0-3]?[0-9])$";
        public const string REGEX_DateTimeNullable = @"^([0-1]?[0-9]/[0-3]?[0-9]/[0-9]{4}|[0-9]{4}/[0-1]?[0-9]/[0-3]?[0-9])?$";

        public const string GR_QRCodeOfeCode = "GR.QRCodeOfeCode";
        public const string GR_BarCode128OfeCode = "GR.BarCode128OfeCode";

        public const string BusinessModelTEST = "Test";

        public const string PinCodeSecurityKey = "PinCodeSecurityKey";
        public const string MulesoftAdminPortalSecurityKey = "MulesoftAdminPortalSecurityKey";

        public const string FinanceExpireDays = "FinanceExpireDays";
        public const string FinanceLEBusinessTypes = "FinanceLEBusinessTypes";
        public const string FinanceLEModelTypes = "FinanceLEModelTypes";

        public const string VerificationNumber = "VerificationNumber";
        public const string VoucherNumber = "VoucherNumber";
        public const string BalanceAvailable = "BalanceAvailable";
        public const string REGEX_BarcodeCanNull = @"^[A-Za-z0-9]{0,50}$";
        public const string REGEX_NewVoucherNumber = @"^[A-Za-z0-9\-]{0,50}$";
        public const string REGEX_VerificationNumber = @"^.{0,50}$";
        public const string ClientLogo = "Client_logo";
        public const string ClientLogoTag = "{Brand_Logo}";
        public const string ContentTagCacheKey = "ContentTagCacheKey";
        public const string Digital = "Digital";
        public const string Delivery = "Delivery";
        public const string Paper = "Paper";

        public const int VoucherNotExist = -100;
        public const byte FromThirdParty = 2;
    }

    public enum MessageType : byte
    {
        Email = 1,
        SMS = 2,
        LMS = 3,
        MMS = 4
    }
}
