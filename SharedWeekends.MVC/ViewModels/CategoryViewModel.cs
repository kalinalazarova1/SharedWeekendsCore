namespace SharedWeekends.MVC.ViewModels
{
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    
    public class CategoryViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Category")]
        [Required]
        public required string Name { get; set; }
    }
}