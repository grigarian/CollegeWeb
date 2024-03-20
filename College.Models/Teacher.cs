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
        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }
    }
}
