using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UBotCore.Interfaces;

namespace UBotCore.BaseClasses;

public abstract class NodeBase: INode
{
    public Guid Id { get; set; }
    public Guid? NextNode { get; set; }

    public abstract string ToScript();

    public virtual void Execute(Bot bot,BotDialog dialog, string userResponse) {
        dialog.CurrentNodeId = Id;
        if (!bot.DialogMap.Any(x => x.Id == dialog.Id))
            bot.DialogMap.Add(dialog);
    }
}

