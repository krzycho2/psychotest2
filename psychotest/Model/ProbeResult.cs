using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psychotest.Model
{
    public class ProbeResult
    {
        public string ID { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }
        public bool Done { get; set; }
        public string Q1Answer { get; set; }
        public string Q2Answer { get; set; }
        public string Q3Answer { get; set; }
        public string Q4Answer { get; set; }
        public string Q5Answer { get; set; }
    }
}
