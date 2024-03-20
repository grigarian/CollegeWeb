using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Группа")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Курс")]
        public int Course { get; set; }
        public string SpecializationId { get; set; }
        [ForeignKey("SpecializationId")]
        [ValidateNever]
        public string Specialization { get; set; }

    }
}
