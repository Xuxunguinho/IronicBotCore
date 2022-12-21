using IronicBotCore.Interfaces;
using IronicBotCore.Models;

namespace IronicBotCore.BaseClasses;

public abstract class NodeBase : INode
{
    public Guid Id { get; set; }
    public Guid? NextNode { get; set; }

    public virtual string ToScript()
    {
        return string.Empty;
    }

    public virtual void Execute(BotDialog dialog, string userResponse)
    {
        dialog.CurrentNodeId = Id;
        if (!dialog.Bot.DialogMap.Any(x => x.Id == dialog.Id))
            dialog.Bot.DialogMap.Add(dialog);
    }
}

