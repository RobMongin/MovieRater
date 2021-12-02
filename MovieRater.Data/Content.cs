using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public enum MaturityRating
    {
        G,
        PG,
        PG_13,
        R,
        NC_17,
        TV_Y,
        TV_G,
        TV_PG,
        TV_14,
        TV_MA
    }

    public enum GenreType
    {
        Comedy = 1,
        Horror,
        Action,
        SciFi,
        Fantasy,
        RomCom,
        Thriller,
        Drama,
        Adventure
    }

    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string  Description { get; set; }

        [Required]
        public MaturityRating MaturityRating { get; set; }

        [Required]
        public GenreType GenreType { get; set; }

        public bool IsFamilyFriendly
        {
            get
            {
                switch (MaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                    case MaturityRating.TV_Y:
                    case MaturityRating.TV_G:
                    case MaturityRating.TV_PG:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}
