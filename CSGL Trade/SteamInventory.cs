using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSGL_Trade
{
    class SteamInventory
    {
        private SteamMarketHistory _steamMarketHistory = new SteamMarketHistory();

        Threading _threading = new Threading();

        public string GetInventoryJson()
        {
            var webClient = new System.Net.WebClient();
            var profileID = CSGL_Trade.Properties.Settings.Default.SteamProfileID;

            return webClient.DownloadString(
                String.Format(@"http://steamcommunity.com/profiles/{0}/inventory/json/730/2",
                profileID));
        }

        public List<string> ParseSteamInventoryJson(string json)
        {
            var jObj = JObject.Parse(json);

            var itemNames = new List<string>();

            foreach (var item in jObj["rgDescriptions"])
            {
                var names = (string)item.First()["market_name"];
                //Remove unncessary markings, like TM, and a STAR.
                //Remove leading and trailing spaces by use of .Trim()
                /* names = names.Replace(@"\u2122", string.Empty);//TM
                names = names.Replace(@"™", string.Empty);
                names = names.Replace(@"\u2605", string.Empty);//STAR
                */
                names = names.Trim();
                itemNames.Add(names);
            }
            return itemNames;
        }

        public string GetPriceOfItemSTEAM(string itemName)
        {
            try
            {
                itemName = System.Web.HttpUtility.UrlEncode(itemName);
                var url =
                        string.Format(@"http://steamcommunity.com/market/search/render/?query={0}&start=0&count=10",
                        itemName);

                //Console.WriteLine("Request URL: {0}",url);
                var webClient = new System.Net.WebClient();

                var json = webClient.DownloadString(url);
                //JObject jObj = JObject.Parse(json);

                var match = Regex.Match(json, @"[$]\d[.]\d{2}");

                if (match.Success)
                {
                    var lowestPrice = match.Value;
                    return lowestPrice;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public SteamMarketHistory GetMarketHistory(string itemName)
        {
            itemName = System.Web.HttpUtility.UrlEncode(itemName);

            var webClient = new System.Net.WebClient();

            string url = string.Format("https://open-market.io/api/prices/?item={0}&appID=730", itemName);
            //Console.WriteLine("Requesting URL: {0}", url);

            string json = webClient.DownloadString(url);

            return JsonConvert.DeserializeObject<SteamMarketHistory>(json);

        }
    }
}
