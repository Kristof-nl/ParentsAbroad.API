namespace ParentsAbroad.Models.Models
{
    public class ParentHobby
    {
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int HobbyId { get; set; }
        public Hobby Hobby { get; set; }
    }
}
