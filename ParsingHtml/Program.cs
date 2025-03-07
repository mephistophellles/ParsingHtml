using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParsingHtml
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public static async Task<string> GetContent()
        {
            string url = "https://phtt.ru/news/2024/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string FinalStream = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return FinalStream;
        }
        
    } 
}
