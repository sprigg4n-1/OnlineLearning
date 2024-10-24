using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBLL.DTO.Request
{
    public class TestQuestionRequest
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestModelId { get; set; }
    }
}
