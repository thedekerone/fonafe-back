using Fonafe.SGI.Common;
using Fonafe.SGI.Domain.Model.Blog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Service.Inteface.Blog
{
    public interface IBlogRequestService
    {
        Task<ProcessResult<List<BlogPost>>> ListBlog();
        Task<ProcessResult<BlogPost>> AddBlogPost(BlogPost blogPost);
        Task<ProcessResult<BlogPost>> GetBlogPostById(string id);
        Task<bool> UpdateBlogPost(BlogPost blogPost);
        Task<bool> DeleteBlogPost(string id);
        Task<ProcessResult<List<BlogPost>>> SearchBlogPosts(string searchInput);
    }
}
