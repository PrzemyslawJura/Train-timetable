using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DOT_NET_APP.Models
{
    public class bok
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public int Book_Id { get; set; }
    }
}
