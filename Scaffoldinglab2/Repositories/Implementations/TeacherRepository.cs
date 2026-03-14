using Scaffoldinglab2.Data;
using Scaffoldinglab2.Models;
using Scaffoldinglab2.Repositories.Interfaces;

namespace Scaffoldinglab2.Repositories.Implementations
{
    public class TeacherRepository : GenericRepository<Teacher> , ITeacherRepository
    {
        public TeacherRepository(dblab2DbContext context) : base(context)
        {
            
        }
    }
}
