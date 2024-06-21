using ApiServiceExample.Models;
using AspireExample.ServiceDefaults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddScoped<CustomerApiClient>();

//Add DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseExceptionHandler();

// https://localhost:7136/customer
app.MapGet($"/customer", async ([FromServices] CustomerApiClient customerApiClient, CancellationToken cancellation) => {
    var customerList = await customerApiClient.GetCustomersAsync(cancellation);
    return Results.Ok(customerList);
});

// https://localhost:7136/customer/1     "/customer/{id:int}"
app.MapGet($"/customer/{{id:int}}", async ([FromServices] CustomerApiClient customerApiClient, int id, CancellationToken cancellation) => {
    var customerList = await customerApiClient.GetCustomerByIdAsync(id);
    if (customerList == null)
        return Results.NotFound("Not fount this customer");
    return Results.Ok(customerList);
});

app.MapDefaultEndpoints();

app.Run();