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
        //Task<ProcessResult<bool>> UpdateBlogPost(BlogPost blogPost);
        //Task<ProcessResult<bool>> DeleteBlogPost(string id);
    }
}
