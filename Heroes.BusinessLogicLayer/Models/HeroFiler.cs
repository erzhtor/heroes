using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.BusinessLogicLayer.Models
{
    public class HeroFiler
    {
        public string NickName { get; set; }

        public int[] CountryID { get; set; } = new int[0];

        public int[] PowerID { get; set; } = new int[0];

        public bool? IsMale { get; set; }
    }
}
