using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace lab1core.Modules
{
    public class Check
    {

        public int CheckID               { get; set; }
        public int InspectorId           { get; set; }
        public int InterpriseId          { get; set; }
        public int ViolationId           { get; set; }

        public  Violation Violation      { get; set; }
        public  Interprise Interprise    { get; set; }
        public  Inspector Inspector      { get; set; } 

        public DateTime Date             { get; set; }
        public int      ProtocolNumber   { get; set; }
        public string   Responsible      { get; set; }
        public float    Fine             { get; set; }
        public DateTime CorrectionPeriod { get; set; }

    }
}
