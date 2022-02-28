using System.Collections.Generic;

namespace Mock_twitter.Entities
{
    public class Publisher : User
    {
        public ICollection<Post> Posts { get; set; }
        public ICollection<Friendship> MainFriendships { get; set; }
        public ICollection<Friendship> Friendships { get; set; }
    }
}