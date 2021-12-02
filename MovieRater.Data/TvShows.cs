using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class TvShows
    {
        [Key]
        public int TvShowId { get; set; }

        [Required, Display(Name = "Tv Show Name")]
        public string TvShowName { get; set; }
    }
}
