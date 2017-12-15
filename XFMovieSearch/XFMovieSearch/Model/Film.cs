using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace XFMovieSearch.Model
{
    public class Film : FilmModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string ReleaseYear { get => base.ReleaseYear; set => base.ReleaseYear = value; }
        public string Runtime { get => base.Runtime; set => base.Runtime = value; }
        public string Genre { get => base.Genre; set => base.Genre = value; }
        public string Actors { get => base.Actors; set => base.Actors = value; }
        public string Description { get => base.Description; set => base.Description = value; }
        public string PosterPath { get; set; }
        public string TagLine { get => base.TagLine; set => base.TagLine = value; }
        public string BackDropPath { get => base.BackDropPath; set => base.BackDropPath = value; }
        public ImageSource MovieBackDrop => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w780" + BackDropPath));
        public ImageSource MoviePoster => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + PosterPath));
    }
}
