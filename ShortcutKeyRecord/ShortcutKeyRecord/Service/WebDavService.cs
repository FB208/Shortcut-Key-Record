using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using ShortcutKeyRecord.Helper;

namespace ShortcutKeyRecord.Service
{
    public class WebDavService
    {
        HttpWebRequest request;
        private string uri = "https://dav.jianguoyun.com/dav/";
        public WebDavService()
        {
            
            
            if (uri.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) =>
                {
                    return true; //总是接受  
                });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }
        }

        /// <summary>
        /// 示例代码，目前只能获取根目录
        /// </summary>
        public string List()
        {
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PROPFIND";
            request.Credentials = new NetworkCredential("472189065@qq.com", "ayg36ddq6vcxzipc");
            var response = request.GetResponse();
            XDocument doc = XDocument.Load(response.GetResponseStream());

            var files = doc.Descendants("{DAV:}response")
                .Select(x => new
                {
                    Name = x.Element("{DAV:}propstat").Element("{DAV:}prop").Element("{DAV:}displayname").Value,
                    //Size = x.Element("{d:}propstat").Element("{d:}prop").Element("{d:}getcontentlength").Value
                });
            StringBuilder sb = new StringBuilder();
            foreach (var file in files)
            {
                sb.Append(file.Name + "|");
            }

            return sb.ToString();
        }

        public void Upload()
        {
            request = (HttpWebRequest)WebRequest.Create(uri + "SimpRead/test.json");
            request.Credentials = new NetworkCredential("472189065@qq.com", "ayg36ddq6vcxzipc");
            request.Method = "PUT";
            //request.AllowWriteStreamBuffering = true;
            //request.PreAuthenticate=true;

            using (Stream requestStream = request.GetRequestStream())
            {
                using (var fs = File.OpenRead(@"C:\Users\Administrator\Downloads\ShortcutKeyRecord.config.json"))
                {
                    byte[] inData = new byte[4096];
                    int byteRead = fs.Read(inData, 0, inData.Length);  //二进制读文件
                    while (byteRead > 0)
                    {
                        requestStream.Write(inData, 0, byteRead); //响应流写入
                        byteRead = fs.Read(inData, 0, inData.Length);
                    }
                }

                var response = request.GetResponse();
            }
            
            
        }

        /// <summary>
        /// 下载并解析文件内容，未完成
        /// </summary>
        public void Download()
        {
            request = (HttpWebRequest)WebRequest.Create(uri+ "SimpRead/simpread_config.json");
            request.Method = "GET";
            request.Credentials = new NetworkCredential("472189065@qq.com", "ayg36ddq6vcxzipc");
            System.Net.WebResponse res = request.GetResponse();//返回对 Internet 请求的响应
            System.IO.Stream inStream = res.GetResponseStream();
            BinaryReader reader = new BinaryReader(inStream);
            byte[] btyChunk = new byte[4096];
            byte[] buffer = new byte[(int)res.ContentLength];//申请文件大小所需空间
            try
            {
                int count = 0;
                int i = 0;
                while ((count = reader.Read(btyChunk, 0, btyChunk.Length)) > 0)
                {
                    Array.Copy(btyChunk, 0, buffer, i, count);//复制数据
                    i = i + count;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            string content =FileHelper.Bytes2String(buffer);
        }
    }
}
