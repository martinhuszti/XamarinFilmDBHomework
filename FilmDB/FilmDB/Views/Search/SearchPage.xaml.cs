

using FilmDB.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FilmDB.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {

        private string searched_for;
        public SearchPage()
        {
            InitializeComponent();

            Title = "Search";

            ToolbarItems.Add(new ToolbarItem("Search", "home.png", () =>
            {
                Navigation.PopToRootAsync();
            }));

        }
        

        private async void search(string searchedText)
        {
            searched_for = picker.SelectedItem.ToString();

            searched.ItemsSource = null; //to update
            loading.IsRunning = true;


            
            if (searched_for.Equals("Movie"))
                searched.ItemsSource = await App.MovieManager.SearchForMovie(searchedText.ToLower());
            else { searched.ItemsSource = await App.MovieManager.SearchForSeries(searchedText.ToLower()); }

            if(searched.ItemsSource == null)
            { await DisplayAlert("No Internet Connection or "+searched_for+ " not found", "Please check your internet connection, or try to search something else", "OK"); }
            
            loading.IsRunning = false;


        }

     
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            search(searchBar.Text.ToString());
        }

        public async void ItemTapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var id = (int)args.Parameter;

            if (searched_for.Equals("Movie"))
            {
                await Navigation.PushAsync(new MovieDetailsPage(id));
            }
            else
            {
                await Navigation.PushAsync(new SeriesDetailPage(id));
            }

        }

    }

}