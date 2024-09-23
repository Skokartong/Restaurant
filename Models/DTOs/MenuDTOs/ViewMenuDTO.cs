﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs.MenuDTOs
{
    public class ViewMenuDTO
    {
        public string NameOfDish { get; set; }
        public string Drink { get; set; }
        public string? Ingredients { get; set; }
        public bool IsAvailable { get; set; }
        public double Price { get; set; }
    }
}
