using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SharedWeekends.MVC.Model.Enities
{
    public class User : IdentityUser
    {
        [Required]
        public int Rating { get; set; }

        public string? Avatar { get; set; }

        public byte[]? AvatarPhoto { get; set; }

        public virtual ICollection<Weekend> Weekends { get; set; } = new HashSet<Weekend>();

        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();

        public async Task<IdentityResult> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateAsync(this);
            return userIdentity;
        }
    }
}
