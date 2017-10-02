using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishPets.Models
{
    public interface IBlogPostRepository
    {
        IEnumerable<BlogPost> AllBlogPosts { get; }
        IEnumerable<BlogPost> UsersPosts(string UserId);
        Task<BlogPost> GetBlogPost(int BlogPostId);
        void SaveBlogPost(BlogPost BlogPost, string UserId);
        void UpdateBlogPost(BlogPost BlogPost);
        Task<BlogPost> DeleteBlogPost(int BlogPostId);
    }
}
