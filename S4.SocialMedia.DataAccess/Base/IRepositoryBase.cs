﻿using S4.SocialMedia.Entities.Models.Context;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace S4.SocialMedia.DataAccess.Base
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryBase<T>
    {
        SocialMediaContext Context { get; set; }

        Task AddAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task UpdateAsync();
        Task DeleteAsync(T t);
        Task<bool> Exists(int? id);
    }
}