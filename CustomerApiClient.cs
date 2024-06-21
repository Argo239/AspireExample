using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationExample.Models;

namespace WebApplicationExample.Controllers {
    public class CustomerApiClient {

        private readonly DataContext _dataContext = new DataContext();

        public async Task<Customer?> GetCustomerAsync(CancellationToken cancellation = default) {
            List<Customer>? customers = await _dataContext.Customers.ToListAsync(cancellation);

            if (customers != null && customers.Count > 0)
                return customers.First();
            return null;
        }
    }
}  