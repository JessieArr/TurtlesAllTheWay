using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace TATW.Target.Models
{
    [GeneratedCode("TATW", "0.0.1")]
    public class Teacher
    {    
        public string Name { get; set; }
        public int Age { get; set; }
        public int ClassSize { get; set; }
        public string Address { get; set; }
    }
}
