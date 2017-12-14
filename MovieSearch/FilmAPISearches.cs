using System;
using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System.Threading.Tasks;

namespace MovieSearch
{
    public static class FilmAPISearches
    {
        public static IApiMovieRequest movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

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
                    ReleaseYear = infoResponse.Item.ReleaseDate.Year,
                    Runtime = infoResponse.Item.Runtime.ToString(),
                    Genre = "",
                    Actors = "",
                    Description = infoResponse.Item.Overview,
                    PosterPath = infoResponse.Item.PosterPath
                };

                if (infoResponse.Item.Genres.Count != 0)
                {
                    for (int i = 0; i < infoResponse.Item.Genres.Count; i++)
                    {
                        genres.Add(infoResponse.Item.Genres[i].Name);
                    }
                }

                movie.Genre = String.Join(", ", genres);

                if (castResponse.Item.CastMembers.Count != 0)
                {
                    for (int i = 0; i < castResponse.Item.CastMembers.Count && i < 3; i++)
                    {
                        actors.Add(castResponse.Item.CastMembers[i].Name);
                    }
                }
                movie.Actors = String.Join(", ", actors);
                movies.Add(movie);
            }
            return movies;
        }
    }
}
