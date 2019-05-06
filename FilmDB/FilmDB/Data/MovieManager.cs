using FilmDB.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Collections;

namespace FilmDB.Data
{
    public class MovieManager
    {
        IRestService restService;

        public MovieManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Movie>> GetPopularMoviesAsync()
        {
            return restService.GetMostPopularMovies();
        }

        public Task<List<Movie>> SearchForMovie(string searched)
        {
            return restService.SearchForMovie(searched);
        }

        public Task<List<Series>> GetPopularSeriesAsync()
        {
            return restService.GetMostPopularSeries();
        }

        public Task<SeriesDetail> GetSeriesDetails(int seriesId)
        {
            return restService.GetSeriesDetailsAsync(seriesId);
        }

        public Task<Actor> GetActorDetails(int actorID)
        {
            return restService.GetActorDetails(actorID);
        }

        public Task<List<Movie>> MovieRecommendation(int movieId)
        {
            return restService.MovieRecommendation(movieId);
        }

        public Task<Credits> GetCredits(int movieId)
        {
            return restService.GetCredits(movieId);
        }

        internal Task<ActorCredits> GetActorMovies(int actorID)
        {
            return restService.GetActorMovies(actorID);

        }

        public Task<List<Series>> SearchForSeries(string searched)
        {
            return restService.SearchForSeries(searched);
        }

        public Task<List<Episode>> GetEpisodeList(int seriesid, int season_number)
        {
            return restService.GetEpisodeList(seriesid, season_number);
        }

        public Task<MovieDetails> GetMovieDetails(int movieId)
        {
            return restService.GetMovieDetailsAsync(movieId);
        }

        public Task<List<Genre>> GetGenresAsync(string s)
        {
            return restService.GetGenresAsync(s);
        }
    }


}
