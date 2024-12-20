using AutoMapper;
using Freshx_API.Dtos;
using Freshx_API.Interfaces;
using Freshx_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly FreshxDBContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<PositionRepository> _logger;
        public PositionRepository(FreshxDBContext context, IMapper mapper, ILogger<PositionRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Position?> CreatePositionAsync(AddingPositionRequest addingPositionRequest)
        {
            try
            {
                var position = new Position
                {
                    Name = addingPositionRequest.Name
                };
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await _context.Positions.AddAsync(position);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        return position;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw;
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, "An exception occured while creating a position");
                throw;
            }
        }

        public async Task<Position?> GetPositionByIdAsync(int id)
        {
            try
            {
                return await _context.Positions.FindAsync(id);              
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An exception occured while getting postion by {id}");
                throw;
            }
        }

        public async Task<List<Position>> GetPositionsAsync()
        {
            try
            {
              return  await _context.Positions.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An exception occured while getting positions");
                throw;
            }
        }
    }
}
