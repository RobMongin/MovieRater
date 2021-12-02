using MovieRater.Models.MovieModels;
using MovieRater.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRater.Web.API.Controllers
{
    public class MovieController : ApiController
    {
        [Authorize]
        public class CommentController : ApiController
        {
            private MovieService CreateMovieService()
            {
                var movieService = new MovieService();
                return movieService;
            }

            // GET
            public IHttpActionResult Get()
            {
                var movieService = CreateMovieService();
                var movies = movieService.GetMovies();
                return Ok(movies);
            }

            public IHttpActionResult Get(int id)
            {
                MovieService movieService = CreateMovieService();
                var movie = movieService.GetMovieById(id);
                return Ok(movie);
            }

            //POST
            public IHttpActionResult Post(MovieCreate movie)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateMovieService();

                if (!service.CreateMovie(movie))
                    return InternalServerError();

                return Ok();
            }

            //PUT (update)
            public IHttpActionResult Put(MovieEdit movie)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var movieService = CreateMovieService();

                if (!movieService.UpdateMovie(movie))
                    return InternalServerError();

                return Ok();
            }

            //DELTE
            public IHttpActionResult Delete(int id)
            {
                var movieService = CreateMovieService();

                if (!movieService.DeleteMovie(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}
