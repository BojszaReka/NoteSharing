using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace class_library.Models
{
    [Table("UserFollows")]
    public class UserFollow
    {
        public Guid FollowerUserID { get; set; }
        [ForeignKey("FollowerUserID")]
		public User FollowerUser { get; set; }

        public Guid FollowedUserID { get; set; }
        [ForeignKey("FollowedUserID")]
		public User FollowedUser { get; set; }

        public override string ToString(){
            return $"UserFollow(FollowerUserID:{FollowerUserID}, FollowingUserID:{FollowedUserID})";
		}
    }
}
