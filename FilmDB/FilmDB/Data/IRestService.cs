using FilmDB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmDB.Data
{
   public interface IRestService
    {
        Task<List<Movie>> GetMostPopularMovies();
        Task<List<Movie>> SearchForMovie(string searched);
        Task<List<Series>> SearchForSeries(string searched);
        Task<List<Genre>> GetGenresAsync( string s);
        Task<MovieDetails> GetMovieDetailsAsync(int movieId);
        Task<Credits> GetCredits(int movieId);
        Task<Actor> GetActorDetails(int actorID);
        Task<List<Series>> GetMostPopularSeries();
        Task<SeriesDetail> GetSeriesDetailsAsync(int seriesId);
        Task<List<Episode>> GetEpisodeList(int seriesid, int season_number);
        Task<ActorCredits> GetActorMovies(int actorID);
        Task<List<Movie>> MovieRecommendation(int id);
    }
}
