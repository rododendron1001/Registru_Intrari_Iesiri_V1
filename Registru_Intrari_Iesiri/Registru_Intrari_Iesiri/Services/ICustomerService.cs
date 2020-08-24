using Registru_Intrari_Iesiri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registru_Intrari_Iesiri.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetEntriesAsync();

        Task<Customer> GetByIdAsync(int id);

        Task<bool> CreateEntryAsync(Customer entry);

        Task<bool> UpdateEntryAsync(Customer entry);

        Task<bool> DeleteEntryAsync(int id);
    }
}
