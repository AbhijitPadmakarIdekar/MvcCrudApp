using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string? Role { get; set; } = string.Empty;
        public DateTime? LastLogin { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string? LName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Department { get; set; } = string.Empty;
        public DateTime? DOJ { get; set; }
        public int? MgrId { get; set; }
        public decimal? Seniority { get; set; }

        [Required]
        [MaxLength(10)]
        public string? EmpCode { get; set; } = string.Empty;
    }
}
