using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public class PostRepo : IPostRepo
    {
        private readonly LibraryDbContext _db;

        public PostRepo(LibraryDbContext db)
        {
            _db = db;
        }

        public Post AddPost(Post post)
        {
            _db.Posts.Add(post);

            if (_db.SaveChanges() > 0)
            {
                return post;
            }
            return null;
        }

        public bool DeletePost(int postId)
        {
            var post = _db.Posts.FirstOrDefault(c => c.Id == postId);
            if (post != null)
            {
                _db.Posts.Remove(post);
                return _db.SaveChanges() > 0;
            }
            return false;
        }

        public IEnumerable<Post> GetPosts()
        {
            return _db.Posts.AsEnumerable();
        }

        public Post GetPost(int postId)
        {
            return _db.Posts.FirstOrDefault(c => c.Id == postId);
        }
    }
}
