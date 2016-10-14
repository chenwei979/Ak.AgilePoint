using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Text;


namespace SendPost
{
    class Program
    {
        static void Main(string[] args)
        {
          //  string url = "https://api.weixin.qq.com/cgi-bin/groups/update";
          //  string data = string.Format("access_token={0}&openid={0}&to_groupid={1}",
          //      "EbbNCL1DoCdhopQL2pfvTCi-xsmwmk21c-hxsT0FgYxOCYGkGgfvWOBdlcu-bdoYvEd4QubrxMr3gKJVYIpoTjfXQ8haLe3helYznVVwuyex9xzC6R2Vcdq2c3ZwZxx8OZDgAFAJUY",
          //         "ocJIHwUgA3zFmkknaiCJc_GYlvM0",
          //         100);

          //  //WebChatHelper.HttpPost(url, data);



          ////  string postString = "arg1=a&arg2=b";//这里即为传递的参数，可以用工具抓包分析，也可以自己分析，主要是form里面每一个name都要加进来  
          //  byte[] postData = Encoding.UTF8.GetBytes(data);//编码，尤其是汉字，事先要看下抓取网页的编码方式  
          //  //string url = "http://localhost/register.php";//地址  
          //  WebClient webClient = new WebClient();
          //  webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
          //  byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
          //  string srcString = Encoding.UTF8.GetString(responseData);//解码  

            string tem = "'openid':'{0}','to_groupid':{1}";
            string temr = string.Format(tem,"22","333");
            tem = "{" + temr + "}";
            Console.WriteLine(tem);

        }

    }

    public static class WebChatHelper
    {

        /// <summary>
        /// POST请求与获取结果
        /// </summary>
        public static string HttpPost(string Url, string postDataStr)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            //Stream myRequestStream = request.GetRequestStream();
            //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            //myStreamWriter.Write(postDataStr);
            //myStreamWriter.Close();
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();
            //return retString;


            //string postString = "arg1=a&arg2=b";//这里即为传递的参数，可以用工具抓包分析，也可以自己分析，主要是form里面每一个name都要加进来  
            //byte[] postData = Encoding.UTF8.GetBytes(postString);//编码，尤其是汉字，事先要看下抓取网页的编码方式  
            //string url = "http://localhost/register.php";//地址  
            //WebClient webClient = new WebClient();
            //webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可  
            //byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流  
            //string srcString = Encoding.UTF8.GetString(responseData);//解码 
            return "";
        }
    }

}
