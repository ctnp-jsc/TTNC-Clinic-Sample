using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sample.Entities;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public sealed class ResponseRepository : BaseCrudEntityRepository<ResponseEntity>, IResponseRepository
    {
        private readonly DbContext _context;
        public ResponseRepository(IServiceProvider serviceProvider, ILogger<FormRepository> logger) : base(serviceProvider, logger)
        {
            _context = serviceProvider.GetRequiredService<EntityDbContext>();
        }

    }
}
