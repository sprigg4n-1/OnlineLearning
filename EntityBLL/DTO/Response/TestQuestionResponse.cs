using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBLL.DTO.Response
{
    public class TestQuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestModelId { get; set; }
        public TestResponse Test { get; set; }
    }
}
