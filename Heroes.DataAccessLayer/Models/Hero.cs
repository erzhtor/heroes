using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.DataAccessLayer.Models
{
    public class Hero : Base
    {
        public Hero()
        {
            Powers = new HashSet<Power>();
        }

        [Required]
        [StringLength(100)]
        public string NickName { get; set; }

        [Required]
        public int CountryID { get; set; }

        [Required]
        public bool IsMale { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Power> Powers { get; set; }
    }
}
