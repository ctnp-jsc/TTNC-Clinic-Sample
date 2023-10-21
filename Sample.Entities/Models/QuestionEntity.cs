using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Entities.Models
{
    public enum QuestionType {
        Info,
        Multiple,
        Single,
        Open,
        MultipleOpen,
        SingleOpen
    }
    public class QuestionEntity : IdEntity, IAuditEntity, ISoftDelete
    {
        public string QuestionText { get; set; } = default!;
        public QuestionType QuestionType { get; set; } = default!;
        public FormEntity Form { get; set; } = default!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
