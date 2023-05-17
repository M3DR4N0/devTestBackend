using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTestBackend.Entities.Structs
{
    public struct DecoratorStruct
    {
        public Type ContractService { get; set; }
        public ImplemetedServices ImplemetedServices { get; set; }  


    }

    public struct ImplemetedServices 
    {
        public Type Inner { get; set; }
        public Type Validation { get; set; }
        public Type Error { get; set; } 
    }
}
