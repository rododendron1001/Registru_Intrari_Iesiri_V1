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
        public int Id { get; set; }

        [Range(1,int.MaxValue)]
        public int DocNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DocDate { get; set; }

        [ForeignKey("CustomerId") ]
        public Customer Customer { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public EntryStatus Status { get; set; }

        [StringLength(1000)]
        public string Resolution { get; set; }
    }
}
