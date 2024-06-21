var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ApiServiceExample>("ApiService");

builder.Build().Run();
