namespace Scaffoldinglab2.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IStudentRepository StudentRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IUnitOfwork unitOfwork { get; }
    }
}
