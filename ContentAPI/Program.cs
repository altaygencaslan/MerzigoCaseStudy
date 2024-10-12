using ContentAPI.Business;
using ContentAPI.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var configuration = builder.Configuration;
builder.Services.AddDbContext<ContentDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
builder.Services.AddScoped<IContentRepository, ContentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateAsyncScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ContentDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
