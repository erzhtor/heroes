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
        IEnumerable<HeroDTO> GetHeroes();
        HeroDTO GetHeroById(int id);
        bool HeroExists(int id);
        void UpdateHero(HeroDTO heroDto);
        HeroDTO AddHero(HeroDTO heroDto);
        HeroDTO DeleteHero(int id);
    }
}
