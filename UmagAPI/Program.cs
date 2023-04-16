using Microsoft.EntityFrameworkCore;
using UmagAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Environment.IsDevelopment()) {
    Console.WriteLine("--> Current Environment: Development");
    var connectionString = builder.Configuration.GetConnectionString("devDbConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>  options.UseNpgsql(connectionString));
} else if(builder.Environment.IsProduction()) {
    Console.WriteLine("--> Current Environment: Production");
    var host = Environment.GetEnvironmentVariable("DB_Host");
    var port = Environment.GetEnvironmentVariable("DB_Port");
    var database = Environment.GetEnvironmentVariable("DB_Name");
    var user = Environment.GetEnvironmentVariable("DB_User");
    var password = Environment.GetEnvironmentVariable("DB_Password");
    var connectionString = $"Host={host};Port={port};Database={database};User Id={user};Password={password}";
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
}



builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

var enableHttpsRedirection = Environment.GetEnvironmentVariable("HttpsRedirection");
if(enableHttpsRedirection == "enable") {
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
