using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;

namespace UBotCore.Nodes
{
    public class TriggerNode : NodeBase
    {
        public override void Execute()
        {
            Console.WriteLine($"Bot: Ola humano eu sou o Yuca Bot em que lhe posso ajudar ? ");
            Children?.Execute();
        }
        public override string ToScript()
        {
            throw new NotImplementedException();
        }


    }
}
