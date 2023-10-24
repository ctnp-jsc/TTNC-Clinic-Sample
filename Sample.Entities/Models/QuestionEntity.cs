using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Entities.Models
{

    public enum QuestionType
    {
        Info,
        Multiple,
        Single,
        Open,
        MultipleOpen,
        SingleOpen
    }
    public enum QuestionDataType
    {
        Text,
        Date,
        Boolean
    }
    public class QuestionEntity : IdEntity, IAuditEntity, ISoftDelete
    {
        public string QuestionText { get; set; } = default!;
        public string? QuestionCategory { get; set; }
        public string? QuestionCategoryDescription { get; set; }
        public string? FormId { get; set; }
        public int Order { get; set; }
        public bool IsMandatory { get; set; } = false;
        public QuestionType QuestionType { get; set; } = default!;
        public FormEntity? Form { get; set; }
        public QuestionDataType QuestionDataType { get; set; } = QuestionDataType.Text;
        public ICollection<AnswerEntity> Answers { get; set; } = default!;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
