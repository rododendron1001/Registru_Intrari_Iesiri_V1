using Microsoft.EntityFrameworkCore;
//using Registru_Intrari_Iesiri.Data;
using Registru_Intrari_Iesiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Services
{
    public class InOutRegisterService : IInOutRegisterService
    {
        
        private readonly DataContext _context;

        public InOutRegisterService(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<InOutRegisterEntry>> GetEntriesAsync()
        {
            return await _context.InOutRegisterEntry.ToListAsync();
        }

        public async Task<InOutRegisterEntry> GetByIdAsync(int id)
        {
            var contactListEntry = await _context.InOutRegisterEntry
                .FirstOrDefaultAsync(m => m.Id == id);

            return contactListEntry;
        }

        public async Task<bool> CreateEntryAsync(InOutRegisterEntry entry)
        {
            _context.Add(entry);

            var insertedRows = await _context.SaveChangesAsync();

            return insertedRows > 0;
        }

        public async Task<bool> UpdateEntryAsync(InOutRegisterEntry entry)
        {
            _context.Update(entry);

            int updatedRows = await _context.SaveChangesAsync();

            return updatedRows > 0;
        }

        public async Task<bool> DeleteEntryAsync(int id)
        {
            var inOutRegisterEntry = await _context.InOutRegisterEntry.FindAsync(id);
            _context.InOutRegisterEntry.Remove(inOutRegisterEntry);
            var deletedRows = await _context.SaveChangesAsync();

            return deletedRows > 0;
        }
    }
}
