using web_api.Lib.Repositories.Interfaces;

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
        public IAuthRepository AuthRepository { get; }
        public ILogRepository LogRepository { get; }

		public ProductionUnitOfWork(IServiceProvider serviceProvider)
        {
            UserRepository = serviceProvider.GetRequiredService<IUserRepository>();
            PreferenceRepository = serviceProvider.GetRequiredService<IPreferenceRepository>();
            InstitutionRepository = serviceProvider.GetRequiredService<IInstitutionRepository>();
            SubjectRepository = serviceProvider.GetRequiredService<ISubjectRepository>();
            UserSubjectRepository = serviceProvider.GetRequiredService<IUserSubjectRepository>();
            UserFollowRepository = serviceProvider.GetRequiredService<IUserFollowRepository>();
            AuthRepository = serviceProvider.GetRequiredService<IAuthRepository>();
            LogRepository = serviceProvider.GetRequiredService<ILogRepository>();
		}
    }
}
