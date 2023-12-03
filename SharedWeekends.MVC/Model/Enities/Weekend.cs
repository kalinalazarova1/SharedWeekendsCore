using System.ComponentModel.DataAnnotations;

namespace SharedWeekends.MVC.Model.Enities
{
    public class Weekend
    {
        public int Id { get; set; }

        [Required]
        public required string AuthorId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }

        public int CategoryId { get; set; }

        public decimal Lattitude { get; set; }

        public decimal Longitude { get; set; }

        public string? PictureUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User? Author { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
