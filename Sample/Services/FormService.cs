using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;
using Sample.Repositories;
using Sample.ViewModels;

namespace Sample.Services
{
    public sealed class FormService : BaseCrudEntityService<FormEntity, IFormRepository>
    {
        public FormService(IServiceProvider serviceProvider, ILogger<FormService> logger) : base(serviceProvider, logger)
        {
        }
        public async Task<IEnumerable<FormEntity>> GetListForm(CancellationToken ct = default)
        {
            return await Repository.FindManyAsync(e => true, ct);
        }
        public async Task<FormEntity> CreateForm(FormViewModel formModel, CancellationToken ct = default)
        {
            var test = new FormEntity() { Title = formModel.Title, Id = Guid.NewGuid().ToString() };
            return await Repository.AddFormAsync(test, ct);
        }
    }
}
