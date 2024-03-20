using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Длина текста не должна превышать 30-и символов")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Длина текста не должна превышать 30-и символов")]
        [DisplayName("Фамилия")]
        public string Surname { get; set; }
        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }
        [DisplayName("Курс")]
        public int Course { get; set; }
        [DisplayName("Специальность")]
        public string GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        public string Group { get; set; }
    }
}
