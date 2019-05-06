using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmDB.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActorPage : ContentPage
    {
        private int actorID;
        public ActorPage(int id)
        {
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("Search", "home.png", () =>
            {
                Navigation.PopToRootAsync();
            }));

            Title = "Actor Details";
            actorID = id;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var actorDetails = await App.MovieManager.GetActorDetails(actorID);
            if (actorDetails != null)
            {

                if (actorDetails != null)
                {
                    mainlayout.BindingContext = actorDetails;
                    if (actorDetails.gender == 1)
                        gender.Text = "Female";
                    if (actorDetails.gender == 2)
                        gender.Text = "Male";
                }
                else
                {
                    gender.Text = "Unknow actor";
                }


                var actorMovies = await App.MovieManager.GetActorMovies(actorID);

                if (actorMovies != null)
                {
                    var size = actorMovies.cast.Count;
                    actorMovies.cast.RemoveRange(10, size - 10);
                }

                if (actorMovies.cast != null)
                    filmlist.ItemsSource = actorMovies.cast;

                view.Opacity = 100;

            }
            else { await DisplayAlert("No Internet Connection", "Please check your internet connection", "OK"); }

            loading.IsRunning = false;

        }

        async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;

            await Navigation.PushAsync(new MovieDetailsPage(id));
        }

    }
}