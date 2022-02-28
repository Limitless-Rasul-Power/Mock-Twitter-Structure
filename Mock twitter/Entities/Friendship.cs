using System.ComponentModel.DataAnnotations.Schema;

namespace Mock_twitter.Entities
{
    public class Friendship
    {        
        public int TargetUserId { get; set; }        
        public Publisher TargetUser { get; set; }

        public int FriendUserId { get; set; }        
        public Publisher FriendUser { get; set; }
    }
}