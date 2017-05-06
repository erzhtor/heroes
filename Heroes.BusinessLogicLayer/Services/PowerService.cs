using Heroes.BusinessLogicLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Data.Models;
using Heroes.DataAccessLayer.Models;
using System.Linq.Expressions;
using AutoMapper;
using Heroes.DataAccessLayer.UnitOfWork;
using Heroes.DataAccessLayer.GenericRepository;
using AutoMapper.QueryableExtensions;

namespace Heroes.BusinessLogicLayer.Services
{
    public class PowerService : BaseService, IPowerService
    {
        private readonly IGenericRepository<Power> powerRepository;

        public PowerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            powerRepository = this.unitOfWork.GetRepository<Power>();
        }

        public PowerDTO Add(PowerDTO powerDto)
        {
            var power = Mapper.Map<Power>(powerDto);
            powerRepository.Insert(power);
            unitOfWork.Save();
            return Mapper.Map<PowerDTO>(power);
        }

        public PowerDTO Delete(int id)
        {
            var power = powerRepository.GetById(id);
            var powerDto = Mapper.Map<PowerDTO>(power);
            powerRepository.Delete(power);
            unitOfWork.Save();
            return powerDto;
        }

        public IEnumerable<PowerDTO> GetAll(Expression<Func<Power, bool>> filter = null)
        {
            return powerRepository.Get(filter).ProjectTo<PowerDTO>();
        }

        public PowerDTO GetById(int id)
        {
            var power = powerRepository.GetById(id);
            return Mapper.Map<PowerDTO>(power);
        }

        public bool PowerExists(int id)
        {
            var power = powerRepository.GetById(id);
            return power != null;
        }

        public void Update(PowerDTO powerDto)
        {
            var power = powerRepository.GetById(powerDto.ID);
            Mapper.Map(powerDto, power);
            unitOfWork.Save();
        }
    }
}
