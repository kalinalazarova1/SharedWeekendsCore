namespace SharedWeekends.MVC.Model.Enities
{
    public class Like
    {
        public int Id { get; set; }

        public int Stars { get; set; }

        public string? Comment { get; set; }

        public required string VoterId { get; set; }

        public int WeekendId { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual Weekend? Weekend { get; set; }

        public virtual User? Voter { get; set; }
    }
}
