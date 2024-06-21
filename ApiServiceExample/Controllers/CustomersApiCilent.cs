using ApiServiceExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CustomerApiClient{
    private readonly DataContext _dataContext;

    public CustomerApiClient(DataContext dataContext) {
        _dataContext = dataContext;
    }

    public async Task<List<Customer>> GetCustomersAsync(CancellationToken cancellation = default) {
        // 使用 LINQ 查询所有用户
        return await _dataContext.Customers
            //.Where(c => c.HasDelete == 0) // 假设 HasDelete 表示未删除
            .ToListAsync(cancellation);
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id, CancellationToken cancellation = default) {
        return await _dataContext.Customers.FirstOrDefaultAsync(c => c.Uid == id, cancellation);
    }
}
