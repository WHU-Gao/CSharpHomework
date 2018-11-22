using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();    //Hashtable 通过节点关键码确定节点位置，Valude, Key
        static int count = 0;
        static void Main(string[] args)
        {
            Crawler crawler = new Crawler();        
            string startUrl = "http://www.cnblogs.com/dstang2000";
          
            if (args.Length >= 1)
            {
                startUrl = args[0];
            }

            crawler.urls.Add(startUrl, false); //加入初始页面  key value
            new Thread(crawler.Crawl).Start(); //开始爬行
            
        }

        private void Crawl()
        {
            Console.WriteLine("......开始爬行了......");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url])
                    {
                        continue;
                    }
                    current = url;
                }
                if (current == null || count > 10)
                {
                    break;
                }
                Console.WriteLine("爬行" + current + "页面！");
                string html = DownLoad(current);    //下载

                urls[current] = true;   //键的值设为true，代表访问过了
                count++;
                Parse(html);
            }
        }

                public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient
                {
                    Encoding = Encoding.UTF8
                };
                string html = webClient.DownloadString(url);  //下载网络，返回文本

                string fileName = count.ToString() + ".html";   //后缀名
                File.WriteAllText(fileName, html, Encoding.UTF8);

                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);  
            // MatchCollection: 表示通过以迭代方式将正则表达式模式应用于输入字符串所找到的成功匹配的集合
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                //Trim是string 中的函数，是删去一些内容 ，函数参数是一个char类型的数组
                if (strRef.Length == 0)
                {
                    continue;
                }
                if (urls[strRef] == null)
                {
                  urls[strRef] = false;
                }
            }
        }
    }
}
