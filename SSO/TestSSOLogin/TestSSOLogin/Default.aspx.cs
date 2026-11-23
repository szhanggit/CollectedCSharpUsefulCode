using ERAuth.ClientLib;
using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestSSOLogin
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = SecurityHelper.CurrentUser.UserName;
            List<string> RoleNameList = SecurityHelper.CurrentUser.RoleNames;
            string Email = SecurityHelper.CurrentUser.Email;
            string Title = SecurityHelper.CurrentUser.Title;
            string Department = SecurityHelper.CurrentUser.Department;
            List<ERAuth.ServiceDataContract.Permission> permissionList = ApplicationManager.Instance.CurrentAppInfo.Permissions;
            List<ERAuth.ServiceDataContract.Menu> menuList = ApplicationManager.Instance.CurrentAppInfo.Menus;

            if (SecurityHelper.CurrentUser.IsInRole("asdf"))
            {

            }
            else
            {

            }                

            if (SecurityHelper.CurrentUser.IsInApp("MyTestAppWithSSO"))
            {

            }
            else
            {

            }

            bool b = SecurityHelper.CheckResourcePermission("Product", "SaveAndApplyToOrder", SecurityHelper.CurrentUser.RoleNames, ApplicationManager.Instance.CurrentAppInfo.Permissions);




            var fam = FederatedAuthentication.WSFederationAuthenticationModule;
            fam.SignOut(false);

            var signOutRequest = new SignOutRequestMessage(new Uri(fam.Issuer), fam.SignOutReply);

            HttpContext.Current.Response.Redirect(signOutRequest.WriteQueryString());
        }
    }
}