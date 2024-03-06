namespace ParentsAbroad.Models.Models
{
    public class ChildLikeToDo
    {
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int LikeToDoId { get; set; }
        public LikeToDo LikeToDo { get; set; }
    }
}
