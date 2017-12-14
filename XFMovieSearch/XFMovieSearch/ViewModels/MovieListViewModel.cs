using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFMovieSearch.Model;
using XFMovieSearch.Pages;

namespace XFMovieSearch
{
    class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private List<Film> _movieList;
        private string _searchString;
        
        private Film _selectedMovie;

        public MovieListViewModel(INavigation navigation, List<Film> movieList)
        {
            this._navigation = navigation;
            this._movieList = movieList;
        }

        public List<Film> Films
        {
            get => this._movieList;
            set
            {
                this._movieList = value;
                OnPropertyChanged();
            }
        }

        public Film SelectedMovie
        {
            get => this._selectedMovie;
            set
            {
                if(value != null)
                {
                    this._selectedMovie = value;
                    this._navigation.PushAsync(new MovieDetailPage(this._selectedMovie), true);
                }
            }
        }

        public string SearchString { get => this._searchString; set => _searchString = value; }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (this._searchString != "")
                    {
                        this.Films = FilmAPISearches.FindMovieTitles(await FilmAPISearches.movieApi.SearchByTitleAsync(this._searchString));
                        LoadActorssAsync();
                    }
                });
            }
        }

        public async Task LoadActorssAsync()
        {
            foreach (var movie in this._movieList)
            {
                await FilmAPISearches.FindMovieActorsAsync(FilmAPISearches.movieApi, movie);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}