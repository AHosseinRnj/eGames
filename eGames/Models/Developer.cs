using eGames.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Developer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Biography { get; set; }

        // Relationships
        public List<Developer_Game>? Developers_Games { get; set; }
    }
}