using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("UserFollows")]
    public class UserFollow
    {
        public Guid FollowerUserID { get; set; }
        public User FollowerUser { get; set; }

        public Guid FollowingUserID { get; set; }
        public User FollowingUser { get; set; }

        public override string ToString(){
            return $"UserFollow(FollowerUserID:{FollowerUserID}, FollowingUserID:{FollowingUserID})";
		}
    }
}
