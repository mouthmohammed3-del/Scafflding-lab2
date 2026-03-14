using Scaffoldinglab2.Data;
using Scaffoldinglab2.Repositories.Interfaces;

namespace Scaffoldinglab2.Repositories.Implementations
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly dblab2DbContext context;

        public UnitOfwork( dblab2DbContext context)
        {
            this.context = context;
        }
        public int saveChanges()
        {
            try
            {
                return context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
