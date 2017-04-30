using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Data.Models
{
    public class BaseDTO
    {
        public int ID { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
