using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using PostBackend.entity;
using PostBackend.Models;

namespace PostBackend.Controllers
{
    public class PostsController : ApiController
    {
        private PostContext db = new PostContext();

        // GET: api/Posts
        [AllowAnonymous]
        //public List<string> getArr()
        //{
        //    List<string> data = new List<string>() { "Hello", "World" };
        //    return data;
        //    //return db.Posts.ToList();
        //}

        public async Task<IHttpActionResult> GetPosts(int pageNo, int size)
        {
            List<Post> allPosts = new List<Post>();
            //List<Comment> allComments = new List<Comment>();

            allPosts = await db.Posts.OrderBy(x=>x.PostId).Skip((pageNo - 1) * size).Take(size).ToListAsync();

            List<vmPost> allPostWithComments = allPosts.Select(pst => new vmPost()
            {
                PostId = pst.PostId,
                PostTitle = pst.PostTitle,
                PostAddedBy = pst.PostAddedBy,
                PostAddedDate = pst.PostAddedDate,
                Comments = db.Comments.Where(x=>x.PostId == pst.PostId).ToList()
            }).ToList();


            //foreach (var item in db.Posts.ToList())
            //{
            //    var cmnts = db.Comments.Where(x => x.PostId == item.PostId)
            //        .Select(a=> new { a.CommentId, a.CommentTitle, a.CommentAddedBy, a.CommentAddedDate})
            //        .ToList();

            //}


            //allPostWithComments.AddRange(customPost);
            //foreach(var item in )


            return Ok(allPostWithComments);
        }

        [HttpPost]
        public IHttpActionResult UpdateLike(int cmntId, int postId)
        {
            Comment cmnt = db.Comments.Single(x => x.CommentId == cmntId && x.PostId == postId);
            cmnt.LikeCount += 1;
            db.SaveChanges();

            return Ok(1);
        }
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult UpdateDisLike(int cmntId, int postId)
        {
            Comment cmnt = db.Comments.Single(x => x.CommentId == cmntId && x.PostId == postId);

            cmnt.DislikeCount = cmnt.DislikeCount > 0 ? cmnt.DislikeCount -= 1 : 0;
            db.SaveChanges();

            return Ok(1);
        }
        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult GetPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.PostId)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public IHttpActionResult PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public IHttpActionResult DeletePost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.PostId == id) > 0;
        }
    }
}