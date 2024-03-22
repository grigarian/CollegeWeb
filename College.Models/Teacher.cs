using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("ФИО")]
        public string Name { get; set; }
        [DisplayName("Должность")]
        public string Post { get; set; }
        [DisplayName("Образование")]
        public string Education { get; set; }
        [DisplayName("Квалификация")]
        public string Qualification { get; set; }
        [DisplayName("Стаж работы")]
        public int WorkExperience { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
