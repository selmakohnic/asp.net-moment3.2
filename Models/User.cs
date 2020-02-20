using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace moment3_2.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Namn")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Utlåningsdatum")]
        [DataType(DataType.Date)]
        public DateTime BorrowingDate { get; set; }

        public int CDId { get; set; }

        public CD CD { get; set; }
    }
}
