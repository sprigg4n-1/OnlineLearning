using AutoMapper;
using EntityBLL.DTO.Request;
using EntityBLL.DTO.Response;
using EntityBLL.Interfaces.Services;
using EntityDAL.Interfaces;
using EntityDAL.Interfaces.Repositories;
using EntityDAL.Models;
using EntityDAL.Pagination;
using EntityDAL.Parameters;

namespace EntityBLL.Services
{
    public class TestQuestionService : ITestQuestionService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ITestQuestionRepository testQuestionRepository;

        private readonly ITestModelRepository testModelRepository;

        public TestQuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            testQuestionRepository = this.unitOfWork.TestQuestionRepository;
            testModelRepository = this.unitOfWork.TestModelRepository;
        }

        public async Task<IEnumerable<TestQuestionResponse>> GetAsync()
        {
            var testQs = await testQuestionRepository.GetAsync();
            return testQs.Select(mapper.Map<TestQuestion, TestQuestionResponse>);
        }

        public async Task<PagedList<TestQuestionResponse>> GetAsync(TestParameters parameters)
        {
            var testQs = await testQuestionRepository.GetAllAsync(parameters);
            return testQs.Map(mapper.Map<TestQuestion, TestQuestionResponse>);
        }

        public async Task<TestQuestionResponse> GetByIdAsync(int id)
        {
            var testQs = await testQuestionRepository.GetCompleteEntityAsync(id);
            return mapper.Map<TestQuestion, TestQuestionResponse>(testQs);
        }

        public async Task InsertAsync(TestQuestionRequest request)
        {
            var testQ = mapper.Map<TestQuestionRequest, TestQuestion>(request);
            await testQuestionRepository.InsertAsync(testQ);
            await unitOfWork.SaveChangsAsync();

        }

        public async Task UpdateAsync(TestQuestionRequest request)
        {
            var testQ = mapper.Map<TestQuestionRequest, TestQuestion>(request);
            await testQuestionRepository.UpdateAsync(testQ);
            await unitOfWork.SaveChangsAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await testQuestionRepository.DeleteAsync(id);
            await unitOfWork.SaveChangsAsync();
        }

    }
}
