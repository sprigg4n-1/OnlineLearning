using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBLL.DTO.Response
{
    public class TestResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public int CourseId { get; set; }
    }
}
