using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GetPeople.Controllers;


[Route("[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    [HttpGet("all")]
    public ActionResult<People> GetPeoples()
    {
        if(Repository.people.Count == 0)
        {
            Console.WriteLine(Repository.people.Count);
            return NoContent();
        }

        return Ok(Repository.people);
    } 

    [HttpGet("{id}")]
    public ActionResult<People> Get(int id)
    {
        var person = Repository.people.FirstOrDefault(p => p.Id == id);
        return person == null ? NotFound("no se encontro el id " + id) : Ok(person);
    }

    [HttpPost("create")]
    public IActionResult Add(People person)
    {
        if (string.IsNullOrEmpty(person.Name))
        {
            return BadRequest("");
        }
        Repository.people.Add(person);
        return Ok();
        
    }
}

public class Repository
{
    public static List<People> people = new List<People>()
    {
        new People() { Id = 1, Name="elded"},
        new People() { Id = 2, Name="usuariocomun"},
        new People() { Id = 3, Name="agustin51"},
        new People() { Id = 4, Name="gogoggo"},
    };
}

public class People
{
    public int Id { get; set;}
    public string Name { get; set;}

}
