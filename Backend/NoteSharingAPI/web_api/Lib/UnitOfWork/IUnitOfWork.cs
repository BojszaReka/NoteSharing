using web_api.Lib.Repositories.Interfaces;

namespace web_api.Lib.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPreferenceRepository PreferenceRepository { get; }
        IInstitutionRepository InstitutionRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IUserSubjectRepository UserSubjectRepository { get; }
        IUserFollowRepository UserFollowRepository { get; }
        IAuthRepository AuthRepository { get; }
        ILogRepository LogRepository { get; }
	}
}
