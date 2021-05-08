using AdditionBonusTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdditionBonusTask.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepo;

        public PostService(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<List<Post>> GetPosts()
        {
            return await _postRepo.GetAll();
        }

        public async Task AddAndSave(Post post)
        {
            _postRepo.Add(post);
            await _postRepo.Save();
        }

        public async Task<List<Post>> Search(string text)
        {
            text = text.ToLower();
            var searchedMovies = await _postRepo.GetPosts(post => post.PostText.ToLower().Contains(text));

            return searchedMovies;
        }

        public async Task RemovePost(Post post)
        {
            _postRepo.DeletePost(post);
            await _postRepo.Save();
        }
    }
}
