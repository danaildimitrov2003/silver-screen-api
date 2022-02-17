﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SilverScreen.Models.Tables;
using SilverScreen.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilverScreen.Controllers
{
    public class MainPageMovieInfoController : Controller
    {
        private IConfiguration configuration;


        public MainPageMovieInfoController(IConfiguration config)
        {
            configuration = config;
        }
        /// <summary>
        /// This metod select all movies based on a specific genre.
        /// </summary>
        /// <param name="genreID">The genre based on witch movies are retrieved.</param>
        /// <returns>Returns a list of movies by genre.</returns>
        [HttpGet]
        [Route("GetMoviesForMainPage")]
        public List<Movie> GetMoviesByGenreForMainPage(int genreID)
        {
            MainPageMovieInfoService service = new MainPageMovieInfoService(configuration);
            return service.GetMoviesByGenre(genreID);
        }

        [HttpGet]
        [Route("GetMoviesForMyList")]
        [Authorize]
        public IActionResult GetMoviesForMyList(bool watched)
        {
            var user = HttpContext.User;
            if (user.HasClaim(x => x.Type == "userID"))
            {
                MainPageMovieInfoService service = new MainPageMovieInfoService(configuration);
                return Json(service.GetMyListMovies(int.Parse(user.Claims.FirstOrDefault(x => x.Type == "userID").Value), watched));

            }
            return Unauthorized();
        }
    }
}