using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public interface IResponseRepository : ICrudEntityRepository<ResponseEntity>, IQueryRepository<ResponseEntity>
    {
        public Task<ResponseEntity> AddResponseAsync(ResponseEntity model, CancellationToken ct = default);
        public Task<ResponseEntity> FindByFormId(string formId, CancellationToken ct = default);
    }
}
