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

            var tabbedPage = new TabBarPage();
            
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
