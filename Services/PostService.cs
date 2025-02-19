using System;
using System.Text.Json;
using GetPeople.DTOs;

namespace GetPeople.Services;

public class PostService : IPostService
{
    private readonly HttpClient _httpClient;

    public PostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<PostDTO>> GetPosts()
    {
        var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var posts = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(content, options);
        return posts ?? Enumerable.Empty<PostDTO>();
    }
}
