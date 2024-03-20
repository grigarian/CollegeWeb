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
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        [ValidateNever]
        public string Teacher { get; set; }
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        public string Group { get; set; }
        [Required]
        [DisplayName("День недели")]
        public string DayOfWeek { get; set; }

    }
}
