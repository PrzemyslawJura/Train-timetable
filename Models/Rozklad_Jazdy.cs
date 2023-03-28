using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DOT_NET_APP.Models
{
    public class Rozklad_Jazdy
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name_From { get; set; }

        [Required]
        public string Name_To { get; set; }

        [Required]
        public string Hours{ get; set; }

    }
}
