using EntityBLL.DTO.Request;
using EntityBLL.DTO.Response;
using EntityDAL.Pagination;
using EntityDAL.Parameters;

namespace EntityBLL.Interfaces.Services
{
    public interface ITestQuestionService
    {
        Task<IEnumerable<TestQuestionResponse>> GetAsync();

        Task<PagedList<TestQuestionResponse>> GetAsync(TestParameters parameters);

        Task<TestQuestionResponse> GetByIdAsync(int id);

        Task InsertAsync(TestQuestionRequest request);

        Task UpdateAsync(TestQuestionRequest request);

        Task DeleteAsync(int id);
    }
}
