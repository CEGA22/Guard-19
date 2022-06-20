using Guard19.Helper;
using Guard19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guard19.Services
{
    public class CovidService
    {
        static string BaseUrl = "https://corona.lmao.ninja/v2/all?yesterday";

        public static async Task<World> GetAll()
        {
            try
            {
                string url = BaseUrl;
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<World>(content);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
