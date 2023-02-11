using eGames.Data.Base;
using eGames.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGames.Models
{
    public class NewGameVM
    {
        public int Id { get; set; }

        [Display(Name = "Game image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Game name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Game description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Category is required")]
        public GameCategory Category { get; set; }

        // Relationships
        [Display(Name = "Select developer(s)")]
        [Required(ErrorMessage = "Game developer(s) is required")]
        public List<int> DeveloperIds { get; set; }

        [Display(Name = "Select a platform")]
        [Required(ErrorMessage = "Platform is required")]
        public int PlatformId { get; set; }

        [Display(Name = "Select a publisher")]
        [Required(ErrorMessage = "publisher is required")]
        public int PublisherId { get; set; }
    }
}