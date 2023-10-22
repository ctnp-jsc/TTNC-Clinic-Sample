using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public interface IResponseDetailRepository : ICrudEntityRepository<ResponseDetailEntity>, IQueryRepository<ResponseDetailEntity>
    {
        public Task<List<ResponseDetailEntity>> GetResponsesDetailByFormId(string FormId, CancellationToken ct = default);
    }
}
