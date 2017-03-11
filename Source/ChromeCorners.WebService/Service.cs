using ChromeCorners.Core;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChromeCorners.WebService
{
    public class Service : IWebService
    {
        public string FindFaviconUrlFromWebsite(string websiteUrl)
        {
            var client = new HttpClient();

            try
            {
                var response = client.GetAsync(websiteUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    // by calling .Result you are performing a synchronous call
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    
                    return FindFaviconUrl(responseString, new Uri(websiteUrl)); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);    
            }
            finally
            {
                client.Dispose();
            }

            return null;
        }
        



        private string FindFaviconUrl(string html, Uri hostUrl)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            var favNode         = doc.DocumentNode.SelectSingleNode("//link[contains(@rel, 'icon')] | //link[contains(@rel, 'shortcut')]");
            var faviconUrl      = favNode.GetAttributeValue("href", string.Empty);

            if (faviconUrl != string.Empty)
            {
                if (!faviconUrl.StartsWith("http") && !faviconUrl.StartsWith("https"))
                {
                    var host = !hostUrl.Host.EndsWith("/") ? $"{hostUrl.Host}/" : "";
                    faviconUrl = $"{hostUrl.Scheme}://{hostUrl.Host}{faviconUrl}";
                }
            }

            return faviconUrl;
        }
    }
}