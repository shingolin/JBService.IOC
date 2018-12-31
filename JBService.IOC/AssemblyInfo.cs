using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBService.IOC
{
    public class AssemblyInfo
    {
        public string Path { get; set; }
        public string ClassName { get; set; }
        public List<string> ImplementedInterfaces { get; set; }
    }
}
