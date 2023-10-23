using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public sealed class ResponseRepository : BaseCrudEntityRepository<ResponseEntity>, IResponseRepository
    {
        private readonly EntityDbContext _context;
        public ResponseRepository(IServiceProvider serviceProvider, ILogger<FormRepository> logger) : base(serviceProvider, logger)
        {
            _context = serviceProvider.GetRequiredService<EntityDbContext>();
        }

        public async Task<ResponseEntity> AddResponseAsync(ResponseEntity model, CancellationToken ct = default)
        {
            await _context.AddAsync(model, ct);
            await _context.SaveChangesAsync(ct);
            return model;
        }

        public async Task<ResponseEntity?> FindByFormId(string formId, CancellationToken ct = default)
        {
            return await _context.Responses.Where(e=>e.Form.Id == formId).Include(e=>e.ResponseDetail).OrderByDescending(e=>e.Version).FirstOrDefaultAsync(ct);
        }
    }
}
