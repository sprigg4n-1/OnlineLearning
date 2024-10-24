using DapperDAL.Entities;


namespace DapperDAL.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<int> AddModuleAsync(string title, string description, TimeSpan duration, int courseId);
        Task<List<ModuleEntity>> GetAllModulesAsync();
        Task<ModuleEntity> GetModuleByIdAsync(int id);
        Task UpdateModuleAsync(int id, string title, string description, TimeSpan duration, int courseId);
        Task DeleteModuleAsync(int id);
    }
}
