using DapperDAL.Entities;

namespace DapperDAL.Repositories.Interfaces
{
    public interface ICourseRepository: IGenericRepository<CourseEntity>
    {
        Task<IEnumerable<Object>> GetCoursesWithModules();
        Task<IEnumerable<Object>> GetCoursesWithModuleCount();
        
    }
}
