﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RestSharp;
using SilverScreen.Models;
using SilverScreen.Models.Tables;

namespace SilverScreen.Services
{
    public class IMDbAPIService
    {
        private IConfiguration configuration;

        public IMDbAPIService(IConfiguration config)
        {
            configuration = config;
        }

        public void LoadMovieIntoDB(string title)
        {
            SilverScreenContext context = new SilverScreenContext(configuration); 

            string url = "https://imdb-api.com/API/AdvancedSearch/k_faxyw40f";
            var client = new RestClient(url);
            var request = new RestRequest();
            request.AddParameter("title", title);
            request.AddParameter("count", "1");
            var response = client.Get(request);
            var extractedFilm = JsonSerializer.Deserialize<IMDBQuery>(response.Content);

            string imdbId = extractedFilm.results[0].id;
            string urlTrailer = $"https://imdb-api.com/en/API/Trailer/k_faxyw40f/" + imdbId;
            var clientTrailer = new RestClient(urlTrailer);
            var requestTrailer = new RestRequest();
            var responseTrailer = clientTrailer.Get(requestTrailer);
            var extractedTrailer = JsonSerializer.Deserialize<IMDBTrailerLink>(responseTrailer.Content);

            string urlCast = "https://imdb-api.com/en/API/FullCast/k_faxyw40f/"+ imdbId;
            var clientCast = new RestClient(urlCast);
            var requestCast = new RestRequest();
            var responseCast = clientCast.Get(requestCast);
            var extractedCast = JsonSerializer.Deserialize<IMDBMovieCast>(responseCast.Content);
            var movie = new Movie()
            {
                ImdbId = extractedFilm.results[0].id,
                Title = extractedFilm.results[0].title,
                Description = extractedFilm.results[0].plot,
                Thumbnail = extractedFilm.results[0].image,
                Rating = Double.Parse(extractedFilm.results[0].imDbRating),
                Duration = int.Parse(extractedFilm.results[0].runtimeStr.Split(' ')[0]), 
                MaturityRating = extractedFilm.results[0].contentRating,
                Trailer = extractedTrailer.linkEmbed,
                ReleaseDate = extractedFilm.results[0].description
            };
            
            context.Movies.Add(movie);
            context.SaveChanges();

            var genresCount = 3;
            if (extractedFilm.results[0].genreList.Count<3)
            {
                genresCount = extractedFilm.results[0].genreList.Count;
            }
            for (int i = 0; i < genresCount; i++)
            {
                var genres = context.Genres.Where(x => x.Genre1.Equals(extractedFilm.results[0].genreList[i].value));
                if (genres.Any())
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                        GenreId = genres.FirstOrDefault().Id

                    };
                    context.MovieGenres.Add(movieGenre);
                }
                else
                {
                    var genre = new Genre
                    {
                        Genre1 = extractedFilm.results[0].genreList[i].value
                       
                    };
                    context.Genres.Add(genre);
                    context.SaveChanges();
                    genres = context.Genres.Where(x => x.Genre1.Equals(extractedFilm.results[0].genreList[i].value));
                    var movieGenre = new MovieGenre
                    {
                        MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                        GenreId = genres.FirstOrDefault().Id

                    };
                    context.MovieGenres.Add(movieGenre);
                }
            }
            var directorsCast = context.staff.Where(x => x.Name.Equals(extractedCast.directors.items[0].name) && x.Position.Equals(extractedCast.directors.job));
            if (directorsCast.Any())
            {
                var movieStaff = new MovieStaff
                {
                    MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                    StaffId = directorsCast.FirstOrDefault().Id
                };
                context.MovieStaffs.Add(movieStaff);
                
            }
            else
            {
                var director = new staff
                {
                    Name = extractedCast.directors.items[0].name,
                    Position = "Director"
                };
                context.staff.Add(director);
                context.SaveChanges();
                directorsCast = context.staff.Where(x => x.Name.Equals(extractedCast.directors.items[0].name) && x.Position.Equals(extractedCast.directors.job));
                var movieStaff = new MovieStaff
                {
                    MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                    StaffId = directorsCast.FirstOrDefault().Id
                };
                context.MovieStaffs.Add(movieStaff);
            }
            
            var writersCast = context.staff.Where(x => x.Name.Equals(extractedCast.writers.items[0].name) && x.Position.Equals(extractedCast.writers.job));
            if (writersCast.Any())
            {
                var movieStaff = new MovieStaff
                {
                    MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                    StaffId = writersCast.FirstOrDefault().Id
                };
                context.MovieStaffs.Add(movieStaff);
            }
            else
            {
                var writer = new staff
                {
                    Name = extractedCast.writers.items[0].name,
                    Position = "Writer"
                };
                context.staff.Add(writer);
                context.SaveChanges();
                writersCast = context.staff.Where(x => x.Name.Equals(extractedCast.writers.items[0].name) && x.Position.Equals(extractedCast.writers.job));
                var movieStaff = new MovieStaff
                {
                    MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                    StaffId = writersCast.FirstOrDefault().Id
                };
                context.MovieStaffs.Add(movieStaff);
            }
            for (int i = 0; i < 3; i++)
            {
                var actorsCast = context.staff.Where(x => x.Name.Equals(extractedCast.actors[i].name) && x.Position.Equals("Actor"));
                if (actorsCast.Any())
                {
                    var movieStaff = new MovieStaff
                    {
                        MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                        StaffId = actorsCast.FirstOrDefault().Id
                    };
                    context.MovieStaffs.Add(movieStaff);
                }
                else
                {
                    var actor = new staff
                    {
                        Name = extractedCast.actors[i].name,
                        Position = "Actor"
                    };
                    context.staff.Add(actor);
                    context.SaveChanges();
                    actorsCast = context.staff.Where(x => x.Name.Equals(extractedCast.actors[i].name) && x.Position.Equals("Actor"));
                    var movieStaff = new MovieStaff
                    {
                        MovieId = context.Movies.Where(x => x.ImdbId.Equals(movie.ImdbId)).FirstOrDefault().Id,
                        StaffId = actorsCast.FirstOrDefault().Id
                    };
                    context.MovieStaffs.Add(movieStaff);
                }
            }
            context.SaveChanges();
            
            
            
        }
        

    }
}
