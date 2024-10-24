using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public int CourseId { get; set; }
        public ICollection<TestQuestion> TestQuestions { get; }
    }
}
