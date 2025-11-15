using Microsoft.Extensions.DependencyInjection;
using web_api.Lib.Services;
using web_api.Lib.Services.Interfaces;

namespace web_api.Lib.UnitOfWork
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddLocalServices(this IServiceCollection services)
        {
            
			services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IPreferenceManagerService, PreferenceManagerService>();
            services.AddScoped<IInstitutionManagerService, InstitutionManagerService>();
            services.AddScoped<ISubjectManagerService, SubjectManagerService>();
            services.AddScoped<IUserSubjectManagerService, UserSubjectManagerService>();
            services.AddScoped<IUserFollowManagerService, UserFollowManagerService>();
			services.AddScoped<IAuthManagerService, AuthManagerService>();
            services.AddScoped<ILogManagerService, LogManagerService>();
            services.AddScoped<IStudentManagerService, StudentManagerService>();


            services.AddScoped<IUnitOfWork, ProductionUnitOfWork>();

            return services;
        }
    }
}
