using System;
using System.Collections.Generic;
using System.Text;

namespace lab1core.Modules
{
    public class Violation
    {
        public int      ViolationId      { get; set; }
        public string   NameViolation    { get; set; }
        public float    Fine             { get; set; }
        public DateTime CorrectionPeriod { get; set; }
    }
}
