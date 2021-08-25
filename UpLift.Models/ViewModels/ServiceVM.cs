using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpLift.Models.ViewModels
{
    public class ServiceVM
    {
        public Service Service { get; set; }
        public IEnumerable<SelectListItem> FrequencyList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
