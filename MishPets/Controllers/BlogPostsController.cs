using Microsoft.AspNet.Identity;
using MishPets.Models;
using PagedList;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

//using MishDomain;

namespace MishPets.Controllers
{
    public class BlogPostsController : Controller
    {
        private UnitOfWork UOW = new UnitOfWork(new ApplicationDbContext());

        // GET: BlogPosts
        public ActionResult Index()
        {
            //int pageSize = 6;
            //int pageNumber = (page ?? 1);
            //return View(UOW.BlogPostRepository.AllBlogPosts.ToPagedList(pageNumber, pageSize));
            return View(UOW.BlogPostRepository.AllBlogPosts);
        }

        // GET: BlogPosts
        public ActionResult List(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(UOW.BlogPostRepository.AllBlogPosts.ToPagedList(pageNumber, pageSize));
            //return View(UOW.BlogPostRepository.AllBlogPosts);
        }
        // GET: BlogPosts
        public ActionResult UsersList()
        {
            string usid = User.Identity.GetUserId();
            if ((UOW.BlogPostRepository.UsersPosts(usid))!= null)
            {
                return View(UOW.BlogPostRepository.UsersPosts(usid));
            }
            else
            {
                return View("У вас нет сообщений");
            }
        }

        //Метод getimage**********************************
        public async Task<FileContentResult> GetImage(int BlogPostId)
        {
            BlogPost blogPost = await UOW.BlogPostRepository.GetBlogPost(BlogPostId);
            if (blogPost != null)
                return File(blogPost.ImagePost, blogPost.ImagePostMimeType);
            else return null;
        }

        // GET: BlogPosts/Details/5
        public async Task<ActionResult> Details(int BlogPostId)
        {
            BlogPost blogPost = await UOW.BlogPostRepository.GetBlogPost(BlogPostId);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogPostId,DatetimeBlogPost,TextOfPost,ImagePost,ImagePostMimeType")] BlogPost blogPost, HttpPostedFileBase image = null)
        {
            blogPost.DatetimeBlogPost = DateTime.Now;
            if (image != null)
            {
                blogPost.ImagePost= new byte[image.ContentLength];
                blogPost.ImagePostMimeType = image.ContentType;
                image.InputStream.Read(blogPost.ImagePost, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                string usid = User.Identity.GetUserId();
                UOW.BlogPostRepository.SaveBlogPost(blogPost,usid);
                return RedirectToAction("List");
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        public async Task<ActionResult> Edit(int BlogPostId)
        {
            BlogPost blogPost = await UOW.BlogPostRepository.GetBlogPost(BlogPostId);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogPostId,DatetimeBlogPost,TextOfPost,ImagePost,ImagePostMimeType")] BlogPost blogPost,  HttpPostedFileBase image = null)
        {
            //Для добавления фото*******************************
            if (image != null)
            {
                blogPost.ImagePostMimeType = image.ContentType;
                blogPost.ImagePost = new byte[image.ContentLength];
                image.InputStream.Read(blogPost.ImagePost, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                string usid = User.Identity.GetUserId();
                UOW.BlogPostRepository.SaveBlogPost(blogPost, usid);
                return RedirectToAction("List");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        public async Task<ActionResult> Delete(int BlogPostId)
        {
            BlogPost blogPost = await UOW.BlogPostRepository.GetBlogPost(BlogPostId);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int BlogPostId)
        {
            BlogPost blogPost = await UOW.BlogPostRepository.DeleteBlogPost(BlogPostId);
            return RedirectToAction("List");
        }
    }
}
