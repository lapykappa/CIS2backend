using DbFirstCIS2.DATA;
using DbFirstCIS2.Interfaces;
using DbFirstCIS2.Models;
using DbFirstCIS2.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DbFirstCIS2.Repository
{
    public class tblComputerRepository : ITblComputerRepository
    {
        private readonly ContinousIntegrationScriptDbContext _context;
        public tblComputerRepository(ContinousIntegrationScriptDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComputerDto>> GetAllAsync()
        {
            return await _context.TblComputers
                .Include(c => c.TblComputerType)
                .Include(c => c.TblComputerFunctionality)
                .Select(c => new ComputerDto
                {
                    Id = c.TblComputerId,
                    ComputerName = c.ComputerName,
                    TypeDescription = c.TblComputerType.ComputerTypeDescription, // replaced TypeId
                    FunctionalityDescription = c.TblComputerFunctionality.FunctionalityDescription, // replaced FunctionalityId
                    SerialNr = c.SerialNr,
                    Inventory = c.Inventory,
                    Comment = c.Comment
                })
                .ToListAsync();
        }

        public async Task<ComputerDto> GetAsync(int id)
        {
            var computer = await _context.TblComputers
                .Include(c => c.TblComputerType)
                .Include(c => c.TblComputerFunctionality)
                .FirstOrDefaultAsync(c => c.TblComputerId == id);
            if (computer == null)
                return null;

            return new ComputerDto
            {
                Id = computer.TblComputerId,
                ComputerName = computer.ComputerName,
                 Comment = computer.Comment
            };
        }

        public async Task<ComputerDto> CreateAsync(ComputerDto computerDto)
        {
            var computer = new TblComputer
            {
                ComputerName = computerDto.ComputerName,
                TblComputerTypeId = _context.TblComputerTypes.FirstOrDefault(t => t.ComputerTypeDescription == computerDto.TypeDescription).TblComputerTypeId,
                TblComputerFunctionalityId = _context.TblComputerFunctionalities.FirstOrDefault(f => f.FunctionalityDescription == computerDto.FunctionalityDescription).TblComputerFuncionalityId,
                SerialNr = computerDto.SerialNr,
                Inventory = computerDto.Inventory,
                Comment = computerDto.Comment
            };

            _context.TblComputers.Add(computer);
            await _context.SaveChangesAsync();

            computerDto.Id = computer.TblComputerId;
            return computerDto;
        }

        public async Task UpdateAsync(ComputerDto computerDto)
        {
            var computer = await _context.TblComputers.FindAsync(computerDto.Id);
            if (computer != null)
            {
                computer.ComputerName = computerDto.ComputerName;
                computer.TblComputerTypeId = _context.TblComputerTypes.FirstOrDefault(t => t.ComputerTypeDescription == computerDto.TypeDescription).TblComputerTypeId;
                computer.TblComputerFunctionalityId = _context.TblComputerFunctionalities.FirstOrDefault(f => f.FunctionalityDescription == computerDto.FunctionalityDescription).TblComputerFuncionalityId;
                computer.SerialNr = computerDto.SerialNr;
                computer.Inventory = computerDto.Inventory;
                computer.Comment = computerDto.Comment;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var computer = await _context.TblComputers.FindAsync(id);
            if (computer != null)
            {
                _context.TblComputers.Remove(computer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
