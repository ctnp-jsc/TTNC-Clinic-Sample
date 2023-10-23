using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.Repositories
{
    public interface IResponseDetailRepository : ICrudEntityRepository<ResponseDetailEntity>, IQueryRepository<ResponseDetailEntity>
    {
    }
}
