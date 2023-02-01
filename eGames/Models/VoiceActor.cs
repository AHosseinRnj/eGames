using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class VoiceActor
    {
        [Key] 
        public int ActorId { get; set; }

        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
    }
}