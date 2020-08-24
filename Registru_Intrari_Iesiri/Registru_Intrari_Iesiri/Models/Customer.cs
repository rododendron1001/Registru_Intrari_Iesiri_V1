using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name.")]
        [Display(Name = "Customer Name")]
        [StringLength(100)]
        public string Name { get; set; }

    }
}
