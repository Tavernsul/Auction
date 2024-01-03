using System;
using System.ComponentModel.DataAnnotations;

namespace Auction.Entities
{
    public class Car
    {
        [Key]
        [Required]
        public int Id { get; set; } // Unique identifier for the car
        [Required]
        [StringLength(17)]
        [RegularExpression(@"^[A-HJ-NPR-Z0-9]{17}$")]
        public string VIN { get; set; } // VIN number as identifier
        public string Make { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    }
}
