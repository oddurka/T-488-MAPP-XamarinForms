using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarPage : TabbedPage
    {

        public TabBarPage()
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
        }
    }
}