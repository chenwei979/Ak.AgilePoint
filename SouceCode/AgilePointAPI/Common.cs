using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml.Linq;
using System.Xml;

namespace AgilePointAPI
{


    class Common
    {
    }


    public class HTTPOperations
    {
        string domain = string.Empty;
        string userName = string.Empty;
        string password = string.Empty;
        string appID = string.Empty;
        string locale = string.Empty;
        string contenttype = string.Empty;

        public HTTPOperations(string Domain, string UserName, string Password, string AppID, string Locale)
        {
            domain = Domain;
            userName = UserName;
            password = Password;
            appID = AppID;
            locale = Locale;
        }

        #region Create Http Request

        public HttpWebRequest GetHttpRequest(string URI, string Method)
        {
            //---------- Creat a request with required URI
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);

            request.Method = Method;

            //Set Content Type
            request.ContentType = "application/json";
            //Set Accept Type
            request.Accept = "application/json";

            //Setting Header
            //Creating Authorizationheader format (Basic (base64(domain\\username:password))
            request.Headers[HttpRequestHeader.Authorization] =
              "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(domain + "\\" + userName + ":" + password));
            request.Headers["appID"] = appID;
            request.Headers["locale"] = locale;
            //request.Timeout = 100000;
            //request.KeepAlive = false;
            //ServicePointManager.ServerCertificateValidationCallback += 
            //         new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
            return request;
        }

        #endregion

        #region POST Method

        public string POSTMethod(string URI, string JsonRequestData)
        {

            HttpWebRequest request = GetHttpRequest(URI, WebRequestMethods.Http.Post);

            //------------POST ing data to Server

            request.ContentLength = JsonRequestData.Length;
            Stream content = request.GetRequestStream();
            StreamWriter ContentWriter = new StreamWriter(content);
            ContentWriter.Write(JsonRequestData);
            ContentWriter.Close();

            HttpWebResponse webResponse = null;
            try
            {
                //-------- geting response from request
                webResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                throw ex;
            }

            string jsonResponseData = ReadData(webResponse);

            return jsonResponseData;

        }

        public string PostXml(string url, string xml)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(xml);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "application/xml";
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader rdStreamRdr = new StreamReader(resStream);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("POST failed. Received HTTP {0}",
                    response.StatusCode);
                    throw new ApplicationException(message);
                }
                else
                {
                    string message = rdStreamRdr.ReadToEnd();
                    return message;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string POSTMethod(string URI)
        {
            HttpWebRequest request = GetHttpRequest(URI, WebRequestMethods.Http.Post);

            //------------POST ing data to Server

            //request.ContentLength = JsonRequestData.Length;
            Stream content = request.GetRequestStream();
            StreamWriter ContentWriter = new StreamWriter(content);
            //ContentWriter.Write();
            ContentWriter.Close();

            HttpWebResponse webResponse = null;
            try
            {
                //-------- geting response from request
                webResponse = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                throw ex;
            }

            string jsonResponseData = ReadData(webResponse);

            return jsonResponseData;
        }

        #endregion

        #region GET Method

        public string GetData(string URI)
        {
            HttpWebRequest request = GetHttpRequest(URI, WebRequestMethods.Http.Get);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string jsonResponseData = ReadData(response);

                return jsonResponseData;
            }
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            catch (Exception ex)
            {
                //LogServiceException(ex);
                throw ex;
            }

        }

        #endregion

        string ReadData(HttpWebResponse webResponse)
        {
            string jsonResponseData = string.Empty;
            try
            {
                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    //Stream webStream = webResponse.GetResponseStream();
                    StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                    jsonResponseData = responseReader.ReadToEnd();

                    responseReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jsonResponseData;
        }

    }
}
