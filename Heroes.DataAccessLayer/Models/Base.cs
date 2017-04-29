using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.DataAccessLayer.Models
{
    public class Base
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
