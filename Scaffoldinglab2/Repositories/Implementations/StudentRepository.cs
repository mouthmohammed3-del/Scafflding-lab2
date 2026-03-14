using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.Repositories.Interfaces;

namespace Scaffoldinglab2.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(dblab2DbContext context):base(context) 
        {
            
        }
    } 
}
