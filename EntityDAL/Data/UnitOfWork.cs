using EntityDAL.Interfaces;
using EntityDAL.Interfaces.Repositories;

namespace EntityDAL.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly TestsContext databaseContext;
        public ITestModelRepository TestModelRepository { get; }

        public ITestQuestionRepository TestQuestionRepository { get; }

        public async Task SaveChangsAsync()
        {
            await databaseContext.SaveChangesAsync();
        }

        public UnitOfWork(TestsContext databaseContext, ITestModelRepository testModelRepository, ITestQuestionRepository testQuestionRepository)
        {
            this.databaseContext = databaseContext;
            TestModelRepository = testModelRepository;
            TestQuestionRepository = testQuestionRepository;
        }   
    }
}
