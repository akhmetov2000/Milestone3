using AdditionBonusTask.Controllers;
using AdditionBonusTask.Core;
using AdditionBonusTask.Data;
using AdditionBonusTask.Models;
using AdditionBonusTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AdditionalBonusTask.Test
{
    public class UnitTest1
    {
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IPostRepository>();
            var postService = new PostService(fakeRepository);

            var post = new Post() {
                PostText = "test text",
                PostImage = "https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg",
                PublicDate = DateTime.Now,
                UserId = "01cf5bc4-420c-4d9e-bef2-2b0a9f0f9797"
            };
            await postService.AddAndSave(post);
        }

        [Fact]
        public async Task GetPostsTest()
        {
            var posts = new List<Post>
            {
                new Post() { PostText = "test post 1" },
                new Post() { PostText = "test post 2" },
            };

            var fakeRepositoryMock = new Mock<IPostRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(posts);


            var postService = new PostService(fakeRepositoryMock.Object);

            var resultPosts = await postService.GetPosts();

            Assert.Collection(resultPosts, post =>
            {
                Assert.Equal("test post 1", post.PostText);
            },
            post =>
            {
                Assert.Equal("test post 2", post.PostText);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var posts = new List<Post>
            {
                new Post() { PostText = "test post 1" },
                new Post() { PostText = "test post 2" },
            };

            var fakeRepositoryMock = new Mock<IPostRepository>();
            fakeRepositoryMock.Setup(x => x.GetPosts(It.IsAny<Expression<Func<Post, bool>>>())).ReturnsAsync(posts);


            var postService = new PostService(fakeRepositoryMock.Object);

            var resultPosts = await postService.Search("TEST");

            Assert.Collection(resultPosts, post =>
            {
                Assert.Equal("test post 1", post.PostText);
            },
            post =>
            {
                Assert.Equal("test post 2", post.PostText);
            });
        }

        //[Fact]
        //public async Task AddComments_WithCorrectInputData_ReturnSameComment()
        //{

        //    var comment = new Comment()
        //    {
        //        CommentText = "test comment",
        //        CommentDate = DateTime.Now,
        //        PostId = 1,
        //        UserId = "01cf5bc4-420c-4d9e-bef2-2b0a9f0f9797"
        //    };
        //    var commentConn = new CommentService(comment);
        //    commentConn.AddComment(comment);

        //    Assert.Equal(1, commentConn.SizeComment);
        //}


    }
}
