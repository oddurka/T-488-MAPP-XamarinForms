using System;
using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System.Threading.Tasks;

namespace XFMovieSearch.Model
{
    public static class FilmAPISearches
    {
        public static IApiMovieRequest movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

        public static List<Film> FindMovieTitles(ApiSearchResponse<MovieInfo> apiResponse)
        {
            List<Film> movies = new List<Film>();

            if (apiResponse.Results == null)
            {
                return movies;
            }

            foreach (MovieInfo info in apiResponse.Results)
            {
                Film movie = new Film()
                {
                    Title = info.Title,
                    Id = info.Id,
                    PosterPath = info.PosterPath
                };
                movies.Add(movie);
            }
            return movies;
        }

        public static async Task FindMovieActorsAsync(IApiMovieRequest movieApi, Film movie)
        {
            if(movie == null)
            {
                return;
            }

            List<string> actors = new List<string>();
            ApiQueryResponse<MovieCredit> castResponse = await movieApi.GetCreditsAsync(movie.Id);

            if (castResponse.Item.CastMembers.Count != 0)
            {
                for (int i = 0; i < castResponse.Item.CastMembers.Count && i < 3; i++)
                {
                    if(castResponse.Item.CastMembers[i].Name != "")
                        actors.Add(castResponse.Item.CastMembers[i].Name);
                }
                movie.Actors = String.Join(", ", actors);
                actors.Clear();
            }
        }

        public static async Task FindMovieDetailsAsync(IApiMovieRequest movieApi, Film movie)
        {
            if (movie == null)
            {
                return;
            }

            List<string> genres = new List<string>();
            ApiQueryResponse<Movie> infoResponse = await movieApi.FindByIdAsync(movie.Id);

            movie.ReleaseYear = infoResponse.Item.ReleaseDate.Year.ToString();
            movie.Runtime = infoResponse.Item.Runtime.ToString();
            movie.Description = infoResponse.Item.Overview;
            movie.TagLine = infoResponse.Item.Tagline;
            movie.BackDropPath = infoResponse.Item.BackdropPath;

            if (infoResponse.Item.Genres.Count != 0)
            {
                for (int i = 0; i < infoResponse.Item.Genres.Count; i++)
                {
                    genres.Add(infoResponse.Item.Genres[i].Name);
                }
                movie.Genre = String.Join(", ", genres);
                genres.Clear();
            }
        }

        public static async Task<List<Film>> PopulateMovieListAsync(IApiMovieRequest movieApi, ApiSearchResponse<MovieInfo> apiResponse)
        {
            List<Film> movies = new List<Film>();
            List<string> actors = new List<string>();
            List<string> genres = new List<string>();

            if(apiResponse == null)
            {
                return movies;
            }

            foreach (MovieInfo info in apiResponse.Results)
            {
                ApiQueryResponse<MovieCredit> castResponse = await movieApi.GetCreditsAsync(info.Id);
                ApiQueryResponse<Movie> infoResponse = await movieApi.FindByIdAsync(info.Id);

                Film movie = new Film()
                {
                    Title = info.Title,
                    ReleaseYear = infoResponse.Item.ReleaseDate.Year.ToString(),
                    Runtime = infoResponse.Item.Runtime.ToString(),
                    Genre = "",
                    Actors = "",
                    Description = infoResponse.Item.Overview,
                    PosterPath = infoResponse.Item.PosterPath,
                };

                if (infoResponse.Item.Genres.Count != 0)
                {
                    for (int i = 0; i < infoResponse.Item.Genres.Count; i++)
                    {
                        genres.Add(infoResponse.Item.Genres[i].Name);
                    }
                    movie.Genre = String.Join(", ", genres);
                    genres.Clear();
                }

                if (castResponse.Item.CastMembers.Count != 0)
                {
                    for (int i = 0; i < castResponse.Item.CastMembers.Count && i < 3; i++)
                    {
                        actors.Add(castResponse.Item.CastMembers[i].Name);
                    }
                    movie.Actors = String.Join(", ", actors);
                    actors.Clear();
                }
                movies.Add(movie);
            }
            return movies;
        }
    }
}
