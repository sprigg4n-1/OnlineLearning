﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDAL.Parameters
{
    public class TestParameters: QueryStringParameters
    {
        public int TestModelId { get; set; }
        public string QuestionText { get; set; }
    }
}
