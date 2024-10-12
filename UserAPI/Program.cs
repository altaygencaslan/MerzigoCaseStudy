using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserAPI.Business;
using UserAPI.Business.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var configuration = builder.Configuration;
builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHttpClient("ContentService", httpClient =>
{
    string contentServiceUri = configuration.GetSection("BaseAddresses:ContentService")?.Value ?? string.Empty;
    httpClient.BaseAddress = new Uri(contentServiceUri);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetService<UserDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
