using Heroes.BusinessLogicLayer.Models;
using Heroes.Data.Models;
using System.Collections.Generic;

namespace Heroes.BusinessLogicLayer.Contracts
{
    public interface IHeroService
    {
        IEnumerable<HeroDTO> GetHeroes(HeroFiler filter);
        HeroDTO GetHeroById(int id);
        bool HeroExists(int id);
        void UpdateHero(HeroDTO heroDto);
        HeroDTO AddHero(HeroDTO heroDto);
        HeroDTO DeleteHero(int id);
    }
}
