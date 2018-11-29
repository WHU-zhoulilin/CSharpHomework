using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace program1
{
    public class Program
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Program program = new Program();
            string startUrl = "https://www.baidu.com/";
            if (args.Length >= 1)
            {
                startUrl = args[0];
            }
            program.urls.Add(startUrl, false);
            new Thread(program.Crawl).Start();
        }

        private void Crawl()
        {
            
            Console.WriteLine("开始爬行了。。。");
            while (true)
            {
               

                
                string current = null;
                string current1 = null;
                string current2 = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    if (current == null)
                        current = url;
                    else if (current1 == null)
                        current1 = url;
                    else
                    {
                        current2 = url;
                        break;
                    }

                }
                
                if (current== null || count > 100) break;

                Console.WriteLine("爬行" + current + "页面！");

                Task<string> task = Task<string>.Run(() => DownLoad(current));
                Task<string> task1 = Task<string>.Run(() => DownLoad(current1));
                Task<string> task2 = Task<string>.Run(() => DownLoad(current2));
                string html = task.Result+task1.Result+task2.Result;
                try
                {
                    urls[current] = true;
                    urls[current1] = true;
                    urls[current2] = true;
                }
                catch
                {

                }
                 
                Parse(html);
     
            }
            Console.WriteLine("爬行结束");
        }
        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                count++;
                return html;
            }
            catch(Exception e)
            {
                Console.WriteLine("下载失败"+e.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
           
           
                
                string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', ',', '>');
                    if (strRef.Length == 0)
                    {
                        continue;
                    }
                    if (urls[strRef] == null)
                    {
                       urls[strRef]=false;
                    }
                }
            
        }
    }
}
