using EntityDAL.Models;
using EntityDAL.Pagination;
using EntityDAL.Parameters;

namespace EntityDAL.Interfaces.Repositories
{
    public interface ITestQuestionRepository: IGenericRepository<TestQuestion>
    {
        Task<PagedList<TestQuestion>> GetAllAsync(TestParameters parameters);
    }
}
