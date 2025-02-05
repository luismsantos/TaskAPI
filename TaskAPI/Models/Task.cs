using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; private set; }
        public String Description { get; private set; }

        public Task(String title, String description)
        {
            SetTitle(title);
            SetDescription(description);
        }

        public void SetTitle(String title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("O título não pode ser nulo ou vazio");

            if (title.Length > 100)
                throw new ArgumentException("O título não pode ser maior que 100 caracteres");

            Title = title;
        }

        public void SetDescription(String description)
        {

            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("A descrição não pode ser nulo ou vazio");

            if (description.Length > 300)
                throw new ArgumentException("A descrição não pode ser maior que 300 caracteres");

            Description = description;
        }
    }
}
