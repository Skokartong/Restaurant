﻿using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models.DTOs.AccountDTOs
{
    public class LogIn
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}