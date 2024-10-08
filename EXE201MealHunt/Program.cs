using MealHunt_APIs;
using MealHunt_APIs.ServiceExtensions;
using MealHunt_Repositories;
using MealHunt_Repositories.Data;
using MealHunt_Repositories.Implements;
using MealHunt_Repositories.Interfaces;
using MealHunt_Services.Implements;
using MealHunt_Services.Interfaces;
using MealHunt_Services.Mapper;
using System.Reflection;

var MyAllowSpecificOrigins = "myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dbcontext
builder.Services.AddDbContext<MealHuntContext>();

// Auto Mapper
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// Seed data
builder.Services.AddTransient<Seed>();


// Service Extensions
builder.Services.AddApplicationServices();

var app = builder.Build();

//Seed data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
