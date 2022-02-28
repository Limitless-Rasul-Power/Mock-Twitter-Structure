using System.Collections.Generic;

namespace Mock_twitter.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}