using web_api.Lib.Repositories.Interfaces;

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
	}
}
