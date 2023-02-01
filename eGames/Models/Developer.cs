﻿using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
    }
}