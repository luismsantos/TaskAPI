using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAPI.Context;
using TaskAPI.DTO;
using TaskAPI.Models;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var user = context.Users.ToList();
            return user is null || !user.Any() ? NotFound("Não existem usuários cadastrados") : Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = context.Users
                .Include(u => u.Tasks)
                .FirstOrDefault(u => u.Id == id);
            return user is null ? NotFound("Usuário não encontrado") : Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserInsertDTO userInsertDto)
        {
            var user = new User(userInsertDto.Name, userInsertDto.Email, userInsertDto.Password);

            context.Users.Add(user);
            context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
                return NotFound("Usuário não encontrado");

            context.Users.Remove(user);
            context.SaveChanges();
            return Ok("Usuário removido com sucesso");
        }
    }
}
