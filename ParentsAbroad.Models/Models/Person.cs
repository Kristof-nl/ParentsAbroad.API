using ParentsAbroad.Models.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ParentsAbroad.Models.Models
{
    public class Person : IEntity
    {
       [Key]
       public int Id { get; set; }
       [Required]
       public string Name { get; set; }
       [Required]
       public DateTime DateOfBirth { get; set; }
       public int FamilyId { get; set; }
       public virtual Family Family { get; set; }
       public virtual IList<Language> Languages { get; set; }

    }
}
