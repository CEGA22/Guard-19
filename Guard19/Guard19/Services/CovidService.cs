using Guard19.Helper;
using Guard19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Guard19.Models.Countries;

namespace Guard19.Services
{
    public class CovidService
    {
        static string BaseUrl = "https://corona.lmao.ninja/v2/all?yesterday";
        static string Url = "https://corona.lmao.ninja/v2/countries?yesterday&sort";
        static string URL = "https://corona.lmao.ninja/v2/countries";

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

        public static async Task<IEnumerable<Countries>>GetAllCountries()
        {
            try
            {
                string url = Url;
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<IEnumerable<Countries>>(content);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
