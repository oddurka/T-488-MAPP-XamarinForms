using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFMovieSearch.Model;

namespace XFMovieSearch.ViewModels
{
    class PopularMoviesViewModel : MovieListViewModel
    {
        private bool _isRefreshing = false;

        public PopularMoviesViewModel(INavigation navigation, List<Film> movieList) : base(navigation, movieList)
        {
        }

        public bool IsRefreshing
        {
            get => this._isRefreshing;
            set
            {
                this._isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    await LoadData();
                    IsRefreshing = false;
                });
            }
        }

        public async Task LoadData()
        {
            this.Films = FilmAPISearches.FindMovieTitles(await FilmAPISearches.movieApi.GetPopularAsync());
            this.LoadActorssAsync();
        }
    }
}
