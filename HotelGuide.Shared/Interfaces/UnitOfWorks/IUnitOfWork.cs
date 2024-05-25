﻿using HotelGuide.Shared.Interfaces.Repositories;

namespace HotelGuide.Shared.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, new();
        void OpenTransaction();
        Task<bool> SaveAsyncBool();
        Task SaveAsync1();
        Task CommitAsync();
        void Commit();
        void RollBack();
        int Save();
    }

}
