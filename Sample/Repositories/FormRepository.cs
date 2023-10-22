using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public sealed class FormRepository : BaseCrudEntityRepository<FormEntity>, IFormRepository
    {
        private readonly EntityDbContext _context;
        public FormRepository(IServiceProvider serviceProvider, ILogger<FormRepository> logger) : base(serviceProvider, logger)
        {
            _context = serviceProvider.GetRequiredService<EntityDbContext>();
        }

        public async Task<FormEntity> AddFormAsync(FormEntity model, CancellationToken ct = default)
        {
            await _context.AddAsync(model, ct);
            await _context.SaveChangesAsync(ct);
            return model;
        }
        public async Task<FormEntity?> GetFromDetail(string formId, CancellationToken ct = default)
        {
            return await _context.Forms.Include(e=>e.Questions).ThenInclude(ch=>ch.Answers).Where(e => e.Id == formId).FirstOrDefaultAsync(ct);
        }
        public async Task<List<FormEntity>?> GetListFrom(CancellationToken ct = default)
        {
            return await _context.Forms.Include(e=>e.Questions).ToListAsync(ct);
        }
    }
}
