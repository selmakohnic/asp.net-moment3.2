using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class User
    {
        //Användar-id
        public int UserId { get; set; }

        //Namn
        [Required]
        [Display(Name = "Namn")]
        public string UserName { get; set; }

        //Utlåningsdatum
        [Required]
        [Display(Name = "Utlåningsdatum")]
        [DataType(DataType.Date)]
        public DateTime BorrowingDate { get; set; }

        //Referenser till CD som lånas
        public int CDId { get; set; }

        public CD CD { get; set; }
    }
}
