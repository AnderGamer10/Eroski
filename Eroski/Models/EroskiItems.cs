using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eroski.Models
{
    public class EroskiItems
    {
        [Key]
        public string Seccion { get; set; }
        public int numeroTicket { get; set; }
    }
}
