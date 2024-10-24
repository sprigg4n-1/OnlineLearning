
namespace DapperDAL.Repositories.Interfaces
{
    public interface IUnitOfWorkDapper: IDisposable
    {
        ICourseRepository _courseRepository { get; }

        IModuleRepository _moduleRepository { get; }
        void Commit();
        void Dispose();
    }
}
