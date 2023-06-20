using Microsoft.EntityFrameworkCore;
using System;

namespace MovieFan.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        { }

        public DataBaseContext(string connString)
        {
        }

        public DataBaseContext()
        {
        }

        DateTime thisDate1 = new DateTime(2009, 9, 9);
        DateTime thisDate2 = new DateTime(2006, 6, 6);
        DateTime thisDate3 = new DateTime(2003, 3, 3);

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(
                new Movie 
                { 
                    Id = 1,
                    MovieName = "Computer Engeenering 1",
                    MovieActors = "Behzad",
                    MovieDirector = "Google",
                    MovieIMDB = 9.9,
                    MovieDescription = "Flutter",
                    MovieDuration = "99 min",
                    ReleaseDate = thisDate1
                },
                new Movie
                {
                  Id = 2,
                  MovieName = "Computer Engeenering 2",
                  MovieActors = "Behzad",
                  MovieDirector = "Microsoft",
                  MovieIMDB = 9.6,
                  MovieDescription = "DotNet",
                  MovieDuration = "99 min",
                  ReleaseDate = thisDate2
                },
                new Movie
                {
                    Id = 3,
                    MovieName = "Computer Engeenering 3",
                    MovieActors = "Behzad",
                    MovieDirector = "Python Software Foundation",
                    MovieIMDB = 9.3,
                    MovieDescription = "Python",
                    MovieDuration = "99 min",
                    ReleaseDate = thisDate3
                }
                );

            /*modelBuilder.Entity<User>().HasKey(u => u.EmailAddress );*/
        }
    }
}
