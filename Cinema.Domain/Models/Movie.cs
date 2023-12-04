using System.ComponentModel.DataAnnotations.Schema;
using Cinema.Domain.Interfaces;

namespace Cinema.Domain.Models
{
    [Flags]
    public enum MovieGenre
    {
        None = 0,
        Action = 1,
        Fantasy = 2,
        Thriller = 4,
        Horror = 8,
        Comedy = 16
    }

    public class Movie : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateOnly PublishDate { get; private set; }
        public MovieGenre Genre { get; private set; }
        [NotMapped] public ICollection<string> Actors { get; private set; }
        public string Description { get; private set; }

        // public Movie(string name, MovieGenre genre, DateOnly publishDate, string description, ICollection<string> actors)
        // {
        // 	Name = name;
        // 	PublishDate = publishDate;
        // 	Genre = genre;
        // 	Description = description;
        // 	Actors = actors;
        // }

        public Movie(int id, string name, MovieGenre genre, DateOnly publishDate, string description, ICollection<string> actors)
        : this(id, name, genre, publishDate, description)
        {
            Actors = actors;
        }

        /// <summary>
        /// EF constructor
        /// </summary>
        private Movie(int id, string name, MovieGenre genre, DateOnly publishDate, string description)
        {
            Id = id;
            Name = name;
            PublishDate = publishDate;
            Genre = genre;
            Description = description;
        }
    }
}

