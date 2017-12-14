using DM.MovieApi;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.Model;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopularPage : ContentPage
    {
        private PopularMoviesViewModel _modelView;
        public PopularPage(FilmCollection Movies)
        {
            MovieDbFactory.RegisterSettings(Movies);
            this._modelView = new PopularMoviesViewModel(this.Navigation, Movies._movies);
            this.BindingContext = this._modelView;
            InitializeComponent();
        }

        public async Task loadData()
        {
            await this._modelView.LoadData();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (this._modelView.Films.Count == 0)
                await loadData();
        }
    }
}