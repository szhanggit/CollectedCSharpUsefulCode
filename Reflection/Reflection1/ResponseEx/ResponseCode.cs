using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseEx
{
    public class ResponseCode
    {
        public static readonly string A411 = "Port number must be numeric";
        public static readonly string A415 = "Invalid xml/Invalid Json";
        public static readonly string A416 = "Invalid Message ID/Mobile";
        public static readonly string A417 = "Invalid Message ID/Mobile";
        public static readonly string A418 = "Invalid Group ID/Campaign";
        public static readonly string A419 = "Invalid Group ID/Campaign";
        public static readonly string A430 = "Invalid Group ID";
        public static readonly string A431 = "Invalid Group ID";
        public static readonly string A432 = "Campaign already completed/Campaign already cancelled";
        public static readonly string A433 = "Schedule time already passed";
        public static readonly string A434 = "Campaign within next 15 minutes cannot be modified/canceled.";
        //Caughtion:There are tow A434 in https://www.solutionsinfini.com/sms-api , for processing, set one of them to A435
        public static readonly string A435 = "Invalid schedule time. Minimum 15 min time gap is required.";
        public static readonly string E601 = "Missing receipent";
        public static readonly string E603 = "Missing message";
        public static readonly string E602 = "Missing senderid";
        public static readonly string E604 = "Senderid must be less than 14 chars";
        public static readonly string E605 = "Invalid Sender or Sender not allowed";
        public static readonly string E606 = "Invalid schedule time. Minimum 15 min time gap is required.";
        public static readonly string E606A = "Batch size should be greater or equal to 1000";
        public static readonly string E606B = "Schedule minute should be in multiples of 15. minimum 15 minute";
        public static readonly string E612 = "Invalid Template Matched";
        public static readonly string E607 = "SMS length is exceeding 1000 characters";
        public static readonly string E607A = "Unable to find gateway to sent sms.";
        public static readonly string E608 = "No Valid mobile numbers found";
        public static readonly string E608A = "Your daily usage limit exceeded";
        public static readonly string E609 = "An error occured while saving group details";
        public static readonly string E610 = "Unable to write to temp files";
        public static readonly string E611 = "Unable to process your request. try again";
        public static readonly string H601 = "Insufficent credits. Total 1. Required 1 more credits.";
    }
}
