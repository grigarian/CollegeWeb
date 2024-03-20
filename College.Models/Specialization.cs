using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Специальность")]
        public string Name { get; set; }
    }
}
