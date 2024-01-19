using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Entities
{
    public class SearchParameter
    {
        [Key]
        public int SearchParameterId { get; set; }

        [Required(ErrorMessage = "Username is mandatory")]
        public string? Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fieldname is mandatory")]
        public string? Fieldname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Datatype is mandatory")]
        public string? Datatype { get; set; } = string.Empty;

        [Required(ErrorMessage = "ControlType is mandatory")]
        public string? ControlType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Constraint is mandatory")]
        public string? Constraint { get; set; } = string.Empty;

        public int? MaxLength { get; set; }

        public int? MinLimit { get; set; }

        public int? MaxLimit { get; set; }

        public string? MaskPattern { get; set; } = string.Empty;

        // New property to store JSON data
        public string? JsonData { get; set; } = string.Empty;
    }
}
