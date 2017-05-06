using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Data.Models;
using System.Linq.Expressions;
using Heroes.DataAccessLayer.Models;

namespace Heroes.BusinessLogicLayer.Contracts
{
    public interface IPowerService
    {
        IEnumerable<PowerDTO> GetAll(Expression<Func<Power, bool>> filter = null);
        PowerDTO GetById(int id);
        bool PowerExists(int id);
        void Update(PowerDTO powerDto);
        PowerDTO Add(PowerDTO powerDto);
        PowerDTO Delete(int id);
    }
}
