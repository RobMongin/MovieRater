using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.MovieModels
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}
