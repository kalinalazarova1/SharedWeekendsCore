using System.ComponentModel.DataAnnotations;

namespace SharedWeekends.MVC.ViewModels
{
    public class TopUserViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        public int Rating { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string AvatarUrl { get; set; }
    }
}