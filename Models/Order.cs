using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoexam.Models
{
    [Table("orders")]
    public class Order
    {
        [Key, Column("order_id")]
        public int OrderId { get; set; }
        [Column("order_article")]
        public string OrderArticle { get; set; } = string.Empty;
        [Column("order_date")]
        public DateOnly OrderDate { get; set; }
        [Column("delivery_date")]
        public DateOnly DeliveryDate { get; set; }
        [Column("pickup_point_id")]
        public int? PickupPointId { get; set; }
        [Column("client_full_name")]
        public string ClientFullName { get; set; } = string.Empty;
        [Column("pickup_code")]
        public int PickupCode { get; set; }
        [Column("status")]
        public string Status { get; set; } = "Новый";
    }
}
