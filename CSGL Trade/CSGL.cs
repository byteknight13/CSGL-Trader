using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGL_Trade
{
    class CSGL
    {
        Threading Threading = new Threading();



        public Dictionary<string, string> GetItemSchema()
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            string json = webClient.DownloadString(@"http://www.csgolounge.com/api/schema.php");
            /*using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\itemschema.txt"))
            {
                json = sr.ReadToEnd();
            }   */
            //Remove unncessary markings, like TM, and a STAR.
            /*json = json.Replace(@"\u2122", string.Empty);//TM
            json = json.Replace(@"\u2605", string.Empty);//STAR*/
            JObject jObj = JObject.Parse(json);

            Dictionary<string, string> Items = new Dictionary<string, string>();

            for (int i = 1; i < jObj.Count - 1; i++)
            {
                try
                {
                    var itemName = jObj[i.ToString()]["name"];

                    //This stops us from displaying useless, untrabable items.

                    if (itemName.Contains("|")) { break; }

                    var itemWorth = jObj[i.ToString()]["worth"];
                    //Console.WriteLine("Name: {0} - Worth: {1}", itemName, itemWorth);
                    Items.Add(itemName.ToString().Trim(), itemWorth.ToString().Trim());
                }
                catch (Exception ex)
                {
                    //Just supressing the errors here. They happen, and its ok.
                }

            }
            return Items;

        }

    }
}
