using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFMovieSearch.Model;

namespace XFMovieSearch.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarPage : TabbedPage
    {
        private TopRatedPage _topRatedPage;
        private PopularPage _popularPage;

        public TabBarPage()
        {
            var searchPage = new MovieListPage(new FilmCollection());
            var searchPageNavigator = new NavigationPage(searchPage);
            searchPageNavigator.Title = "Search";

            _topRatedPage = new TopRatedPage(new FilmCollection());
            var topReatedNavigator = new NavigationPage(_topRatedPage);
            topReatedNavigator.Title = "Top Rated";

            _popularPage = new PopularPage(new FilmCollection());
            var popularNavigator = new NavigationPage(_popularPage);
            popularNavigator.Title = "Popular";

            Children.Add(searchPageNavigator);
            Children.Add(popularNavigator);
            Children.Add(topReatedNavigator);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._popularPage.loadData();
            await Task.Delay(1000);
            this._topRatedPage.loadData();
            
        }
    }
}