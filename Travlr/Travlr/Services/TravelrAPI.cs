using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Travlr.Services
{
    public class TravelrAPI
    {
        private const string endPoint = "https://staging.hero.travel/api/v2";
        private const string appKey = "app_Key";
        private static string GetAPIJsonResult(string url, string method)
        {
            string resultUrl = string.Empty;
            try
            {
                WebRequest requestObject = WebRequest.Create(url);
                requestObject.Method = method;
                HttpWebResponse responseObject = null;
                responseObject = (HttpWebResponse)requestObject.GetResponse();

                using (Stream stream = responseObject.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    resultUrl = sr.ReadToEnd();
                    sr.Close();
                }
                return resultUrl;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        public static string GetProducts()
        {
            string apiUrl = String.Format("{0}/products?app_id={1}", endPoint, appKey);
            return GetAPIJsonResult(apiUrl, "GET");
        }

        public static string GetProductById(string id)
        {
            string apiUrl = String.Format("{0}/products/{1}?app_id={2}", endPoint, id, appKey);
            return GetAPIJsonResult(apiUrl, "GET");
        }
    }
}