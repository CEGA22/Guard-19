using Guard19.Models;
using Guard19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Guard19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();           
        }

        private void SelectedCountry(object sender, EventArgs e)
        {
            countries.Focus();
        }

        private async void countries_SelectedIndexChanged(object sender, EventArgs e)
        {           
            var selectedItem = countries.Items[countries.SelectedIndex];

            if (BindingContext is HomeViewModel hvm)
            {
                await hvm.DisplaySpecificCountry(selectedItem.ToString());                
            }
        }
    }
}