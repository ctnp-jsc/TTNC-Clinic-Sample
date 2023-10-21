using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public interface IFormRepository : ICrudEntityRepository<FormEntity>, IQueryRepository<FormEntity>
    {
        public Task<FormEntity> AddFormAsync(FormEntity model, CancellationToken ct = default);
    }
}
