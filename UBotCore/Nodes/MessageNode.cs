using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;

namespace UBotCore.Nodes;

public  class MessageNode : NodeBase
{
    public string Body { get; set; }
    public bool IsFile { get; set; }
    public string FileName { get; set; }

    public override void Execute(Bot bot, BotDialog dialog, string userResponse)
    {
        base.Execute( bot, dialog,userResponse);
        Console.WriteLine($"Bot: {Body}");
    }

    public override string ToScript()
    {
        return Body;
    }
}
