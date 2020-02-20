using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class CD
    {
        public int CDId { get; set; }

        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Utgivningsdatum")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Skivbolag")]
        public string RecordCompany { get; set; }

        [Required]
        [Display(Name = "Antal låtar")]
        public int SongsAmount { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
