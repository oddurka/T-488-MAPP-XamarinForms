using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMovieSearch.CustomUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListView : ListView
    {
        public MovieListView()
        {
            InitializeComponent();

            this.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }
    }
}