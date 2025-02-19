using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetPeople.Services;

namespace GetPeople.Controllers
{
    [Route("")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postService.GetPosts();
            return Ok(posts);
        }
    }
}
