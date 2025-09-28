using Mapster;
using System.Reflection;
using web_api.Lib.Database;
using web_api.Lib.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using class_library.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMapster();
TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddControllers(
	options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
}
);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<db_context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddStackExchangeRedisCache(options =>
	options.Configuration = builder.Configuration.GetConnectionString("Cache"));

builder.Services.AddSwaggerGen(options =>
{
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Note Sharing API",
		Description = "An ASP.NET Core Web API for the sharing of notes"
	});
});
builder.Services.AddMapster();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin", policy =>
	{
		policy.AllowAnyOrigin() 
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

builder.Services.AddLocalServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseAuthorization();


app.MapControllers();

app.Run();


