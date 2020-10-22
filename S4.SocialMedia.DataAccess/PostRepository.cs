﻿using Microsoft.EntityFrameworkCore;
using S4.SocialMedia.DataAccess.Base;
using S4.SocialMedia.Entities.Models;
using S4.SocialMedia.Entities.Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S4.SocialMedia.DataAccess
{
    /// <summary>
    /// Specialization of <see cref="RepositoryBase{TModel, TContext}"/> for inclusion of <see cref="AspNetPosts.FkUser"/>
    /// </summary>
    public class PostRepository: RepositoryBase<AspNetPosts, SocialMediaContext>
    {
        #region Overrides
        public override async Task<AspNetPosts> GetByIdAsync(int? id)
        {
            return await context.Set<AspNetPosts>().Include(p => p.FkUser).FirstOrDefaultAsync(p => p.PkId == id);
        }

        public override async Task<IEnumerable<AspNetPosts>> GetAllAsync()
        {
            return await context.Set<AspNetPosts>().Include(p => p.FkUser).ToListAsync();
        }
        #endregion
    }
}