using System.ComponentModel.DataAnnotations;

namespace SharedWeekends.MVC.Model.Enities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Weekend> Weekends { get; set; } = new HashSet<Weekend>();
    }
}
