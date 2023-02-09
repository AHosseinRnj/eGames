using eGames.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Platform : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Website")]
        public string URL { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        // Relationships
        public List<Game> Games { get; set; }
    }
}