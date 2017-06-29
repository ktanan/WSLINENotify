using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LINENotify.App_Code.smsHttp;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    smsHttp sendSMShttp = new smsHttp();
    public Service () {

        //Uncomment the following line if using designed components
        //InitializeComponent();
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public string WS001_PostMsgHttp(string prmText)
    {
        string StrSuccess = "";
        try
        {
            StrSuccess = sendSMShttp.SendMsgHttp(prmText);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            StrSuccess = ex.Message;
        }
        return StrSuccess;
    }

}
