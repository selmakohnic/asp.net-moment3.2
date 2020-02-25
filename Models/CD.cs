using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class CD
    {
        //CD-id
        public int CDId { get; set; }

        //Titel
        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }

        //Utgivningsdatum
        [Required]
        [Display(Name = "Utgivningsdatum")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //Genre
        [Required]
        public string Genre { get; set; }

        //Skivbolag
        [Required]
        [Display(Name = "Skivbolag")]
        public string RecordCompany { get; set; }

        //Antal låtar 
        [Required]
        [Display(Name = "Antal låtar")]
        public int SongsAmount { get; set; }

        //Referenser till tillhörande artist
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        //Lån av CD
        public ICollection<User> User { get; set; }
    }
}
