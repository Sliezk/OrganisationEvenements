using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class WebServiceParking
    {

        public static T getJsonResponse<T>(string URL, T item)
        {
            HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
            HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
            //List<T> items = null;
            try
            {
                //Create Request
                myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(URL);
                myHttpWebRequest.Method = WebRequestMethods.Http.Get;
                myHttpWebRequest.ContentType = "application/json; charset=utf-8";
                myHttpWebRequest.Accept = "application/json";

                //Get Response
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                string jsonString;
                using (Stream stream = myHttpWebResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                item = JsonConvert.DeserializeObject<T>(jsonString);

            }
            catch (Exception myException)
            {
                throw new Exception("Error Occurred in getJsonResponse", myException);
            }
            finally
            {
                myHttpWebRequest = null;
                myHttpWebResponse = null;
            }
            return item;
        }

    }
}
