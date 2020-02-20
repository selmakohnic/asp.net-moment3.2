using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Namn")]
        public string ArtistName { get; set; }

        [Required]
        [Display(Name = "Ålder")]
        public int ArtistAge { get; set; }

        [Required]
        [Display(Name = "Antal släppta album")]
        public int NumberOfAlbums { get; set; }

        public ICollection<CD> CD { get; set; }
    }
}
