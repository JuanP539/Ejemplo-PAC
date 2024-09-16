﻿using BusinessLogic;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.In;
using Models.Out;

namespace TDDAvanzado.Controllers
{
    [Route("movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMovieLogic _movieLogic;

        public MoviesController(MovieLogic movieLogic)
        {
            _movieLogic = movieLogic;
        }

        [HttpGet]
        public IActionResult GetMovieByPostfix([FromQuery] string? endsWith)
        {
            List<Movie> movies = _movieLogic.GetMoviesByPostix(endsWith);

            if (endsWith is null)
            {
                return Ok(movies);
            }
            return Ok(movies);
        }

        [HttpGet("{title}")]
        public IActionResult GetMovieByTitle([FromRoute] string title)
        {
            var movie = _movieLogic.GetMovieByTitle(title);
            var response = new RetrieveMovieResponse() { Title = movie.Title, Genres = movie.Genres};
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieRequest movie)
        {
            CreateMovieResponse response = new CreateMovieResponse()
            {
                Title = movie.Title,
                Genres = movie.Genres
            };
            return Created(string.Empty, response);
        }
    }
}
