using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.ViewModels
{
    public class QuestionCategory
    {
        public string Category { get; set; } = default!;
        public string? CategoryDescription { get; set; }
    }
}
