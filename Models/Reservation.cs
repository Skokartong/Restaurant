﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumberOfGuests { get; set; }
        [Required]
        public DateTime BookingStart { get; set; }
        [Required]
        public DateTime BookingEnd { get; set; }
        public string? Message { get; set; }

        [ForeignKey("Customer")]
        public int FK_CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public virtual Table? Table { get; set; }
        [ForeignKey("Restaurant")]
        public int FK_RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
