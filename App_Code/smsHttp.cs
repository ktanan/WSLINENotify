using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
//using System.Xml;
using System.Globalization;
using System.Collections;
using System.Web.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


/// <summary>
/// Summary description for smsHttp
/// </summary>
namespace LINENotify.App_Code.smsHttp
{
    public class smsHttp
    {
        private string m_LastError;
        private string m_UdpDate = DateTime.Now.ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("en-AU", false));
        private string m_UdpTime = DateTime.Now.GetDateTimeFormats()[102].ToString().Trim();
        private string m_YYYY = DateTime.Now.GetDateTimeFormats()[5].Substring(6, 4);

        public smsHttp()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string SendMsgHttp(string msg)
       {
            string blSucess ="";
           try
           {
                string UrlAPI = ConfigurationManager.AppSettings["LINI_URi"].ToString();
                var request = (HttpWebRequest)WebRequest.Create(UrlAPI);
                var postData = string.Format("message={0}", msg);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer d1ZTxSzN7AXWAcbvobXQ5EkJqNAIg4P3v82gXNGWw82");

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                blSucess = responseString.ToString();

            }
           catch (Exception ex)
            {
                m_LastError = ex.Message;
                blSucess = ex.Message;
            }
            return blSucess;
       }
    }
}
