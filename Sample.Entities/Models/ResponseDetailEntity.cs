using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Entities.Models
{
    public class ResponseDetailEntity : IdEntity, IAuditEntity, ISoftDelete
    {
        public ResponseEntity Response { get; set; } = default!;
        public AnswerEntity? Answer { get; set; }
        public string ResponseId { get; set; }  = default!;
        public string? ExtraAnswer { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
