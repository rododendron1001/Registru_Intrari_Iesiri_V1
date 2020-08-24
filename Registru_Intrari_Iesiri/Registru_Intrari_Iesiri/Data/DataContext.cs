using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registru_Intrari_Iesiri.Models;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Registru_Intrari_Iesiri.Models.InOutRegisterEntry> InOutRegisterEntry { get; set; }

        public DbSet<Registru_Intrari_Iesiri.Models.Customer> Customer { get; set; }
   
}
