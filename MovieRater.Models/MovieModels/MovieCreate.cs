using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models.MovieModels
{
    public class MovieCreate
    {
        public int MovieId { get; set; }

        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        [Required]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public override string ToString() => Content;
    }
}
