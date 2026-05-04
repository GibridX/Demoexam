using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demoexam.Models
{
    [Table("users")]
    public class User
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("role")]
        public string Role { get; set; } = string.Empty;
        [Column("full_name")]
        public string Fullname { get; set; } = string.Empty;
        [Column("login")]
        public string Login { get; set; } = string.Empty;
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        public bool IsAdmin => Role == "Администратор";
        [NotMapped]
        public bool CanSearch => Role == "Администратор" || Role == "Менеджер";
    }
}
