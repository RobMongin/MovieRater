using MovieRater.Data;
using MovieRater.Models.TvShowsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Service
{
    public class TvShowService
    {
        public bool CreateTvShow(TvShowCreate model)
        {
            var entity =
                new TvShow()
                {
                    TvShowId = model.TvShowId,
                    TvShowName = model.TvShowName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TvShows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TvShowListItem> GetTvShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TvShows
                        .Select(
                            e =>
                                new TvShowListItem
                                {
                                    TvShowId = e.TvShowId,
                                    TvShowName = e.TvShowName
                                }
                        );
                return query.ToArray();
            }
        }

        public TvShowDetail GetTvShowId(int tvShowId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TvShows
                        .Single(e => e.TvShowId == tvShowId);
                return
                    new TvShowDetail
                    {
                        TvShowId = entity.TvShowId,
                        TvShowName = entity.TvShowName
                    };
            }
        }

        public bool UpdateTvShow(TvShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TvShows
                        .Single(e => e.TvShowId == model.TvShowId);
                entity.TvShowName = model.TvShowName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTvShow(int tvShowId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TvShows
                        .Single(e => e.TvShowId == tvShowId);
                ctx.TvShows.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
