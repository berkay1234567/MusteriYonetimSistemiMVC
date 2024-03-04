using MusteriYonetimSistemi.Data.Interfaces;
using MusteriYonetimSistemi.Data.Models.Domain;



namespace MusteriYonetimSistemi.Data.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ISqlDataAccess _db;

        public CustomerRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Customer customer)
        {

            try
            {
                await _db.SaveData("sp_create_customer", new { customer.CustomerName, customer.CustomerSurName, customer.Address,
                    customer.City,customer.Region,customer.PostalCode,customer.Country,customer.Phone,customer.Email });
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            try
            {
                await _db.SaveData("sp_update_customer", customer);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_customer", new { CustomerId = id });
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {

            IEnumerable<Customer> result = await _db.GetData<Customer, dynamic>("sp_get_customer", new { CustomerId = id });
            return result.FirstOrDefault();

        }

        public async Task<IEnumerable<Customer>> GetByAllAsync()
        {

            string query = "sp_get_all_customers";
            return await _db.GetData<Customer, dynamic>(query, new { });

        }

    }


}
