using FilmDB.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FilmDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Title = "FilmDB";
                        
            
        }

        async void GetPopularMovies(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MostPopularMovies());
        }

        async void GetPopularSeries(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MostPopularSeries());
        }

        async void onSearchPressed(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}
