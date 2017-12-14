using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XFMovieSearch.Model;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch.Pages
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var searchPage = new MovieListPage(new FilmCollection());
            var searchPageNavigator = new NavigationPage(searchPage);
            searchPageNavigator.Title = "Search";

            var topRatedPage = new TopRatedPage(new FilmCollection());
            var topReatedNavigator = new NavigationPage(topRatedPage);
            topReatedNavigator.Title = "Top Rated";

            var popularPage = new PopularPage(new FilmCollection());
            var popularNavigator = new NavigationPage(popularPage);
            popularNavigator.Title = "Popular";

            var tabbedPage = new TabBarPage();
            tabbedPage.Children.Add(searchPageNavigator);
            tabbedPage.Children.Add(popularNavigator);
            tabbedPage.Children.Add(topReatedNavigator);
            
            MainPage = tabbedPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
