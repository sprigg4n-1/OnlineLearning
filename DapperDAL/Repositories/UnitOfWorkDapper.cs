﻿using DapperDAL.Repositories.Interfaces;
using System.Data;

namespace DapperDAL.Repositories
{
    public class UnitOfWorkDapper: IUnitOfWorkDapper, IDisposable
    {
        public ICourseRepository _courseRepository { get; }

        public IModuleRepository _moduleRepository { get; }

        readonly IDbTransaction _dbTransaction;

        public UnitOfWorkDapper(ICourseRepository courseRepository, IModuleRepository moduleRepository, IDbTransaction dbTransaction)
        {
            _courseRepository = courseRepository;
            _moduleRepository = moduleRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
            }
        }

        public void Dispose()
        {

            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}