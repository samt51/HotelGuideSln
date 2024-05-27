using HotelGuide.Shared.Interfaces.Repositories;
using HotelGuide.Shared.Interfaces.UnitOfWorks;
using ReportService.Persistence.Concrete.Repositories;
using ReportService.Persistence.Context;

namespace ReportService.Persistence.Concrete.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportDbContext dbContext;

        public UnitOfWork(ReportDbContext dbContext)
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


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);



        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()
        {
            return new WriteRepository<T>(dbContext);
        }

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
    }
}
