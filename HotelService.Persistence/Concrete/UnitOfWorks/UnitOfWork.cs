﻿using HotelGuide.Shared.Interfaces.Repositories;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using HotelService.Persistence.Concrete.Repositories;
using HotelService.Persistence.Context;

namespace HotelService.Persistence.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDbContext dbContext;

        public UnitOfWork(HotelDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task CommitAsync()
        {
            await dbContext.Database.CommitTransactionAsync();
        }

        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();

        public void OpenTransaction()
        {
            dbContext.Database.BeginTransactionAsync();
        }

        public void RollBack()
        {
            dbContext.Database.RollbackTransaction();
        }

        public int Save() => dbContext.SaveChanges();

        public async Task<bool> SaveAsyncBool()
        {
            try
            {
                var result = await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);

            }
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);



        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(dbContext);
        }
    }
}
