using DotNetCoreWebApi.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

static void NewMethod(WebApplicationBuilder builder)
{
    NewMethod1(builder);

    static void NewMethod1(WebApplicationBuilder builder)
    {
        NewMethod2(builder);
    }
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

NewMethod(builder);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void NewMethod2(WebApplicationBuilder builder)
{
    NewMethod1(builder);
}

static void NewMethod1(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
}