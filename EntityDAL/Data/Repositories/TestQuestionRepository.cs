using EntityDAL.Exceptions;
using EntityDAL.Interfaces.Repositories;
using EntityDAL.Models;
using EntityDAL.Pagination;
using EntityDAL.Parameters;
using Microsoft.EntityFrameworkCore;


namespace EntityDAL.Data.Repositories
{
    public class TestQuestionRepository: GenericRepository<TestQuestion>, ITestQuestionRepository
    {
        public TestQuestionRepository(TestsContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<TestQuestion> GetCompleteEntityAsync(int id)
        {
            var testQ = await table.Include(testQ => testQ.TestModel)
                                     .SingleOrDefaultAsync(testQ => testQ.Id == id);

            return testQ ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        public async Task<PagedList<TestQuestion>> GetAllAsync(TestParameters parameters)
        {
            IQueryable<TestQuestion> soure = table.Include(testQ => testQ.TestModel);

            SearchByTestId(ref soure, parameters.TestModelId);
            SearchByQuestionText(ref soure, parameters.QuestionText);

            return await PagedList<TestQuestion>.ToPagedListAsync(
                soure,
                parameters.PageNumber,
                parameters.PageSize);
        }

        public static void SearchByTestId(ref IQueryable<TestQuestion> source, int? testId) {
            if (testId is null || testId == 0)
            {
                return;
            }

            source = source.Where(testQ => testQ.TestModelId == testId);
        }

        public static void SearchByQuestionText(ref IQueryable<TestQuestion> source, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            source = source.Where(testQ => testQ.QuestionText.Contains(text));
        }

    }
}
