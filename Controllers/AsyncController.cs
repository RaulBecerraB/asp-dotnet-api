using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetPeople.Controllers
{
    [Route("")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            //Stop watch es solo para medir el tiempo de ejecución
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //Thread.Sleep es para simular un proceso que tarda 5 segundos
            Thread.Sleep(5000);
            //Elapsed.TotalSeconds es para obtener el tiempo de ejecución en segundos
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed.TotalSeconds);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var task = new Task(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task completed");
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Task 2 completed");
                return 1;
            });
            //Podemos aprovechar los tasks para hacer varias tareas al mismo tiempo
            task.Start();
            Console.WriteLine("Task 1 started");
            task2.Start();
            Console.WriteLine("Task 2 started");
            //await task es para esperar a que la tarea se complete
            await task;
            //se pueden devolver valores de las tareas
            int result = await task2;
            Console.WriteLine("All tasks completed");
            stopwatch.Stop();
            return Ok(stopwatch.Elapsed.TotalSeconds);
        }
    }
}
