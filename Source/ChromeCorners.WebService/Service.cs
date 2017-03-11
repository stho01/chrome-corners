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
        private const string IconXpathSelector = "//link[contains(@rel, 'icon')] | //link[contains(@rel, 'shortcut')]";

        /// <summary>
        ///
        /// </summary>
        /// <param name="websiteUrl"></param>
        /// <returns></returns>
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
                    var  responseString = responseContent.ReadAsStringAsync().Result;
                    
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="html"></param>
        /// <param name="hostUrl"></param>
        /// <returns></returns>
        private static string FindFaviconUrl(string html, Uri hostUrl)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            var favNode         = doc.DocumentNode.SelectSingleNode(IconXpathSelector);
            var faviconUrl      = favNode.GetAttributeValue("href", string.Empty);

            if (faviconUrl == string.Empty || faviconUrl.StartsWith("http") || faviconUrl.StartsWith("https"))
                return faviconUrl;

            var host = !hostUrl.Host.EndsWith("/") ? $"{hostUrl.Host}/" : "";
            faviconUrl = $"{hostUrl.Scheme}://{hostUrl.Host}{faviconUrl}";
            return faviconUrl;
        }
    }
}