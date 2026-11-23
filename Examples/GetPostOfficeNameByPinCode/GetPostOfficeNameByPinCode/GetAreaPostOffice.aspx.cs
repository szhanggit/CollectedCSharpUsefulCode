using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetPostOfficeNameByPinCode
{
    public partial class GetAreaPostOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PostOfficeResult postOfficeResult = null;
            try
            {
                string userAuthenticationURI = "http://postalpincode.in/api/pincode/" + txtPinCode.Text.Trim();

                if (!string.IsNullOrEmpty(userAuthenticationURI))
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userAuthenticationURI);
                    request.Method = "GET";
                    request.ContentType = "application/json";
                    WebResponse response = request.GetResponse();
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        var ApiStatus = reader.ReadToEnd();
                        JsonData data = JsonMapper.ToObject(ApiStatus);
                        string status = data["Status"].ToString();
                        if (status.ToLower() == "success")
                        {
                            postOfficeResult = JsonMapper.ToObject<PostOfficeResult>(ApiStatus);

                        }
                        if (postOfficeResult != null)
                        {
                            grdAreaPostOffice.DataSource = postOfficeResult.PostOffice;
                            grdAreaPostOffice.DataBind();
                        }
                        else
                        {
                            lblMessage.Text = data["Message"].ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}