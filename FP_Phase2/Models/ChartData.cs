using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FP_Phase2.Models
{
    public class ChartData
    {
        public List<string> Names { get; set; }
        public List<string> Targets { get; set; }
        public List<string> Actuals { get; set; }

        public ChartData()
        {

        }
    }
}