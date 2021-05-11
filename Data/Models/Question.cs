﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTests
{
    class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Dictionary<string, bool> Answers { get; set; }
    }
}