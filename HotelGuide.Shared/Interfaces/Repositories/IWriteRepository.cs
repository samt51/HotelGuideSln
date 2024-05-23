﻿namespace HotelGuide.Shared.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, new()
    {
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task HardDeleteRangeAsync(IList<T> entity);
    }
}
