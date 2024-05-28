using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College.Models.ViewModels
{
    public class GroupVM
    {
        public Group Group { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SpecializationList { get; set; }
    }
}
