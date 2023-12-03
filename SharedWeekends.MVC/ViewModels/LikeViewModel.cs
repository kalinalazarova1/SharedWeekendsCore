namespace SharedWeekends.MVC.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LikeViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("Stars")]
        public int Stars { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string? Comment { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public int WeekendId { get; set; }

        [Display(Name = "Weekend Title")]
        [StringLength(50, MinimumLength = 3)]
        public string? WeekendTitle { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string? Voter { get; set; }
    }
}