using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailTemplateProcessing
{
    public class Consts
    {
        /* Define your project constants here   
        //Basic consts
        public static readonly int NO_ID = -999;
        public static readonly string ANONYMOUS_USER_NAME = "Anonymous";
        public static readonly string ENCRYPTION_PURPOSE_OBJ_REF = "EncryptionPurposeObjRef";
        */

        //System
        public static readonly string SYS_NOT_OPEN = "EX000";

        //General
        public static readonly string RETDTO_GENERAL_SUCCESS = "0000";
        public static readonly string RETDTO_GENERAL_FAILURE = "EX101";
        public static readonly string RETDTO_GENERAL_UNKNOWN = "EX102";

        //Consumer
        public static readonly string CONSUMER_NOT_EXIST_OR_NOT_OPEN = "EX200";
        public static readonly string CONSUMER_CODE_NOT_EMPTY = "EX201";

        //Provider
        public static readonly string PROVIDER_NOT_EXIST_OPEN = "EX300";
        public static readonly string PROVIDER_CODE_NOT_EMPTY = "EX301";

        //Task
        public static readonly string TASK_INVALID_TEMPLATE = "EX400";
        public static readonly string TASK_NOT_EXIST = "EX401";
        public static readonly string TASK_CANNOT_BE_DELETED = "EX402";
        public static readonly string TASK_INVALID_LOCALID = "EX403";
        public static readonly string TASK_INVALID_PRIORITY = "EX404";
        public static readonly string TASK_MESSAGES_NOT_EMPTY = "EX405";
        public static readonly string TASK_INVALID_TIMEZONEOFFSET = "EX407";
        public static readonly string RETDTO_TASK_INVALID_SENDER_EMAIL_ADDRESS = "EX408";
        public static readonly string TASK_CONVERT2EMAILMESSAGETEMPLATEENTITY_EXCEPTION = "EX409";
        public static readonly string TASK_CONVERT2EMAILTASKENTITY_EXCEPTION = "EX410";
        public static readonly string TASK_SAVEEMAILTASK2DB_EXCEPTION = "EX411";
        public static readonly string TASK_CONVERT2SLMSTASKENTITY_EXCEPTION = "EX412";
        public static readonly string TASK_SAVESLMSTASK2DB_EXCEPTION = "EX413";
        public static readonly string TASK_INVALID_MESSAGE_TYPE = "EX414";
        public static readonly string TASK_HAVE_NO_MESSAGE = "EX415";
        public static readonly string TASK_RESENDOPTION_TOBERESENDALL_TOBERESENTFAIL = "EX416";
        public static readonly string TASK_CANNOT_BE_RESEND = "EX417";
        public static readonly string TASK_TRIEDCOUNT_LESS = "EX418";

        //Message
        public static readonly string RETDTO_EMAIL_ADDRESS_INVALID = "EX500";
        public static readonly string RETDTO_EMAIL_ADDRESS_EMPTY = "EX501";
        public static readonly string MESSAGE_NOT_EXIST = "EX502";
        public static readonly string MESSAGE_CANNOT_BE_DELETED = "EX503";
        public static readonly string RETDTO_MESSAGE_LOCALID_NOT_EMPTY = "EX504";
        public static readonly string MESSAGE_INVALID_EMAIL_TO_ADDRESS = "EX505";
        public static readonly string MESSAGE_INVALID_EMAIL_CC_ADDRESS = "EX506";
        public static readonly string MESSAGE_INVALID_EMAIL_BCC_ADDRESS = "EX507";
        public static readonly string MESSAGE_CONVERT2EMAILMESSAGEENTITY_EXCEPTION = "EX508";
        public static readonly string MESSAGE_CONVERT2SLMSMESSAGEENTITY_EXCEPTION = "EX509";
        public static readonly string MESSAGE_INVALID_LOCALID = "EX510";
        public static readonly string RETDTO_MESSAGE_MOBILEPHONE_NOT_EMPTY = "EX511";
        public static readonly string MESSAGE_CANNOT_BE_RESEND = "EX512";

        public static readonly string RepeaterFlag = "$$repeater$$";
        public static readonly string RepeaterEndFlag = "$$repeaterend$$";
        public const string SplitterFlag = "$$splitter$$";
        public const string INTableTag = "{IN.Table}";
        public const string INSVTableTag = "{IN.SV.TABLE}";

        public static readonly string OrderNumberTag = "{OrderNumber}";
        public static readonly string SMSSenderNameTag = "{SMSSenderName}";
        public static readonly string SmsEntityIdTag = "{SMSEntityId}";

        public static readonly string SendinBlue = "sendinblue";
        public static readonly string Smexpress = "smexpress";
        public static readonly string Solutionsinfini = "solutionsinfini";
        public static readonly string NetCore = "netcore";
        public static readonly string MessageSPIdUnknown = "#NA";
    }
}
