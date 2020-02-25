using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class Artist
    {
        //Artist-id
        public int ArtistId { get; set; }

        //Namn
        [Required]
        [Display(Name = "Namn")]
        public string ArtistName { get; set; }

        //Ålder
        [Required]
        [Display(Name = "Ålder")]
        public int ArtistAge { get; set; }

        //Antal släppta album
        [Required]
        [Display(Name = "Antal släppta album")]
        public int NumberOfAlbums { get; set; }

        //Referens till CD-skivor
        public ICollection<CD> CD { get; set; }
    }
}
