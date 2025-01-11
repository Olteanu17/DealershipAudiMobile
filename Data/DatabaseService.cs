using SQLite;
using DealershipAudiMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealershipAudiMobile.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Car>().Wait();
            _database.CreateTableAsync<Customer>().Wait();
            _database.CreateTableAsync<Sale>().Wait();
        }

        public Task<List<Car>> GetCarsAsync() => _database.Table<Car>().ToListAsync();

        public Task<int> SaveCarAsync(Car car)
        {
            if (car.ID == 0)
            {
                return _database.InsertAsync(car);
            }
            else
            {
                return _database.UpdateAsync(car);
            }
        }

        public Task<int> DeleteCarAsync(Car car) => _database.DeleteAsync(car);

        public Task<List<Customer>> GetCustomersAsync() => _database.Table<Customer>().ToListAsync();

        public Task<int> SaveCustomerAsync(Customer customer)
        {
            if (customer.ID == 0)
            {
                return _database.InsertAsync(customer);
            }
            else
            {
                return _database.UpdateAsync(customer);
            }
        }

        public Task<int> DeleteCustomerAsync(Customer customer) => _database.DeleteAsync(customer);

        public Task<List<Sale>> GetSalesAsync() => _database.Table<Sale>().ToListAsync();

        public Task<int> SaveSaleAsync(Sale sale)
        {
            if (sale.ID == 0)
            {
                return _database.InsertAsync(sale);
            }
            else
            {
                return _database.UpdateAsync(sale);
            }
        }

        public Task<int> DeleteSaleAsync(Sale sale) => _database.DeleteAsync(sale);
    }
}
