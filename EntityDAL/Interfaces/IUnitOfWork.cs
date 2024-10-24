using EntityDAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Interfaces
{
    public interface IUnitOfWork
    {
        ITestModelRepository TestModelRepository { get; }
        ITestQuestionRepository TestQuestionRepository { get; }
        Task SaveChangsAsync();
    }
}
