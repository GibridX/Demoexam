using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demoexam.Models
{
    [Table("production")]
    public class Product
    {
        [Key, Column("article")]
        public string Article { get; set; } = string.Empty;

        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("unit")]
        public string Unit { get; set; } = string.Empty;
        [Column("price")]
        public decimal Price { get; set; }
        [Column("supplier")]
        public string Supplier { get; set; } = string.Empty;
        [Column("manufacturer")]
        public string Manifacturer { get; set; } = string.Empty;
        [Column("category")]
        public string Category { get; set; } = string.Empty;
        [Column("discount")]
        public int Discount { get; set; }
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }
        [Column("description")]
        public string Description { get; set; } = string.Empty;
        [Column("photo")]
        public string? Photo { get; set; } = "picture.png";
    }
}
