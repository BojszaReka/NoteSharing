using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace web_api.Lib.UnitOfWork
{
    public class ProductionUnitOfWork : IUnitOfWork
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public IUserRepository userRepository { get; }
        public IPreferenceRepository preferenceRepository { get; }
        public IInstitutionRepository institutionRepository { get; }
        public ISubjectRepository subjectRepository { get; }
        public IUserSubjectRepository userSubjectRepository { get; }
        public IUserFollowRepository userFollowRepository { get; }
        public IAuthRepository authRepository { get; }
        public ILogRepository logRepository { get; }
        public IStudentRepository studentRepository { get; }

        public INoteRepository noteRepository { get; }
        public ICollectionRepository collectionRepository { get; }
        public INoteRequestRepository noteRequestRepository { get; }

        public ProductionUnitOfWork(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

            userRepository = new UserRepository(_scopeFactory);
            preferenceRepository = new PreferenceRepository(_scopeFactory);
            institutionRepository = new InstitutionRepository(_scopeFactory);
            subjectRepository = new SubjectRepository(_scopeFactory);
            userSubjectRepository = new UserSubjectRepository(_scopeFactory);
            userFollowRepository = new UserFollowRepository(_scopeFactory);
            authRepository = new AuthRepository(_scopeFactory);
            logRepository = new LogRepository(_scopeFactory);
            studentRepository = new StudentRepository(_scopeFactory);

            noteRepository = new NoteRepository(_scopeFactory);
            collectionRepository = new CollectionRepository(_scopeFactory);
            noteRequestRepository = new NoteRequestRepository(_scopeFactory);
        }
    }
}
