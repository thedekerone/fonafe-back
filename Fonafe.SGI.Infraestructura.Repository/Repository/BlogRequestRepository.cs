using Fonafe.SGI.Domain.Model.Blog;
using Fonafe.SGI.Domain.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;

namespace Fonafe.SGI.Domain.Repository.Repository
{
    public class BlogRequestRepository : IBlogRequestRepository
    {
        private readonly IConfiguration _configuration;
        private readonly FirebaseClient _firebaseClient;

        public BlogRequestRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var firebaseUrl = _configuration["Firebase:Url"];
            var authToken = _configuration["Firebase:AuthToken"];
            _firebaseClient = new FirebaseClient(firebaseUrl, new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(authToken) });
        }

        public async Task<IList<BlogPost>> ListBlog()
        {
            var firebaseObjects = await _firebaseClient
                .Child("BlogPosts")
                .OnceAsync<BlogPost>();

            var posts = new List<BlogPost>();
            foreach (var firebaseObject in firebaseObjects)
            {
                posts.Add(firebaseObject.Object);
            }

            return posts;
        }

        public async Task AddBlogPost(BlogPost blogPost)
        {
            var result = await _firebaseClient
                .Child("BlogPosts")
                .PostAsync(blogPost);

            if (result.Object != null)
            {
                // Captura el ID generado por Firebase y lo asigna al blogPost.
                string generatedId = result.Key;
                blogPost.Id = generatedId;

                // Actualiza el post en Firebase con el ID asignado.
                await _firebaseClient
                    .Child("BlogPosts")
                    .Child(generatedId)
                    .PutAsync(blogPost);
            }
        }

        public async Task<BlogPost> GetBlogPostById(string id)
        {
            var post = await _firebaseClient
                .Child("BlogPosts")
                .Child(id)
                .OnceSingleAsync<BlogPost>();
            return post;
        }

        public async Task UpdateBlogPost(BlogPost blogPost)
        {
            await _firebaseClient
                .Child("BlogPosts")
                .Child(blogPost.Id)
                .PutAsync(blogPost);
        }

        public async Task DeleteBlogPost(string id)
        {
            await _firebaseClient
                .Child("BlogPosts")
                .Child(id)
                .DeleteAsync();
        }

        public async Task<IList<BlogPost>> SearchBlogPosts(string searchInput, DateTime? date)
        {
            var firebaseObjects = await _firebaseClient
                .Child("BlogPosts")
                .OnceAsync<BlogPost>();

            var posts = firebaseObjects.Select(firebaseObject => firebaseObject.Object).ToList();

            if (!string.IsNullOrEmpty(searchInput))
            {
                posts = posts.Where(post =>
                    (post.Title != null && post.Title.Contains(searchInput, StringComparison.OrdinalIgnoreCase)) ||
                    (post.Content != null && post.Content.Contains(searchInput, StringComparison.OrdinalIgnoreCase))
                ).ToList();
            }

            if (date.HasValue)
            {
                posts = posts.Where(post => post.UpdatedDate.Date == date.Value.Date).ToList();
            }

            return posts;
        }

        public async Task<IList<BlogPost>> SearchBlogPosts(string searchInput)
        {
            var allPosts = await ListBlog();
            return allPosts.Where(post =>
                (post.Title != null && post.Title.Contains(searchInput, StringComparison.OrdinalIgnoreCase)) ||
                (post.Content != null && post.Content.Contains(searchInput, StringComparison.OrdinalIgnoreCase)) ||
                (post.Category != null && post.Category.Contains(searchInput, StringComparison.OrdinalIgnoreCase)) ||
                (post.UserId != null && post.UserId.Contains(searchInput, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }
    }
}
