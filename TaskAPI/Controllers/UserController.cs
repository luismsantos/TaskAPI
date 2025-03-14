﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserInsertDTO userInsertDTO)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)   
                return NotFound("Usuário não encontrado");

            if (user.Email == userInsertDTO.Email && user.Password == userInsertDTO.Password)
                return BadRequest("Dados iguais não podem ser alterados");
            
            if (user.Name == userInsertDTO.Name)
                return BadRequest("Dados iguais não podem ser alterados");

            if (user.Name != userInsertDTO.Name)
                user.SetName(userInsertDTO.Name);

            if (user.Email != userInsertDTO.Email)
                user.SetEmail(userInsertDTO.Email);
            
            if (user.Password != userInsertDTO.Password)
                user.SetPassword(userInsertDTO.Password);

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
