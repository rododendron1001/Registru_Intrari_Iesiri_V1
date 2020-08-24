using Microsoft.EntityFrameworkCore;
using Registru_Intrari_Iesiri;
using Registru_Intrari_Iesiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Customer>> GetEntriesAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Id == id);

            return customer;
        }

        public async Task<bool> CreateEntryAsync(Customer entry)
        {
            _context.Add(entry);

            var insertedRows = await _context.SaveChangesAsync();

            return insertedRows > 0;
        }

        public async Task<bool> UpdateEntryAsync(Customer entry)
        {
            _context.Update(entry);

            int updatedRows = await _context.SaveChangesAsync();

            return updatedRows > 0;
        }

        public async Task<bool> DeleteEntryAsync(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            var deletedRows = await _context.SaveChangesAsync();

            return deletedRows > 0;
        }

       

        
    }
}
