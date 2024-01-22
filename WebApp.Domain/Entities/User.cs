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

        [Required(ErrorMessage = "UserName is required")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "UserName must contain only digits & letters.")]
        [MaxLength(50)]
        public string? UserName { get; set; } = string.Empty;

        [RegularExpression("^[a-zA-Z0-9]+$",
            ErrorMessage = "UserName must contain only digits & letters.")]
        [Required(ErrorMessage = "Password is required!")]
        [Column(TypeName = "VARCHAR(20)")]
        [StringLength(20, MinimumLength = 10,
            ErrorMessage = "Password must be in range 10 to 20 letters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string? Role { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? LastLogin { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string? LName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Department { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOJ { get; set; }

        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "MgrId must be a 1 to 3 digit number")]
        [Range(1, 999, ErrorMessage = "MgrId must be between 1 and 999")]
        public int? MgrId { get; set; }

        [Range(0, 9.99, ErrorMessage = "Seniority must be between 0 and 9.99")]
        public decimal? Seniority { get; set; }

        [Required(ErrorMessage = "EmpCode is required")]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]{3}\d{4}$", ErrorMessage = "EmpCode must be in the format XXX9999")]
        public string? EmpCode { get; set; } = string.Empty;
    }
}
