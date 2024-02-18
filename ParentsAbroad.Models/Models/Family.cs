using System.ComponentModel.DataAnnotations;

namespace ParentsAbroad.Models.Models
{
    public class Family
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Child> Children { get; set; }
        public IList<Parent> Parents { get; set; }
    }
}
