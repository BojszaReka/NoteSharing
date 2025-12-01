using web_api.Lib.Repositories.Interfaces;
using web_api.Lib.Services.Interfaces;  

namespace web_api.Lib.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository userRepository { get; }
        IPreferenceRepository preferenceRepository { get; }
        IInstitutionRepository institutionRepository { get; }
        ISubjectRepository subjectRepository { get; }
        IUserSubjectRepository userSubjectRepository { get; }
        IUserFollowRepository userFollowRepository { get; }
        IAuthRepository authRepository { get; }
        ILogRepository logRepository { get; }
        IStudentRepository studentRepository { get; }
        INoteRepository noteRepository { get; }
        ICollectionRepository collectionRepository { get; }
        INoteRequestRepository noteRequestRepository { get; }
    }
}
