using eGames.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Relationships
        public List<VoiceActor_Game> VoiceActors_Games { get; set; }
        public List<Developer_Game> Developers_Games { get; set; }

        // Platform
        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public Platform Platform { get; set; }

        // Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}