using System.ComponentModel.DataAnnotations;

namespace CRUD_API_Repo.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
    }
}
