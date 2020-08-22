using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Models
{
    public class InOutRegisterEntry
    {
        public int Id { get; set; }
        public int DocNumber { get; set; }
        public DateTime DocDate { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public EntryStatus Status { get; set; }
        public string Resolution { get; set; }
    }
}
