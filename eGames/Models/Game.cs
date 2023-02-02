using eGames.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GameCategory Category { get; set; }
    }
}