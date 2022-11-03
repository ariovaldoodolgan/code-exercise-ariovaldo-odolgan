using Palindrome.Api.Services;
using Microsoft.AspNetCore.Cors;
using Palindrome.Api.Data.Repositories;
using Palindrome.Api.Data.Context;
using Palindrome.Api.Business;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddTransient<IPalindromeBusiness, PalindromeBusiness>();
builder.Services.AddTransient<IPalindromeService, PalindromeService>();

builder.Services.AddScoped<IPalindromeRepository, PalindromeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DBContext
var sqlConnectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<DataBaseContext>(options => 
{
    options.UseSqlite(sqlConnectionString);
});

var app = builder.Build();
app.UseCors(options => {
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
