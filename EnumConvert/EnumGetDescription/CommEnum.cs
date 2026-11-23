using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGetDescription
{
    public enum VoucherStatus
    {
        [Description("未知")]
        unKnow = 0,
        [Description("已發行")]
        Issued = 1,
        [Description("可使用")]
        Active = 2,
        [Description("已過期")]
        Expired = 4,
        [Description("已失效")]
        Trashed = 8,
        [Description("已申請退貨")]
        Blocked = 16,
        [Description("已使用")]
        Used = 32,
        [Description("庫存")]
        InStock = 64
    }

    public enum TranType
    {
        [Description("核銷")]
        Redemption = 101,
        [Description("取消核銷")]
        ReverseRedemption = 201,
        PreAuthorization = 102,
        ReversePreAuthorization = 202,
        [Description("核銷")]
        PreAuthorizationComplete = 103,
        [Description("取消核銷")]
        ReversePreAuthorizationComplete = 203,
        AccountVerification = 104,
        BalanceEnquiry = 105,
        PosTest = 301,
        Issue = 401,
        ReverseIssue = 501,
        Activate = 402,
        ReverseActivate = 502,
        Expire = 403,
        ReverseExpire = 503,
        PreAuthorizationExpire = 106,
        Reload = 107,
        ReverseReload = 207,
        TrashMoney = 404,
        TrashNoMoney = 405
    }
}
