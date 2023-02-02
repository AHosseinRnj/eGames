namespace eGames.Models
{
    public class Developer_Game
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }
    }
}