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
        IEnumerable<PowerDTO> GetPowers(Expression<Func<Power, bool>> filter = null);
        PowerDTO GetPowerById(int id);
        bool PowerExists(int id);
        void UpdatePower(PowerDTO powerDto);
        PowerDTO AddPower(PowerDTO powerDto);
        PowerDTO DeleteHero(int id);
    }
}
