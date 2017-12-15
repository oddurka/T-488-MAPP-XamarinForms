using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFMovieSearch.Model;

namespace XFMovieSearch.ViewModels
{
    class MovieDetailsViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private Film _movie;

        public MovieDetailsViewModel(INavigation navigation, Film movie)
        {
            this._navigation = navigation;
            this._movie = movie;
        }

        public Film Film
        {
            get => this._movie;
            set
            {
                if(this._movie != value)
                {
                    this._movie = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task LoadDetailsAsync()
        {
            await FilmAPISearches.FindMovieDetailsAsync(FilmAPISearches.movieApi, _movie);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
