namespace ParentsAbroad.Models.Models
{
    public class LikeToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ChildLikeToDo> ChildLikeToDoThings { get; set; }
    }
}
