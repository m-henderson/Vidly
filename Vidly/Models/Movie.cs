﻿namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genres { get; set; }
        public byte GenreId { get; set; }
    }
}