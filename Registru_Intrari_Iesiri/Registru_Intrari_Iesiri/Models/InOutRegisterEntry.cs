using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Models
{
    public class InOutRegisterEntry
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Range(1,int.MaxValue)]
        [Required(ErrorMessage = "Please enter Document Data.")]
        [Display(Name = "Document Number")]
        public int DocNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter Document Data.")]
        [Display(Name = "Document Data")]
        public DateTime DocDate { get; set; }

        [ForeignKey("CustomerId") ]
        public Customer Customer { get; set; }

        [StringLength(1000)]
        [Display(Name = "Request Description")]
        public string Description { get; set; }

        public EntryStatus Status { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Please enter Resolution.")]
        [Display(Name = "Resolution")]
        public string Resolution { get; set; }
    }
}
