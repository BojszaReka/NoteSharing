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

        public ProductionUnitOfWork(IServiceProvider sp)
        {
            UserRepository = sp.GetRequiredService<IUserRepository>();
            PreferenceRepository = sp.GetRequiredService<IPreferenceRepository>();
            InstitutionRepository = sp.GetRequiredService<IInstitutionRepository>();
            SubjectRepository = sp.GetRequiredService<ISubjectRepository>();
            UserSubjectRepository = sp.GetRequiredService<IUserSubjectRepository>();
            UserFollowRepository = sp.GetRequiredService<IUserFollowRepository>();
        }
    }
}
