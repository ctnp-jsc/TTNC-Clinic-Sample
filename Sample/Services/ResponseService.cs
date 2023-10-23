using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;
using Sample.Repositories;
using Sample.ViewModels;

namespace Sample.Services
{
    public sealed class ResponseService : BaseCrudEntityService<ResponseEntity, IResponseRepository>
    {
        public ResponseService(IServiceProvider serviceProvider, ILogger<ResponseService> logger) : base(serviceProvider, logger)
        {
        }
        public async Task<ResponseEntity> GetResponseByFormId(string FormId, CancellationToken ct = default)
        {
            return await Repository.FindByFormId(FormId, ct);
        }
        public async Task<ResponseEntity> CreateResponse(ResponseEntity model, CancellationToken ct = default)
        {
            var rs = await Repository.AddResponseAsync(model, ct);
            return rs;
        }
    }
}
