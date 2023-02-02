using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class VoiceActor
    {
        [Key] 
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }

        // Relationships
        public List<VoiceActor_Game> VoiceActors_Games { get; set; }
    }
}