using System;
using GetPeople.DTOs;

namespace GetPeople.Services;

public interface IPostService
{
    public Task<IEnumerable<PostDTO>> GetPosts();
}
