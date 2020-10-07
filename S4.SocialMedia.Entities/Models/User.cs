using System;
using System.Collections.Generic;

namespace S4.SocialMedia.Entities.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            Post = new HashSet<Post>();
        }

        public string PkUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Google { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
