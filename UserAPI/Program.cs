using Helper.Classes;
using Helper.CustomHttpClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection;
using UserAPI.Business;
using UserAPI.Business.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var configuration = builder.Configuration;
builder.Services.AddDbContext<UserDbContext>(options => options.UseNpgsql(configuration.GetSection("ConnectionStrings:PostgreSQL")?.Value ?? ""));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IHttpClientHelper, HttpClientHelper>();
//builder.Services.AddScoped<CustomHttpClient>();
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

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (Exception ex)
    {
        var error = new ResultDto<string>(false, $"Exception: {ex.ToString()}", "Somethings went wrong");

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(error);
        return;
    }
});

app.Run();
