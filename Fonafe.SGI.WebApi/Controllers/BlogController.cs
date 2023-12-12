using Fonafe.SGI.Common;
using Fonafe.SGI.Domain.Model.Blog;
using Fonafe.SGI.Domain.Service.Inteface.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fonafe.SGI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRequestService _blogRequestService;

        public BlogController(IBlogRequestService blogRequestService)
        {
            _blogRequestService = blogRequestService;
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var result = await _blogRequestService.ListBlog();
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Exception);
            }
        }

        // GET: api/Blog/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(string id)
        {
            var result = await _blogRequestService.GetBlogPostById(id);
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Exception);
            }
        }


        // POST: api/Blog
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] BlogPost blogPost)
        {
            var result = await _blogRequestService.AddBlogPost(blogPost);
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Exception);
            }
        }

        // PUT: api/Blog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(string id, [FromBody] BlogPost blogPost)
        {
            blogPost.Id = id;
            var result = await _blogRequestService.UpdateBlogPost(blogPost);
            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // DELETE: api/Blog/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            var result = await _blogRequestService.DeleteBlogPost(id);
            if (result == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPosts(string searchInput)
        {
            var result = await _blogRequestService.SearchBlogPosts(searchInput);
            if (result.IsSuccess)
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest(result.Exception);
            }
        }
    }
}
