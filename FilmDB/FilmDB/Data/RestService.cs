using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using FilmDB.Models;
using Newtonsoft.Json;

namespace FilmDB.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        
        public RestService()
        {

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<Actor> GetActorDetails(int actorID)
        {
            var actor = new Actor();

            var uri = new Uri(Constants.RestUrl + "/person/" + actorID + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    actor = JsonConvert.DeserializeObject<Actor>(content);
                    return actor;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<ActorCredits> GetActorMovies(int actorID)
        {
            var credits = new ActorCredits();

            var uri = new Uri(Constants.RestUrl + "/person/" + actorID + "/movie_credits" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    credits = JsonConvert.DeserializeObject<ActorCredits>(content);
                    return credits;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<Credits> GetCredits(int movieId)
        {
            var credits = new Credits();

            var uri = new Uri(Constants.RestUrl + "/movie/" + movieId + "/credits" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    credits = JsonConvert.DeserializeObject<Credits>(content);
                    return credits;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Episode>> GetEpisodeList(int seriesid, int season_number)
        {

            var uri = new Uri(Constants.RestUrl + "/tv/" + seriesid + "/season/"+ season_number + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EpisodeListResponse>(content).episodes;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Genre>> GetGenresAsync(string what)
        {

            var uri = new Uri(Constants.RestUrl + "/genre/" + what + "/list" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ServerResponseGenre>(content).genres;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Movie>> GetMostPopularMovies()
        {

            var uri = new Uri(Constants.RestUrl + "/movie/popular" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ServerResponseListMovie>(content).results;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Series>> GetMostPopularSeries()
        {
            var ListOfSeries = new ServerResponseListSeries();

            var uri = new Uri(Constants.RestUrl + "/tv/popular" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ServerResponseListSeries>(content).results;


                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            var movie = new MovieDetails();

            var uri = new Uri(Constants.RestUrl + "/movie/" + movieId + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    movie = JsonConvert.DeserializeObject<MovieDetails>(content);
                    return movie;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<SeriesDetail> GetSeriesDetailsAsync(int seriesId)
        {
            var seriesDetails = new SeriesDetail();

            var uri = new Uri(Constants.RestUrl + "/tv/" + seriesId + Constants.ApiKey);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    seriesDetails = JsonConvert.DeserializeObject<SeriesDetail>(content);
                    return seriesDetails;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Movie>> MovieRecommendation(int id)
        {
            var LisfOfMovies = new ServerResponseListMovie();

            var uri = new Uri(Constants.RestUrl + "/movie/"+ id +"/recommendations" + Constants.ApiKey);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LisfOfMovies = JsonConvert.DeserializeObject<ServerResponseListMovie>(content);
                    return LisfOfMovies.results;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<List<Movie>> SearchForMovie(string searched)
        {
            var LisfOfMovies = new ServerResponseListMovie();

            var uri = new Uri(Constants.RestUrl + "/search/movie" + Constants.ApiKey + "&query=" + searched);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LisfOfMovies = JsonConvert.DeserializeObject<ServerResponseListMovie>(content);
                    return LisfOfMovies.results;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }



        public async Task<List<Series>> SearchForSeries(string searched)
        {
            var LisfOfSeries = new ServerResponseListSeries();

            var uri = new Uri(Constants.RestUrl + "/search/tv" + Constants.ApiKey + "&query=" + searched);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    LisfOfSeries = JsonConvert.DeserializeObject<ServerResponseListSeries>(content);
                    return LisfOfSeries.results;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }


    }
}
