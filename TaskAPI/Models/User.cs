using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class User
    {
        [Key] 
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public List<Task> Tasks { get; set; }

        public void SetName(String name)
        {
            Name = name;
        }

        public void SetEmail(String email)
        {
            Email = email;
        }

        public void SetPassword(String password)
        {
            Password = password;
        }

        public User(String name, String email, String password)
        {
            SetName(name);
            SetEmail(email);
            SetPassword(password);
        }
    }
}
