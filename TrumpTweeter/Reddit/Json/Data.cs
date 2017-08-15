using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpTweeter.Json
{
    public class Data
    {
        public string modhash { get; set; }
        public List<Child> children { get; set; }
        public string after { get; set; }
        public object before { get; set; }
    }
}
