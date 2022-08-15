using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjectManagement.Infrastructures.Helper
{
    public class SmsSendByBanglalinkFromPms
    {
        public long SmsSendByBanglalink(string mobileNumber,String message)
        {
            long returnResult = 0;

            const string userId = "whtil";
            const string passwd = "";
            const string smsSender = "";

            var apiUrl = String.Format(@"https://vas.sms.com/sendSMS/sendSMS?msisdn={0}&message={1}&userID={2}&passwd={3}&sender={4}", mobileNumber, message, userId, passwd, smsSender);

            var request = (HttpWebRequest)WebRequest.Create(apiUrl);

            using (var response = (HttpWebResponse)request.GetResponse())
            {

                using (var stream = response.GetResponseStream())
                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            var html = reader.ReadToEnd();

                            //Success Count : 1 and Fail Count : 1
                            if (html.Contains("Success Count : 1") || html.Contains("Success Count : 2"))
                            {
                                returnResult = 1;
                            }
                        }
            }


            return returnResult;
        }



    }
}
