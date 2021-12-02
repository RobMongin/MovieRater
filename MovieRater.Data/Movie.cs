using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required, Display(Name = "Movie")]
        public string Content { get; set; }

        public DateTime Created { get; set; }
    }
}
