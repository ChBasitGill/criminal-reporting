using System;

namespace criminal.reporting.models
{
    public class CrimeCase
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Address{ get; set; }
        public string Gender{ get; set; }
        public int Age{ get; set; }
        public string CrimeInfo{ get; set; }
        public DateTime DateOfCrime{ get; set; }
        public string Contact{ get; set; }
        public string[] CaseImages{ get; set; }
    }
}