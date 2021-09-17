using System;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public string CoverUrl { get; set; }
    }
}