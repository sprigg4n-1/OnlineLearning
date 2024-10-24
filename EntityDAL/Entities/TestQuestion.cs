using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Models
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestModelId {  get; set; }
        public TestModel TestModel { get; set; }
    }
}
