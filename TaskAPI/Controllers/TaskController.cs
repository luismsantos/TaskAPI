using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Context;
using TaskAPI.DTO;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var task = context.Tasks.ToList();

            return task is null || !task.Any() ? NotFound("Tarefas não encontradas") : Ok(task);
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] TaskInsertDTO taskInsertDTO)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == taskInsertDTO.UserId);
            var task = new Models.Task(taskInsertDTO.Title, taskInsertDTO.Description);

            if (user is null)
                return NotFound("Usuário não encontrado");

            user.Tasks ??= new List<Models.Task>();
            user.Tasks.Add(task);

            context.SaveChanges();
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TaskInsertDTO taskInsertDTO)
        {
            var task = context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task is null)
                return NotFound("Tarefa não encontrada");

            if (task.Title != taskInsertDTO.Title)
                task.SetTitle(taskInsertDTO.Title);

            if (task.Description != taskInsertDTO.Description)
                task.SetDescription(taskInsertDTO.Description);

            //if (task.Title == taskInsertDTO.Title && task.Description == taskInsertDTO.Description)
              //  return BadRequest("Nenhum dado foi alterado");

            context.SaveChanges();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task is null)
                return NotFound("Tarefa não encontrada");

            context.Tasks.Remove(task);
            context.SaveChanges();
            return Ok("Tarefa deletada com sucesso");
        }
    }
}
