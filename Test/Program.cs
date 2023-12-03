using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Runtime.Intrinsics;
using Test.Data;
using Test.Services.ApartmentService;
using Test.Services.buildingservice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString(name: "DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString)

);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IBuildingService, BuildingService>();
builder.Services.AddTransient<IApartmentService, ApartmentService>();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc(name:"v1",info: new OpenApiInfo
	{
		Version="v1",
		Title="TestApi",


	});
	options.AddSecurityDefinition(name:"Bearer",securityScheme: new OpenApiSecurityScheme
	{
		Name="Authorization",
		Type=SecuritySchemeType.ApiKey,
		Scheme="Bearer",
		BearerFormat="JWT",
		In=ParameterLocation.Header,
		Description="Enter Key"
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
