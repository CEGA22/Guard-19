using Guard19.Models;
using Guard19.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guard19.Models.Countries;

namespace Guard19.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        public ObservableRangeCollection<Country> countryInfoList { get; }
        public ObservableRangeCollection<Countries> Countriess { get; }
    

        private float todayCases;
        public float TodayCases
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
            Countriess = new ObservableRangeCollection<Countries>();            
            PreparePageBindings();
        }

        public async void PreparePageBindings()
        {
            await DisplayCountryInfo();
            await DisplayListOfCountries();          
        }

        public async Task DisplayCountryInfo()
        {
            var country = await CovidPhilippineService.GetCountry();           
            countryInfoList.Add(country);
            CountryName = country.CountryName;
            Flag = country.CountryInfo.Flag;
            TodayCases = country.TodayCases;            
        }    

        public async Task DisplayListOfCountries()
        {          
            var countries = await CovidService.GetAllCountries();
            Countriess.AddRange(countries);
        }

        public async Task DisplaySpecificCountry(string selectedCountry)
        {
            countryInfoList.Clear();
            var country = await CovidPhilippineService.GetSpecificCountry(selectedCountry);           
            countryInfoList.Add(country);
            CountryName = country.CountryName;
            Flag = country.CountryInfo.Flag;
            TodayCases = country.TodayCases;
        }
    }
}
