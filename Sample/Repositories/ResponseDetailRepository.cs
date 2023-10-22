using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public sealed class ResponseDetailRepository : BaseCrudEntityRepository<ResponseDetailEntity>, IResponseDetailRepository
    {
        private readonly DbContext _context;
        public ResponseDetailRepository(IServiceProvider serviceProvider, ILogger<FormRepository> logger) : base(serviceProvider, logger)
        {
            _context = serviceProvider.GetRequiredService<EntityDbContext>();
        }

        public async Task<List<ResponseDetailEntity>> GetResponsesDetailByFormId(string FormId, CancellationToken ct = default)
        {
            return await GetQueryable().Where(e=>e.Form.Id == FormId).ToListAsync();
        }
    }
}
