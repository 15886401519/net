using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve.Tool
{
    public class HttpRequestClient
    {

        public string defaultHeaders = @"Accept:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
Accept-Encoding:gzip, deflate, sdch
Accept-Language:zh-CN,zh;q=0.8
Cache-Control:no-cache
Connection:keep-alive
Pragma:no-cache
Upgrade-Insecure-Requests:1
User-Agent:Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.71 Safari/537.36";

        /// <summary>
        /// 是否跟踪cookies
        /// </summary>
        bool isTrackCookies = false;
        /// <summary>
        /// cookies 字典
        /// </summary>
        Dictionary<String, Cookie> cookieDic = new Dictionary<string, Cookie>();

        long avgResponseMilliseconds = -1;
        public long AvgResponseMilliseconds
        {
            get
            {
                return avgResponseMilliseconds;
            }

            set
            {
                if (avgResponseMilliseconds != -1)
                {
                    avgResponseMilliseconds = value + avgResponseMilliseconds / 2;
                }
                else
                {
                    avgResponseMilliseconds = value;
                }

            }
        }

        /// <summary>
        /// http请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method">POST,GET</param>
        /// <param name="headers">http的头部,直接拷贝谷歌请求的头部即可</param>
        /// <param name="content">content,每个key,value 都要UrlEncode才行</param>
        /// <param name="contentEncode">content的编码</param>
        /// <param name="proxy">是否启用代理</param>
        /// <returns></returns>
        public string http(string url, string method, string headers, string content, Encoding contentEncode, bool isProxy, string cookiesHeader)
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            if (method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
            {
                request.MaximumAutomaticRedirections = 100;
                request.AllowAutoRedirect = false;
            }

            fillHeaders(request, headers, true);
            fillProxy(request, isProxy);
            request.Headers[HttpRequestHeader.Cookie] = cookiesHeader;
            #region 添加Post 参数  
            if (contentEncode == null)
            {
                contentEncode = Encoding.UTF8;
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                byte[] data = contentEncode.GetBytes(content);
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
            }
            #endregion

            HttpWebResponse response = null;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                sw.Start();
                response = (HttpWebResponse)request.GetResponse();
                sw.Stop();
                AvgResponseMilliseconds = sw.ElapsedMilliseconds;

                //string cookieString = response.Headers[HttpResponseHeader.SetCookie];
                //var cc = cookieString2Collection(cookieString);
                //trackCookies(cc);
            }
            catch
            {
                sw.Stop();
                AvgResponseMilliseconds = sw.ElapsedMilliseconds;
                return "";
                //throw ex;
            }
            result = getResponseBody(response);
            return result;
        }


        public string GetStream(string url, string method, string headers, string content, Encoding contentEncode, bool isProxy, string cookiesHeader)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Timeout = 15000;
            if (method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
            {
                request.MaximumAutomaticRedirections = 100;
                request.AllowAutoRedirect = false;
            }

            fillHeaders(request, headers, true);
            fillProxy(request, isProxy);
            request.Headers[HttpRequestHeader.Cookie] = cookiesHeader;
            #region 添加Post 参数  
            if (contentEncode == null)
            {
                contentEncode = Encoding.UTF8;
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                byte[] data = contentEncode.GetBytes(content);
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
            }
            #endregion

            HttpWebResponse response = null;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                //string cookieString = response.Headers[HttpResponseHeader.SetCookie];
                //var cc = cookieString2Collection(cookieString);
                //trackCookies(cc);
            }
            catch
            {
                return "";
            }
            return getResponseStream(response);
        }

        public string Locationhttp(string url, string method, string headers, string content, Encoding contentEncode, bool isProxy, string cookiesHeader)
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            if (method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
            {
                request.MaximumAutomaticRedirections = 100;
                request.AllowAutoRedirect = false;
            }

            fillHeaders(request, headers, true);
            fillProxy(request, isProxy);
            request.Headers[HttpRequestHeader.Cookie] = cookiesHeader;
            #region 添加Post 参数  
            if (contentEncode == null)
            {
                contentEncode = Encoding.UTF8;
            }
            if (!string.IsNullOrWhiteSpace(content))
            {
                byte[] data = contentEncode.GetBytes(content);
                request.ContentLength = data.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
            }
            #endregion

            HttpWebResponse response = null;
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            try
            {
                sw.Start();
                response = (HttpWebResponse)request.GetResponse();
                sw.Stop();
                AvgResponseMilliseconds = sw.ElapsedMilliseconds;
                return response.Headers["location"];

                //string cookieString = response.Headers[HttpResponseHeader.SetCookie];
                //var cc = cookieString2Collection(cookieString);
                //trackCookies(cc);
            }
            catch
            {
                sw.Stop();
                AvgResponseMilliseconds = sw.ElapsedMilliseconds;
                return "";
                //throw ex;
            }
        }

        private CookieCollection cookieString2Collection(string cookieString)
        {
            CookieCollection cc = new CookieCollection();
            //string cookieString = response.Headers[HttpResponseHeader.SetCookie];
            if (!string.IsNullOrWhiteSpace(cookieString))
            {
                var spilit = cookieString.Split(';');
                foreach (string item in spilit)
                {
                    if (item.Equals("Path=/", StringComparison.InvariantCultureIgnoreCase))
                        continue;
                    var kv = item.Split('=');
                    if (kv.Length == 2)
                    {
                        if (kv[0].Trim().StartsWith("HttpOnly,", StringComparison.InvariantCultureIgnoreCase))
                        {
                            var cookie = new Cookie(kv[0].Trim().Remove(0, "HttpOnly,".Length), kv[1].Trim());
                            cc.Add(cookie);
                        }
                        else
                        {
                            var cookie = new Cookie(kv[0].Trim(), kv[1].Trim());
                            cc.Add(cookie);
                        }
                    }

                }
            }
            return cc;
        }


        /// <summary>
        /// get 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="content"></param>
        /// <param name="proxyUrl"></param>
        /// <returns></returns>
        public string httpGet(string url, string headers, string content = null, bool isProxy = true, string cookiesHeader = null)
        {
            return http(url, "GET", headers, null, null, isProxy, cookiesHeader);
        }


        /// <summary>
        /// get请求下载 文件流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="content"></param>
        /// <param name="isProxy"></param>
        /// <param name="cookiesHeader"></param>
        /// <returns></returns>
        public string HttpDown(string url, string headers, string content = null, bool isProxy = true, string cookiesHeader = null)
        {
            return GetStream(url, "GET", headers, null, null, isProxy, cookiesHeader);
        }

        /// <summary>
        /// 填充代理
        /// </summary>
        /// <param name="proxyUri"></param>
        private void fillProxy(HttpWebRequest request, bool isProxy = true)
        {
            if (isProxy)
            {
                WebProxy proxy = new WebProxy();
                proxy.Address = new Uri("http://http-dyn.abuyun.com:9020");
                proxy.Credentials = new NetworkCredential("H9920I05529A4DED", "C8E2DB61DFD06F0C");
                request.Proxy = proxy;
                ServicePointManager.Expect100Continue = false;
            }
        }


        /// <summary>
        /// 跟踪cookies
        /// </summary>
        /// <param name="cookies"></param>
        private void trackCookies(CookieCollection cookies)
        {
            if (!isTrackCookies) return;
            if (cookies == null) return;
            foreach (Cookie c in cookies)
            {
                if (cookieDic.ContainsKey(c.Name))
                {
                    cookieDic[c.Name] = c;
                }
                else
                {
                    cookieDic.Add(c.Name, c);
                }
            }

        }

        /// <summary>
        /// 格式cookies
        /// </summary>
        /// <param name="cookies"></param>
        private string getCookieStr()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Cookie> item in cookieDic)
            {
                if (!item.Value.Expired)
                {
                    if (sb.Length == 0)
                    {
                        sb.Append(item.Key).Append("=").Append(item.Value.Value);
                    }
                    else
                    {
                        sb.Append("; ").Append(item.Key).Append(" = ").Append(item.Value.Value);
                    }
                }
            }
            return sb.ToString();

        }

        private HashSet<String> GetUNCHANGEHEADS()
        {
            HashSet<String> UNCHANGEHEADS = new HashSet<string>();
            UNCHANGEHEADS.Add("Host");
            UNCHANGEHEADS.Add("Connection");
            UNCHANGEHEADS.Add("User-Agent");
            UNCHANGEHEADS.Add("Referer");
            UNCHANGEHEADS.Add("Range");
            UNCHANGEHEADS.Add("Content-Type");
            UNCHANGEHEADS.Add("Content-Length");
            UNCHANGEHEADS.Add("Expect");
            UNCHANGEHEADS.Add("Proxy-Connection");
            UNCHANGEHEADS.Add("If-Modified-Since");
            UNCHANGEHEADS.Add("Keep-alive");
            UNCHANGEHEADS.Add("Accept");
            return UNCHANGEHEADS;
        }

        /// <summary>
        /// 填充头
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headers"></param>
        private void fillHeaders(HttpWebRequest request, string headers, bool isPrint = false)
        {
            if (request == null) return;
            if (string.IsNullOrWhiteSpace(headers)) return;
            string[] hsplit = headers.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in hsplit)
            {
                string[] kv = item.Split(':');
                string key = kv[0].Trim();
                string value = string.Join(":", kv.Skip(1)).Trim();
                if (!GetUNCHANGEHEADS().Contains(key))
                {
                    request.Headers.Add(key, value);
                }
                else
                {
                    #region  设置http头
                    switch (key)
                    {

                        case "Accept":
                            {
                                request.Accept = value;
                                break;
                            }
                        case "Host":
                            {
                                request.Host = value;
                                break;
                            }
                        case "Connection":
                            {
                                if (value == "keep-alive")
                                {
                                    request.KeepAlive = true;
                                }
                                else
                                {
                                    request.KeepAlive = false;//just test
                                }
                                break;
                            }
                        case "Content-Type":
                            {
                                request.ContentType = value;
                                break;
                            }

                        case "User-Agent":
                            {
                                request.UserAgent = value;
                                break;
                            }
                        case "Referer":
                            {
                                request.Referer = value;
                                break;
                            }

                        case "Content-Length":
                            {
                                request.ContentLength = Convert.ToInt64(value);
                                break;
                            }
                        case "Expect":
                            {
                                request.Expect = value;
                                break;
                            }
                        case "If-Modified-Since":
                            {
                                request.IfModifiedSince = Convert.ToDateTime(value);
                                break;
                            }
                        default:
                            break;
                    }
                    #endregion
                }
            }
            if (isTrackCookies)
            {
                string cookieString = request.Headers[HttpRequestHeader.Cookie];
                var cc = cookieString2Collection(cookieString);
                trackCookies(cc);
            }
            if (!isTrackCookies)
            {
                request.Headers[HttpRequestHeader.Cookie] = "";
            }
            else
            {
                request.Headers[HttpRequestHeader.Cookie] = getCookieStr();
            }

            #region 打印头
            if (isPrint)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < request.Headers.AllKeys.Length; i++)
                {
                    string key = request.Headers.AllKeys[i];
                    sb.AppendLine(key + ":" + request.Headers[key]);
                }
                string allHeader = sb.ToString();
            }
            #endregion

        }

        /// <summary>
        /// 返回body内容
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string getResponseBody(HttpWebResponse response)
        {
            Encoding defaultEncode = Encoding.UTF8;
            string contentType = response.ContentType;
            if (contentType != null)
            {
                if (contentType.ToLower().Contains("gb2312"))
                {
                    defaultEncode = Encoding.GetEncoding("gb2312");
                }
                else if (contentType.ToLower().Contains("gbk"))
                {
                    defaultEncode = Encoding.GetEncoding("gbk");
                }
                else if (contentType.ToLower().Contains("zh-cn"))
                {
                    defaultEncode = Encoding.GetEncoding("zh-cn");
                }
            }

            string responseBody = string.Empty;
            if (!string.IsNullOrEmpty(response.ContentEncoding))
            {
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, defaultEncode))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, defaultEncode))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, defaultEncode))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
            }
            return responseBody;
        }


        private string getResponseStream(HttpWebResponse response)
        {
            try
            {
                string basepath = AppContext.BaseDirectory;
                DateTime dt = DateTime.Now;
                var name = Guid.NewGuid() + ".pdf";
                string path = "doi/" + dt.Year + "/" + dt.Month + "/" + dt.Day + "/";
                if (!System.IO.Directory.Exists(basepath + path))
                    System.IO.Directory.CreateDirectory(basepath + path);
                using (Stream stream = response.GetResponseStream())
                {
                    if (response.ContentLength > 0)
                    {
                        using (FileStream writer = new FileStream(basepath + path + name, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            byte[] buff = new byte[1024];
                            int c = 0; //实际读取的字节数
                            while ((c = stream.Read(buff, 0, buff.Length)) > 0)
                            {
                                writer.Write(buff, 0, c);
                            }
                            return path + name;
                        }
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }


    }
}
