using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace mob
{
    public class wikpedia
    {
        static void Form1(string[] args)
        {
            string url = "https://pt.wikipedia.org/wiki/C_Sharp";
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            string html = wc.DownloadString(url);

           
        }
    }
}
