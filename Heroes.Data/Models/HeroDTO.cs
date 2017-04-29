using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Data.Models
{
    public class HeroDTO : BaseDTO
    {
        [Required]
        public string NickName { get; set; }

        [Required]
        public int CountryID { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public List<int> PowerIDs { get; set; }
    }
}
