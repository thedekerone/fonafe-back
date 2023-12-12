using Fonafe.SGI.Domain.Model.Blog;
using Fonafe.SGI.Domain.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

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
            try
            {
                var post = await _firebaseClient
                    .Child("BlogPosts")
                    .Child(id)
                    .OnceSingleAsync<BlogPost>();

                return post;
            }
            catch (Exception ex)
            {
                // Handle the exception (log it, return null, or throw a custom exception)
                Console.WriteLine($"Error fetching blog post: {ex.Message}");
                return null;
            }
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
    }
}
