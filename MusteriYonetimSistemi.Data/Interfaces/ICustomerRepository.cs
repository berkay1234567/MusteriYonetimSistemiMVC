using MusteriYonetimSistemi.Data.Models.Domain;
using System;

namespace MusteriYonetimSistemi.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> AddAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetByAllAsync();
    }
}