using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public static class LoadWebPage
    {
        public static int LoadUrl(string url)
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                var content = httpClient.GetStringAsync(url).Result;
                return content.Length;

            }
            catch (Exception exception)
            {
                // todo log
                File.AppendAllText("errors.txt", $"{DateTime.Now} {exception.Message}{Environment.NewLine}");
                return -1;
            }        
        }
    }
}
