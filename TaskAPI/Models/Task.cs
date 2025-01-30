using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; private set; }
        public String Description { get; private set; }

        public void SetTitle(String title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("O titulo não pode ser nulo ou vazio");
            }

            if (title.Length < 5)
            {
                throw new ArgumentException("O titulo deve ter no mínimo 5 caracteres");
            }

            if (title.Length > 30)
            {
                throw new ArgumentException("O titulo deve ter no máximo 30 caracteres");
            }

            Title = title;
        }

        public void SetDescription(String description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("A descrição não pode ser nula ou vazia");
            }

            if (description.Length < 5)
            {
                throw new ArgumentException("A descrição deve ter no mínimo 5 caracteres");
            }

            if (description.Length > 100)
            {
                throw new ArgumentException("A descrição deve ter no máximo 100 caracteres");
            }

            Description = description;
        }
        public Task(String title, String description)
        {
            SetTitle(title);
            SetDescription(description);
        }
    }
}
