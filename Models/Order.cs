﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }

        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public virtual Table Table { get; set; }

        [ForeignKey("Menu")]
        public int FK_MenuId { get; set; }
        public virtual Menu Menu { get; set; }

        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

