using Microsoft.EntityFrameworkCore;
using S4.SocialMedia.DataAccess.Base;
using S4.SocialMedia.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace S4.SocialMedia.DataAccess
{
    /// <summary>
    /// Specialized version of <see cref="RepositoryBase{T}"/> for <see cref="Post"/> 
    /// to include <see cref="Post.FkUser"/>
    /// </summary>
    public class PostRepository: RepositoryBase<Post>
    {
        /// <summary>
        /// Gets an item by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Post> GetByIdAsync(int id)
        {
            return await context.Set<Post>().Include(p => p.FkUser).FirstOrDefaultAsync(p => p.PkPostId == id);
        }

        /// <summary>
        /// Gets all the items
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await context.Set<Post>().Include(p => p.FkUser).ToListAsync();
        }
    }
}