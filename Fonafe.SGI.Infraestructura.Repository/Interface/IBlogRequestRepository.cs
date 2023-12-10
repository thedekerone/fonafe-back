using Fonafe.SGI.Domain.Model.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Repository.Interface
{
    public interface IBlogRequestRepository
    {
        Task<IList<BlogPost>> ListBlog();
        Task AddBlogPost(BlogPost blogPost);
        Task<BlogPost> GetBlogPostById(string id);
        Task UpdateBlogPost(BlogPost blogPost);
        Task DeleteBlogPost(string id);
    }
}
