using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using web_api.Lib.Database;
using web_api.Lib.UnitOfWork;

namespace web_api
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddMapster();
			TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

			builder.Services.AddControllers(
				options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true
			).AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			
			}); ;

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

			builder.Services.AddEndpointsApiExplorer();
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

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = false,
						ValidateIssuerSigningKey = true,
						ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
						ValidAudience = builder.Configuration["JwtSettings:Audience"],
						NameClaimType = ClaimTypes.Name,
						RoleClaimType = ClaimTypes.Role,
						IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
					};
				});

			builder.Services.AddAuthorization(options =>
			{
				// Basic role policies
				options.AddPolicy("RequireAdministrator", policy =>
					policy.RequireClaim(ClaimTypes.Role, EPermissionType.Administrator.ToString()));

				options.AddPolicy("RequireWorker", policy =>
					policy.RequireClaim(ClaimTypes.Role,
						EPermissionType.Administrator.ToString(),
						EPermissionType.Worker.ToString()));

				options.AddPolicy("RequireUser", policy =>
					policy.RequireClaim(ClaimTypes.Role,
						EPermissionType.Administrator.ToString(),
						EPermissionType.Worker.ToString(),
						EPermissionType.User.ToString()));
			});

			builder.Services.AddLocalServices();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}


