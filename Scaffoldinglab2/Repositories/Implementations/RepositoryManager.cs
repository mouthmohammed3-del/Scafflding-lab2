using Scaffoldinglab2.Repositories.Interfaces;

namespace Scaffoldinglab2.Repositories.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
       
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly IUnitOfwork unitOfwork;

        public RepositoryManager(
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            ISubjectRepository subjectRepository,
            IUnitOfwork unitOfwork

            )
        {
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
            this.subjectRepository = subjectRepository;
            this.unitOfwork = unitOfwork;
        }
        public IStudentRepository StudentRepository => studentRepository;

        public ITeacherRepository TeacherRepository =>teacherRepository;

        public ISubjectRepository SubjectRepository => subjectRepository;
        public IUnitOfwork UnitOfwork => unitOfwork;

        IUnitOfwork IRepositoryManager.unitOfwork => throw new NotImplementedException();
    }
}
