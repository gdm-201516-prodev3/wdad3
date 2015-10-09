using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Data
{
    public interface IPostRepo
    {
        IEnumerable<Post> GetPosts();
        Post GetPost(int postId);
        Post AddPost(Post post);
        bool DeletePost(int postId);
    }
}
