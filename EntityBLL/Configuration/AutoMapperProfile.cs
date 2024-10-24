using AutoMapper;
using EntityBLL.DTO.Request;
using EntityBLL.DTO.Response;
using EntityDAL.Models;

namespace EntityBLL.Configuration
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile() {
            CreateTeamQuestionMapps();
        }
        private void CreateTeamQuestionMapps()
        {
            CreateMap<TestQuestionRequest, TestQuestion>();
            CreateMap<TestQuestion, TestQuestionResponse>();
        }
    }
}
