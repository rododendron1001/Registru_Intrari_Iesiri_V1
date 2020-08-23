using Registru_Intrari_Iesiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Services
{
    public interface IInOutRegisterService
    {
        Task<IEnumerable<InOutRegisterEntry>> GetEntriesAsync();

        Task<InOutRegisterEntry> GetByIdAsync(int id);

        Task<bool> CreateEntryAsync(InOutRegisterEntry entry);

        Task<bool> UpdateEntryAsync(InOutRegisterEntry entry);

        Task<bool> DeleteEntryAsync(int id);
    }
}
