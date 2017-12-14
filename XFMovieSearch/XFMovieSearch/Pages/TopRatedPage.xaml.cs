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
    public partial class TopRatedPage : ContentPage
    {
        private TopRatedViewModel _modelView;
        public TopRatedPage(FilmCollection Movies)
        {
            this._modelView = new TopRatedViewModel(this.Navigation, Movies._movies);
            this.BindingContext = this._modelView;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (this._modelView.Films.Count == 0)
                await this._modelView.LoadData();
        }
    }
}