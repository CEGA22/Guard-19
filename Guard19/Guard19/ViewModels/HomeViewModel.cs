using Guard19.Models;
using Guard19.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guard19.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        public ObservableRangeCollection<Country> countryInfoList { get; }
        
        private int todayCases;
        public int TodayCases
        {
            get { return todayCases; }
            set { todayCases = value; OnPropertyChanged();}
        }


        private string flag;
        public string Flag
        {
            get { return flag; }
            set { flag = value; OnPropertyChanged();}
        }

        private string countryName;

        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; OnPropertyChanged();}
        }

        public HomeViewModel()
        {
            countryInfoList = new ObservableRangeCollection<Country>();
            PreparePageBindings();
        }

        public async void PreparePageBindings()
        {
            await DisplayCountryInfo();
        }

        public async Task DisplayCountryInfo()
        {
            var country = await CovidPhilippineService.GetCountry();           
            countryInfoList.Add(country);
            CountryName = country.CountryName;
            Flag = country.CountryInfo.Flag;
            TodayCases = country.TodayCases;
        }
    }
}
