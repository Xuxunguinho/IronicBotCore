using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;

namespace UBotCore.Nodes;

internal class ActionNode : NodeBase
{
    public string Action { get; set; }


    public override void Execute(Bot bot, BotDialog dialog, string userResponse)
    {
        base.Execute(bot,dialog,userResponse);


    }
    public override string ToScript()
    {
       return Action;
    }
}
