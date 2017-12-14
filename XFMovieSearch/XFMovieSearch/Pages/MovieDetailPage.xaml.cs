using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.Model;
using XFMovieSearch.ViewModels;

namespace XFMovieSearch.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailPage : ContentPage
	{
        private MovieDetailsViewModel _viewModel;
		public MovieDetailPage (Film movie)
		{
            this._viewModel = new MovieDetailsViewModel(this.Navigation, movie);
            this.BindingContext = this._viewModel.Film;
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this._viewModel.LoadDetailsAsync();
        }
    }
}