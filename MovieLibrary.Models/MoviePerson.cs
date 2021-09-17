namespace MovieLibrary.Models
{
    public class MoviePerson
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int PersonId { get; set; }
        public EngagementType EngagementType { get; set; }
        public string CharacterName { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Person Person { get; set; }
    }
}