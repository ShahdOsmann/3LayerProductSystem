using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.BLL.ViewModels.Utilities
{
    public class EmailVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
