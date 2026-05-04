using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoexam.Models
{
    [Table("pickup_point")]
    public class PickupPoint
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("address")]
        public string Address { get; set; } = string.Empty;
    }
}
