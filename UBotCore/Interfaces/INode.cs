using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBotCore.Interfaces
{
    public  interface INode
    {
        public Guid Id { get; set; }
        public INode Children { get; set; }
        public  string ToScript();
        public  void Execute();
    }
}
