using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.TvShowsModel
{
    public class TvShowsCreate
    {
        public int TvShowId { get; set; }

        [MaxLength(15, ErrorMessage = "There are too many characters in this field.")]
        [Required]
        public string TvShowName { get; set; }

        public override string ToString() => TvShowName;
    }
}
