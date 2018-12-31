using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementA
{
    public class ImpB : InterfaceB
    {
        InterfaceA _interfaceA;
        InterfaceC _interfaceC;
        //public ImpB(InterfaceA interfaceA, InterfaceC interfaceC)
        //{
        //    _interfaceA = interfaceA;
        //    _interfaceC = interfaceC;
        //}
        public ImpB(InterfaceA interfaceA)
        {
            _interfaceA = interfaceA;
        }
        public ImpB(InterfaceC interfaceC)
        {
            _interfaceC = interfaceC;
        }
        public void RunB()
        {
            Console.WriteLine("我是ImpB12------");
            if(_interfaceA!=null)
            _interfaceA.RunA();
            if (_interfaceC != null)
                _interfaceC.Gogo();
        }
    }
}
