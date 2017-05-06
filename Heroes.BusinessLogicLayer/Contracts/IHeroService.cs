using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Data.Models;

namespace Heroes.BusinessLogicLayer.Contracts
{
    public interface IHeroService
    {
        IEnumerable<HeroDTO> GetAll();
        HeroDTO GetById(int id);
        bool HeroExists(int id);
        void Update(HeroDTO heroDto);
        HeroDTO Add(HeroDTO heroDto);
        HeroDTO Delete(int id);
    }
}
