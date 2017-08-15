using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrumpTweeter.Json
{
    public class Image
    {
        public Source source { get; set; }
        public List<Resolution> resolutions { get; set; }
        public string id { get; set; }
    }
}
