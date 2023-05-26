using System;

namespace MovieFan.Data
{
    public class Movie
    {
        public int Id { get; set; } 
        public string MovieName { get; set; }    
        public double MovieIMDB { get; set; }   
        public DateTime ReleaseDate { get; set; }   
        public string MovieDuration { get; set; } 
        public string MovieDirector { get; set; }   
        public string MovieActors { get; set; } 
        public string MovieDescription { get; set; }    
    }
}
