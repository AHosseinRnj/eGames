using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Biography { get; set; }

        // Relationships
        public List<Developer_Game> Developers_Games { get; set; }
    }
}