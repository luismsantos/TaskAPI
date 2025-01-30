﻿using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
