using AutoMapper;
using Entities.Model;
using Entities.ModelDto;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EFCore
{
    public class ServiceStockChange : IServiceStockChange
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ServiceStockChange(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateStockChange(StockChangeDto stockChangeDto)
        {
            var stock = _mapper.Map<StockChange>(stockChangeDto);
            await _repository.StockChange.Create(stock);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteStockChange(int id)
        {
            var stock = _repository.StockChange.GetById(id).Result;
            if (stock != null)
            {
                await _repository.StockChange.Delete(stock);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<StockChangeDto> GetStockChangeById(int id)
        {
            var stock = await _repository.StockChange.GetById(id);
            return _mapper.Map<StockChangeDto>(stock);
        }

        public async Task<List<StockChangeDto>> GetStockChangeList()
        {
            var stocks = await _repository.StockChange.Read(false);
            return _mapper.Map<List<StockChangeDto>>(stocks);
        }

        public async Task UpdateStockChange(StockChangeDto stockChangeDto)
        {
            var stock = _mapper.Map<StockChange>(stockChangeDto);
            await _repository.StockChange.Update(stock);
            await _repository.SaveChangesAsync();
        }
    }
}
