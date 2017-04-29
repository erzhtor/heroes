using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Data.Models
{
    public class HeroDTO : BaseDTO
    {
        public string NickName { get; set; }

        public int CountryID { get; set; }

        public bool IsMale { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<int> PowerIDs { get; set; }
    }
}
