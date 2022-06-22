using Guard19.Helper;
using Guard19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guard19.Services
{
    public class CovidPhilippineService
    {
        static string BaseUrl = "https://corona.lmao.ninja/v2/countries";

        public static async Task<Country> GetCountry()
        {
            try
            {
                string url = BaseUrl + "/Philippines?yesterday=true&strict=true&query";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<Country>(content);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static async Task<Country> GetSpecificCountry(string country)
        {
            try
            {
                string url = BaseUrl + $"/{country}?yesterday=true&strict=true&query";
                var content = await WebMethods.MakeGetRequest(url);
                var result = JsonConvert.DeserializeObject<Country>(content);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
