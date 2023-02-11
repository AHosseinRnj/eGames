using eGames.Models;

namespace eGames.Data.ViewModels
{
    public class NewGameDropdownsVM
    {
        public List<Publisher> Publishers { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Developer> Developers { get; set; }

        public NewGameDropdownsVM()
        {
            Publishers = new List<Publisher>();
            Platforms = new List<Platform>();
            Developers = new List<Developer>();
        }
    }
}
