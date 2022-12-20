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
        public override void Execute(Bot bot, BotDialog dialog, string userResponse)
        {
            base.Execute(bot,dialog,userResponse);
            Console.WriteLine($"Bot: Ola humano eu sou o Yuca Bot em que lhe posso ajudar ? ");
           
        }
        public override string ToScript()
        {

            throw new NotImplementedException();
        }


    }
}
