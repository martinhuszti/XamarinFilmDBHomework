using DLToolkit.Forms.Controls;
using FilmDB.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FilmDB
{
    public partial class App : Application
    {
        public static MovieManager MovieManager { get; private set; }
        public App()
        {
            MovieManager = new MovieManager(new RestService());

            MainPage = initNavPage();
            FlowListView.Init();


        }

        NavigationPage initNavPage()
        {
            var navpage = new NavigationPage(new MainPage());
            navpage.BarTextColor = Color.FromHex(MyColors.LightGreenHex);
            navpage.BarBackgroundColor = Color.FromHex(MyColors.DarkGreenHex);

            return navpage;
            
        }


        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {

        }

        public static async void goToHomeScreen()
        {
            int numModals = Application.Current.MainPage.Navigation.ModalStack.Count;
            for (int currModal = 0; currModal < numModals; currModal++)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }

    }
}
