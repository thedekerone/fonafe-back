using Fonafe.SGI.Common;
using Fonafe.SGI.Common.Exception;
using Fonafe.SGI.Domain.Model.Blog;
using Fonafe.SGI.Domain.Repository.Interface;
using Fonafe.SGI.Domain.Service.Inteface.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fonafe.SGI.Domain.Service.Service.BlogService
{
    public class BlogRequestService : IBlogRequestService
    {
        private readonly IBlogRequestRepository _iblogRequestRepository;

        public BlogRequestService(IBlogRequestRepository blogRequestRepository)
        {
            _iblogRequestRepository = blogRequestRepository;
        }

        public async Task<ProcessResult<List<BlogPost>>> ListBlog()
        {
            var resultadoProceso = new ProcessResult<List<BlogPost>>();
            try
            {
                var lista = await _iblogRequestRepository.ListBlog();
                resultadoProceso.Result = lista.ToList();
            }
            catch (Exception ex)
            {
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<BlogRequestService>(ex);
            }
            return resultadoProceso;
        }

        public async Task<ProcessResult<BlogPost>> AddBlogPost(BlogPost blogPost)
        {
            var resultadoProceso = new ProcessResult<BlogPost>();
            try
            {
                await _iblogRequestRepository.AddBlogPost(blogPost);
                resultadoProceso.Result = blogPost;
            }
            catch (Exception ex)
            {
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<BlogRequestService>(ex);
            }
            return resultadoProceso;
        }

        public async Task<ProcessResult<BlogPost>> GetBlogPostById(string id)
        {
            var resultadoProceso = new ProcessResult<BlogPost>();
            try
            {
                var post = await _iblogRequestRepository.GetBlogPostById(id);
                resultadoProceso.Result = post;
            }
            catch (Exception ex)
            {
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<BlogRequestService>(ex);
            }
            return resultadoProceso;
        }

        //public async Task<ProcessResult<bool>> UpdateBlogPost(BlogPost blogPost)
        //{
        //    var resultadoProceso = new ProcessResult<bool>();
        //    try
        //    {
        //        await _iblogRequestRepository.UpdateBlogPost(blogPost);
        //        resultadoProceso.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultadoProceso.IsSuccess = false;
        //        resultadoProceso.Exception = new ApplicationLayerException<BlogRequestService>(ex);
        //    }
        //    return resultadoProceso;
        //}

        //public async Task<ProcessResult<bool>> DeleteBlogPost(string id)
        //{
        //    var resultadoProceso = new ProcessResult<bool>();
        //    try
        //    {
        //        await _iblogRequestRepository.DeleteBlogPost(id);
        //        resultadoProceso.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        resultadoProceso.IsSuccess = false;
        //        resultadoProceso.Exception = new ApplicationLayerException<BlogRequestService>(ex);
        //    }
        //    return resultadoProceso;
        //}
    }
}
