using System;
using System.ComponentModel.DataAnnotations;

namespace MovieFan.Model
{
    public class MovieDTO
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public double MovieIMDB { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string MovieDuration { get; set; }
        [Required]
        public string MovieDirector { get; set; }
        [Required]
        public string MovieActors { get; set; }
        [Required]
        public string MovieDescription { get; set; }
    }
}
