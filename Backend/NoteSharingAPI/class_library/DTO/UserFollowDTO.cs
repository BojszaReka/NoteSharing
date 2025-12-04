using System;

namespace class_library.DTO
{
    public class UserFollowDTO
    {
        public Guid FollowerUserID { get; set; }
        public Guid FollowedUserID { get; set; }
    }
}
