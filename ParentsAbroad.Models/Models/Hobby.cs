namespace ParentsAbroad.Models.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ParentHobby> ParentHobbys { get; set; }
    }
}
