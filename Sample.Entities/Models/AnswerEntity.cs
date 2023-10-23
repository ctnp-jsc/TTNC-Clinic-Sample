using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Entities.Models
{
    public class AnswerEntity : IdEntity, IAuditEntity, ISoftDelete
    {
        public string? Answer { get; set; }
        public bool ExtraAnswer { get; set; }
        public int Order { get; set; }
        public string QuestionId { get; set; } = default!;
        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public string? ExtraAnswerText { get; set; }
        public QuestionEntity Question { get; set;} = default!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
