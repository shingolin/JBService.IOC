using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementA
{
    public class ImpA : ClassLibrary1.InterfaceA
    {
        public void RunA()
        {
            Console.WriteLine("我是實作A");
        }
    }
    public class ImpA1 : ClassLibrary1.InterfaceA
    {
        public void RunA()
        {
            Console.WriteLine("我是實作A1");
        }
    }
}
