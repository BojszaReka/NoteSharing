using web_api.Lib.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace web_api.Lib.UnitOfWork
{
    public class ProductionUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IPreferenceRepository PreferenceRepository { get; }
        public IInstitutionRepository InstitutionRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IUserSubjectRepository UserSubjectRepository { get; }
        public IUserFollowRepository UserFollowRepository { get; }

        public ProductionUnitOfWork(IServiceProvider serviceProvider)
        {
            UserRepository = serviceProvider.GetRequiredService<IUserRepository>();
            PreferenceRepository = serviceProvider.GetRequiredService<IPreferenceRepository>();
            InstitutionRepository = serviceProvider.GetRequiredService<IInstitutionRepository>();
            SubjectRepository = serviceProvider.GetRequiredService<ISubjectRepository>();
            UserSubjectRepository = serviceProvider.GetRequiredService<IUserSubjectRepository>();
            UserFollowRepository = serviceProvider.GetRequiredService<IUserFollowRepository>();
        }
    }
}
