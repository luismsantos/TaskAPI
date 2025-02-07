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
            
            if (String.IsNullOrEmpty(name)) 
                throw new ArgumentException("O campo nome não pode ser vazio");
            
            if (name.Length > 100)
                throw new ArgumentException("O nome deve conter mais que 100 caracteres");
        }

        public void SetEmail(String email)
        {
            Email = email;
            
            if (String.IsNullOrEmpty(email))
                throw new ArgumentException("O campo email não pode ser vazio");
            
            if (email.Length < 5)
                throw new ArgumentException("O email deve conter mais que 5 caracteres");
        }

        public void SetPassword(String password)
        {
            Password = password;
            
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("O campo senha não pode ser vazio");
            
            if (password.Length < 6)
                throw new ArgumentException("O senha deve conter mais que 6 caracteres");
        }

        public User(String name, String email, String password)
        {
            SetName(name);
            SetEmail(email);
            SetPassword(password);
        }
    }
}
