using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XFMovieSearch.Model
{
    public class FilmModel : INotifyPropertyChanged
    {
        private string _releaseYear;
        private string _runTime;
        private string _genre;
        private string _actors;
        private string _description;
        private string _tagLine;
        private string _backDropPath;

        public string ReleaseYear
        {
            get => _releaseYear;
            set
            {
                if (_releaseYear != value)
                {
                    _releaseYear = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Runtime
        {
            get => _runTime;
            set
            {
                if (_runTime != value)
                {
                    _runTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Genre
        {
            get => _genre;
            set
            {
                if (_genre != value)
                {
                    _genre = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Actors
        {
            get => _actors;
            set
            {
                if (_actors != value)
                {
                    _actors = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TagLine
        {
            get => _tagLine;
            set
            {
                if (_tagLine != value)
                {
                    _tagLine = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BackDropPath
        {
            get => _backDropPath;
            set
            {
                if (_backDropPath != value)
                {
                    _backDropPath = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
