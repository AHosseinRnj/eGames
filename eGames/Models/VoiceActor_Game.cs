namespace eGames.Models
{
    public class VoiceActor_Game
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int VoiceActorId { get; set; }
        public VoiceActor VoiceActor { get; set; }
    }
}