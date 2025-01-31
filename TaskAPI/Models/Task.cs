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
            Title = title;
        }

        public void SetDescription(String description)
        {
            Description = description;
        }

        public Task(String title, String description)
        {
            SetTitle(title);
            SetDescription(description);
        }

        public void ValidationTask(String title, String description)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("O titulo e/ou descrição não podem ser nulos ou vazios");
            }

            if (title.Length < 5 || description.Length < 5)
            {
                throw new ArgumentException("O titulo e/ou descrição devem ter no mínimo 5 caracteres");
            }

            if (title.Length > 30 || description.Length > 100)
            {
                throw new ArgumentException("O titulo deve ter no máximo 30 caracteres e a descrição deve ter no máximo 100 caracteres");
            }

            SetTitle(title);
            SetDescription(description);
        }
    }
}
