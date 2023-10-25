using DbFirstCIS2.Models;
using DbFirstCIS2.DTO;
namespace DbFirstCIS2.Interfaces
{
    public interface ITblComputerRepository
    {
        Task<IEnumerable<ComputerDto>> GetAllAsync();
        Task<ComputerDto> GetAsync(int id);
        Task<ComputerDto> CreateAsync(ComputerDto computerDto);
        Task UpdateAsync(ComputerDto computerDto);
        Task DeleteAsync(int id);
    }

}