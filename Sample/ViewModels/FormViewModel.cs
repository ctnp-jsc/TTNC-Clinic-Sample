using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.Entities.Models;

namespace Sample.ViewModels
{
    public enum FormStatus
    {
        FillOut,
        Submitted,
        SubmittedDraft
    }
    public class FormViewModel : IdEntity, IAuditEntity
    {
        public string Title { get; set; } = default!;
        public List<QuestionEntity> Questions = default!;
        public DateTimeOffset LastEdited { get; set; }
        public FormStatus FormStatus { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
