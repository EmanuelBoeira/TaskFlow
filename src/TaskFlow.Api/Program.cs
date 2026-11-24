using Microsoft.EntityFrameworkCore;
using TaskFlow.Aplication.Interfaces;
using TaskFlow.Aplication.Services;
using TaskFlow.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5001;
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<TaskFlowDBContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Defaultconnection")
    )
);

builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
