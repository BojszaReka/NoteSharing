using Microsoft.Extensions.DependencyInjection;

using web_api.Lib.Repositories;
using web_api.Lib.Repositories.Interfaces;

using web_api.Lib.ManagerServices;
using web_api.Lib.ManagerServices.Interfaces;

using web_api.Lib.UnitOfWork;

namespace web_api.Lib.UnitOfWork
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddLocalServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPreferenceRepository, PreferenceRepository>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserSubjectRepository, UserSubjectRepository>();
            services.AddScoped<IUserFollowRepository, UserFollowRepository>();

            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IPreferenceManagerService, PreferenceManagerService>();
            services.AddScoped<IInstitutionManagerService, InstitutionManagerService>();
            services.AddScoped<ISubjectManagerService, SubjectManagerService>();
            services.AddScoped<IUserSubjectManagerService, UserSubjectManagerService>();
            services.AddScoped<IUserFollowManagerService, UserFollowManagerService>();

            services.AddScoped<IUnitOfWork, ProductionUnitOfWork>();

            return services;
        }
    }
}
