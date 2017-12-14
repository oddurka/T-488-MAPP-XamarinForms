using DM.MovieApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.Model;

namespace XFMovieSearch.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieListPage : ContentPage
	{
        private MovieListViewModel _movieListViewModel;

        public MovieListPage (FilmCollection Movie)
		{
            MovieDbFactory.RegisterSettings(Movie);
            this._movieListViewModel = new MovieListViewModel(this.Navigation, Movie._movies);
            this.BindingContext = this._movieListViewModel;
            InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
        }
	}
}