using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ParsingHtml
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var content = await GetContent();
            var res = ParsingHtml(content);
            Console.WriteLine(res);
        }
        public static async Task<string> GetContent()
        {
            string url = "https://phtt.ru/news/2024/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string FinalStream = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return FinalStream;
        }
        public static string ParsingHtml(string htmlContent)
        {
            var html = new HtmlDocument();
            html.LoadHtml(htmlContent);
            var document = html.DocumentNode;
            string answer = "";
            var newsItems = document.Descendants("div").Where(n => n.HasClass("news"));
            foreach ( var item in newsItems )
            {
                var headers = item.Descendants("div").Where(n => n.HasClass("header"));
                var texts = item.Descendants("div").Where(n => n.HasClass("text"));
                foreach (var header in headers)
                {
                    foreach ( var text in texts)
                    {
                        var descriptionHeader = header.InnerHtml.Trim();
                        var description = text.InnerText.Trim();
                        answer += $"Событие: {descriptionHeader}\n{description}\n";
                        answer += new string('-', 40) + "\n";
                    }
                }
            }
            return answer;
        }
    } 
}
