using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetPeople.Services;
namespace GetPeople.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService randomSingleton;
        private IRandomService randomScoped;
        private IRandomService randomTransient;

        public RandomController(IRandomService randomSingleton, IRandomService randomScoped, IRandomService randomTransient)
        {
            this.randomSingleton = randomSingleton;
            this.randomScoped = randomScoped;
            this.randomTransient = randomTransient;
        }
    }
}
