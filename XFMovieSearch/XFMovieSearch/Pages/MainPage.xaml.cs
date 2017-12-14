using DM.MovieApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFMovieSearch.Model;

namespace XFMovieSearch.Pages
{
    public partial class MainPage : ContentPage
    {
        private FilmCollection _filmCollection;

        public MainPage(FilmCollection movies)
        {
            InitializeComponent();
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            this.ActivityIndicator.IsRunning = true;
            this._filmCollection._movies = FilmAPISearches.FindMovieTitles(await FilmAPISearches.movieApi.SearchByTitleAsync(this.SearchBar.Text));
            await this.Navigation.PushAsync(new MovieListPage(this._filmCollection));
            this.ActivityIndicator.IsRunning = false;
        }
    }
}
