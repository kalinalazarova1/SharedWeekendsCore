namespace SharedWeekends.MVC.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    
    public class UserViewModel
    {
        public required string Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        [UIHint("Username")]
        public required string UserName { get; set; }

        [UIHint("Points")]
        public int Rating { get; set; }

        [UIHint("Avatar")]
        public byte[]? Avatar { get; set; }
    }
}