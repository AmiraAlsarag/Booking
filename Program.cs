using Booking_ReservationAPI;
using Booking_ReservationAPI.Data;
using Booking_ReservationAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));

});

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddAutoMapper(typeof(MappingConfig));

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
    .WriteTo.File("log/ReservationLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers().AddNewtonsoftJson();

//(options =>{options.ReturnHttpNotAcceptable = true; }

//.AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
