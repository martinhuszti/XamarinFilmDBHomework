
using FilmDB.Models;
using FilmDB.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostPopularMovies : ContentPage
    {


        public MostPopularMovies()
        {
            InitializeComponent();

            Title = "Most Popular Movies";
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var MostPopularMovies = await App.MovieManager.GetPopularMoviesAsync();
            if (MostPopularMovies != null)
            {
                listView.ItemsSource = MostPopularMovies;
            }
            else
            { await DisplayAlert("No Internet Connection", "Please check your internet connection", "OK"); }
            loading.IsRunning = false;

        }

        public async void ItemTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;
            await Navigation.PushAsync(new MovieDetailsPage(id));

        }

    }
}