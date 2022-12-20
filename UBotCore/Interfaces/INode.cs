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
        public Guid? NextNode { get; set; }
        public  string ToScript();
        public  void Execute(Bot bot,BotDialog dialog, string userResponse);
    }
}
