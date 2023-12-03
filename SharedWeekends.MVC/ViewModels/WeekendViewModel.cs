namespace SharedWeekends.MVC.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    public class WeekendViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [UIHint("Picture")]
        public string? PictureUrl { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public required string Title { get; set; }

        [UIHint("Description")]
        [Required]
        [StringLength(2000, MinimumLength = 3)]
        public required string Description { get; set; }

        [Required]
        public required string Category { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string? Author { get; set; }

        [UIHint("Stars")]
        public int Rating { get; set; }

        [UIHint("Reviews")]
        public int LikesCount { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime? CreationDate { get; set; }

        public int PeopleCount { get; set; }

        [UIHint("Currency")]
        public decimal PricePerPerson { get; set; }
    }
}