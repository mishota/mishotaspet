using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MishPets.Models
{
    public class BlogPostRepository: IBlogPostRepository
    {
        private ApplicationDbContext _context ;
        private DbSet<BlogPost> _BlogPosts;
        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
            _BlogPosts = _context.BlogPosts;
        }
        //Общий список сообщений
        public IEnumerable<BlogPost> AllBlogPosts
        {
            get { return _BlogPosts.OrderByDescending(b => b.DatetimeBlogPost); }
        }
        public IEnumerable<BlogPost> UsersPosts(string UserId)
        {
            IEnumerable<BlogPost> bg = _BlogPosts.Where(b => b.ApplicationUser_Id == UserId).OrderByDescending(b => b.DatetimeBlogPost);
            return bg; 
        }
        //Получить сообщение по id
        public async Task<BlogPost> GetBlogPost(int BlogPostId)
        {
            return await _BlogPosts.FindAsync(BlogPostId);
        }
         
        //Сохранение сообщения
        public void SaveBlogPost(BlogPost BlogPost, string UserId)
        {
            if (BlogPost.BlogPostId == 0)
            {
                BlogPost.DatetimeBlogPost = DateTime.Now;
                BlogPost.ApplicationUser_Id = UserId;
                _BlogPosts.Add(BlogPost);
                
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(BlogPost).State = EntityState.Modified;
                _context.SaveChanges();
            }
            
        }
        //Сохранение сообщения
        public void UpdateBlogPost(BlogPost BlogPost)
        {
           _context.Entry(BlogPost).State = EntityState.Modified;
           _context.SaveChanges();
        }
        //Удаление сообщения
        public async Task<BlogPost> DeleteBlogPost(int BlogPostId)
        {
            BlogPost BlogPost = await _BlogPosts.FindAsync(BlogPostId);
            if (BlogPost != null)
            {
                _BlogPosts.Remove(BlogPost);
                _context.SaveChanges();
            }
            
            return BlogPost;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}