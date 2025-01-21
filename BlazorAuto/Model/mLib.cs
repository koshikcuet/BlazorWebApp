using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Dapper;

namespace BlazorAuto
{
    public class mLib
    {

        public static string getCon(int db = 0)
        {
            
            string conn = @"Data Source=PROFITA\PROFITA;Initial Catalog=vyingbraindb;Integrated Security=SSPI;Encrypt=false";
                return conn;
        }

        public static string repInj(string tx, string mthd = "GET")
        {
            if (tx == null)
                return "";
            tx = tx.Replace("select ", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("insert", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("delete", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("update", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("script", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("exec ", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("execute", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("alter ", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace(" union ", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("bit.ly", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("github", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace(">", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("<", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace("'", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace(" into ", "", StringComparison.OrdinalIgnoreCase);
            tx = tx.Replace(" not ", "", StringComparison.OrdinalIgnoreCase);
            if (mthd == "GET")
            {
                // tx = Microsoft.VisualBasic.Replace(tx, " and ", "",,, CompareMethod.Text)
                // tx = Microsoft.VisualBasic.Replace(tx, " or ", "",,, CompareMethod.Text)
                tx = tx.Replace("(", "", StringComparison.OrdinalIgnoreCase);
                tx = tx.Replace(")", "", StringComparison.OrdinalIgnoreCase);
            }
            return tx;


        }

        public string GetPostWP(string Url, CookieContainer CkCont, string authid = "", string PostData = "", int xTLS = 0)
        {
            string pStr = "";
            try
            {

                if (xTLS == 1)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpWebRequest Http = (HttpWebRequest)WebRequest.Create(Url);
                Http.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                Http.CookieContainer = CkCont;
                Http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36 OPR/46.0.2597.57";
                Http.Accept = "text/html,application/json,text/javascript,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                if (!string.IsNullOrEmpty(authid)) { Http.Headers.Add("Authid", authid); }

                if (PostData != "")
                {
                    Http.Method = "POST";
                    Http.ContentLength = PostData.Length;
                    Http.ContentType = "application/x-www-form-urlencoded";

                    StreamWriter PostStream = new StreamWriter(Http.GetRequestStream());
                    PostStream.Write(PostData);
                    PostStream.Close();
                }

                using (HttpWebResponse WebResponse = (HttpWebResponse)Http.GetResponse())
                {
                    Stream responseStream = WebResponse.GetResponseStream();

                    if ((WebResponse.ContentEncoding.ToLower().Contains("gzip")))
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    else if ((WebResponse.ContentEncoding.ToLower().Contains("deflate")))
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

                    StreamReader reader = new StreamReader(responseStream, Encoding.Default);
                    pStr = reader.ReadToEnd();

                    responseStream.Close();
                }
                return pStr;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        public string GetPostJSON(string url, CookieContainer ckCont, string postData = "", string refSite = "")
        {
            string pStr = "";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest http = (HttpWebRequest)WebRequest.Create(url);
                if (!string.IsNullOrEmpty(refSite))
                    http.Referer = refSite;

                http.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");

                http.CookieContainer = ckCont;
                http.KeepAlive = true;
                http.AllowAutoRedirect = true;

                // User agent and accept headers
                http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36 OPR/108.0.0.0";
                http.Accept = "application/json, text/javascript, */*; q=0.01";

                if (!string.IsNullOrEmpty(postData))
                {
                    postData = postData.Trim();
                    http.Method = "POST";
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    http.ContentLength = byteArray.Length;
                    http.ContentType = "application/json; charset=utf-8";

                    using (Stream postStream = http.GetRequestStream())
                    {
                        postStream.Write(byteArray, 0, byteArray.Length);
                    }
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)http.GetResponse())
                {
                    Stream responseStream = webResponse.GetResponseStream();

                    if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    }
                    else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                    }

                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    pStr = reader.ReadToEnd();

                    responseStream.Close();
                }

                return pStr;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        CultureInfo bn = new CultureInfo("hi-IN");
        public DataTable SqlToTbl(string strSqlRec, int dbNo = 1)
        {
            SqlDataAdapter Adp = new SqlDataAdapter(strSqlRec, getCon(dbNo));
            DataTable Tbl = new DataTable();
            try
            {
                Adp.Fill(Tbl);
            }
            catch (Exception ex) { }

            return Tbl;
        }

        public string FindOne(string Fld, string fTbl, string fWhere = "", int dbNo = 0)
        {
            using (SqlCommand comCm = new SqlCommand())
            {
                using (SqlConnection Cn = new SqlConnection(getCon(dbNo)))
                {
                    try
                    {
                        Cn.Open();
                        comCm.Connection = Cn;
                        comCm.CommandTimeout = 90;
                        comCm.CommandText = "select " + Fld + " from " + fTbl + " " + fWhere;
                        return comCm.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                }
            }
        }

        public void cmExecute(string SqlStr)
        {
            string rettx = "";
            using (SqlCommand comCm = new SqlCommand())
            {
                using (SqlConnection Cn = new SqlConnection(getCon()))
                {
                    try
                    {
                        Cn.Open();
                        comCm.Connection = Cn;
                        comCm.CommandTimeout = 90;
                        comCm.CommandText = SqlStr;
                        comCm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        rettx = "error:" + ex.Message;
                    }
                }
            }
            if (rettx != "")
                throw new Exception(rettx);
        }

        public long cmExecuteRet(string SqlStr)
        {
            using (SqlCommand comCm = new SqlCommand())
            {
                using (SqlConnection Cn = new SqlConnection(getCon()))
                {
                    try
                    {
                        Cn.Open();
                        comCm.Connection = Cn;
                        comCm.CommandTimeout = 90;
                        comCm.CommandText = SqlStr + "; Select Scope_Identity()";
                        return Convert.ToInt64(comCm.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
        }

        public string RetLine(string mStr, int sIndex = 0, string fStr = "", string lStr = "", string fndStr = "", bool inclFs = false, bool inclLs = false, bool RetAll = false)
        {
            int fs;
            int ls;

            try
            {
                if (fndStr != "")
                {
                    sIndex = mStr.IndexOf(fndStr, sIndex);
                    if (sIndex == -1)
                        throw new Exception();
                }

                if (fStr != "")
                {
                    fs = mStr.IndexOf(fStr, sIndex);
                    if (fs == -1)
                        throw new Exception();

                    if (inclFs == false)
                        fs = fs + fStr.Length;
                }
                else
                    fs = sIndex;

                if (lStr != "")
                {
                    ls = mStr.IndexOf(lStr, fs);
                    if (ls == -1)
                        throw new Exception();

                    if (inclLs == true)
                        ls = ls + lStr.Length;

                    return mStr.Substring(fs, ls - fs);
                }
                else
                    return mStr.Substring(fs);
            }
            catch (Exception ex)
            {
                if (RetAll == true)
                    return mStr;
                else
                    return "";
            }
        }

        public string TXEnc(string plainText)
        {
            try
            {
                byte[] key = { 170, 56, 39, 124, 31, 136, 211, 100, 180, 51, 111, 88, 216, 92, 214, 36, 164, 188, 71, 51, 36, 187, 195, 205, 87, 167, 81, 248, 173, 7, 194, 10 };
                byte[] iv = { 33, 162, 253, 195, 255, 140, 120, 198, 25, 99, 222, 142, 182, 152, 94, 28 };
                RijndaelManaged cipher = new RijndaelManaged();
                ICryptoTransform encryptor = cipher.CreateEncryptor(key, iv);
                byte[] data = Encoding.Unicode.GetBytes(plainText);
                return Convert.ToBase64String(encryptor.TransformFinalBlock(data, 0, data.Length));
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string TXDec(string encryptedText)
        {
            try
            {
                byte[] key = { 170, 56, 39, 124, 31, 136, 211, 100, 180, 51, 111, 88, 216, 92, 214, 36, 164, 188, 71, 51, 36, 187, 195, 205, 87, 167, 81, 248, 173, 7, 194, 10 };
                byte[] iv = { 33, 162, 253, 195, 255, 140, 120, 198, 25, 99, 222, 142, 182, 152, 94, 28 };
                RijndaelManaged cipher = new RijndaelManaged();
                ICryptoTransform decryptor = cipher.CreateDecryptor(key, iv);
                byte[] data = Convert.FromBase64String(encryptedText);
                return Encoding.Unicode.GetString(decryptor.TransformFinalBlock(data, 0, data.Length));
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string bnF(decimal Vl1, int pnt = 0)
        {
            if (Vl1 == 0) { return "0"; }
            if (pnt == 0)
            {
                return string.Format(bn, "{0:#,#}", Vl1);
            }
            else if (pnt == 2)
            {
                return string.Format(bn, "{0:#,#.##}", Vl1);
            }
            else
            {
                return string.Format(bn, "{0:#,#.#}", Vl1);
            }
        }

        //private static Random random = new Random();
        //public static string RandomString()
        //{
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    string rndS = new string(Enumerable.Repeat(chars, 5).Select(s => s[ random.Next(s.Length)]).ToArray());
        //    string unixTimestamp = rndS + Convert.ToString((long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);
        //    if (unixTimestamp.Length > 18) unixTimestamp = unixTimestamp.Substring(0, 18);
        //    return unixTimestamp;
        //}
       

        public static long TMSTMP()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

    }
}
