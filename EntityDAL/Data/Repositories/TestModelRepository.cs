using EntityDAL.Exceptions;
using EntityDAL.Interfaces.Repositories;
using EntityDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace EntityDAL.Data.Repositories
{
    public class TestModelRepository : GenericRepository<TestModel>, ITestModelRepository
    {
        public TestModelRepository(TestsContext databaseContext) : base(databaseContext)
        {
        }

        public async override Task<TestModel> GetCompleteEntityAsync(int id)
        {
            var test = await table.Include(test => test.CourseId)
                                    .Include(test => test.TestQuestions)
                                    .SingleOrDefaultAsync(testQ => testQ.Id == id);

            return test ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }
    }
}
