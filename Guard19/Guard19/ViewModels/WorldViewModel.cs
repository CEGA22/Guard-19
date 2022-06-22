using Guard19.Helper;
using Guard19.Models;
using Guard19.Services;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Guard19.ViewModels
{
    public class WorldViewModel: BaseViewModel
    {
        public ObservableRangeCollection<World> AllCountries { get; set; }
        public ObservableRangeCollection<Country> Countries { get; set; } 

        private int todayCases;
        public int TodayCases
        {
            get { return todayCases; }
            set { todayCases = value; OnPropertyChanged(); }
        }
        public WorldViewModel()
        {
            AllCountries = new ObservableRangeCollection<World>();
            PreparePageBindings();
        }


        public async void PreparePageBindings()
        {
            await DisplayAll();          
        }

        public async Task DisplayAll()
        {
            var all = await CovidService.GetAll();
            AllCountries.Add(all);
            TodayCases = all.TodayCases;
        }        
    }
}
