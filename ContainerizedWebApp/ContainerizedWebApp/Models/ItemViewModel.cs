using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContainerizedWebApp.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(50, MinimumLength = 3)] // DataAnnotations, driving client- and server-side validation
        //[DataType(DataType.EmailAddress)]
        public string Name { get; set; }
    }
}
