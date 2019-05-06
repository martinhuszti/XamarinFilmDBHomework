
using FilmDB.Models;
using SuaveControls.DynamicStackLayout;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        private int movieId;

        public MovieDetailsPage(int id)
        {
            InitializeComponent();
            Title = "Movie Details";
            movieId = id;

            ToolbarItems.Add(new ToolbarItem("Search", "home.png", () =>
            {
                Navigation.PopToRootAsync();
            }));

        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();


            var movie = await App.MovieManager.GetMovieDetails(movieId);
            if (movie != null)
            {


                var credits = await App.MovieManager.GetCredits(movieId);
                var size = credits.cast.Count;
                credits.cast.RemoveRange(10, size - 10);

                mainlayout.BindingContext = movie;
                if (credits.cast != null)
                    actorList.ItemsSource = credits.cast;
                if (movie.genres != null)
                    genreList.ItemsSource = movie.genres;

                var movierec = await App.MovieManager.MovieRecommendation(movieId);
                if (movierec != null)
                    movieList.ItemsSource = movierec;


                view.Opacity = 100;
            }
            else
            { await DisplayAlert("No Internet Connection or Movie Not Found", "Please check your internet connection", "OK"); }
            loading.IsRunning = false;

        }

        async void ActorTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;

            await Navigation.PushAsync(new ActorPage(id));
        }

        async void MovieTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;

            await Navigation.PushAsync(new MovieDetailsPage(id));
        }


    }
}