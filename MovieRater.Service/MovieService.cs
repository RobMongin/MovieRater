using MovieRater.Data;
using MovieRater.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class MovieService
    {
        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                new Movie()
                {
                    MovieId = model.MovieId,
                    Content = model.Content
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Content = e.Content
                                }
                        );
                return query.ToArray();
            }
        }

        public MovieDetail GetMovieById(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == movieId);
                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        Content = entity.Content
                    };
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == model.MovieId);
                entity.Content = model.Content;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int movieId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == movieId);
                ctx.Movies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
