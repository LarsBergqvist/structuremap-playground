namespace StructureMapTest
{
    public class Post
    {
        public Post(int id, int userId, string body, string title)
        {
            Id = id;
            UserId = userId;
            Body = body;
            Title = title;
        }
        private int Id { get; }
        private int UserId { get; }
        private string Body { get; }
        private string Title { get; }
        public override string ToString()
        {
            return $"{Id}, {UserId}, {Body}, {Title}";
        }
    }
}
