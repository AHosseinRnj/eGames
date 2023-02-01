﻿using System.ComponentModel.DataAnnotations;

namespace eGames.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}