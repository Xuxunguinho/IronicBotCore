using IronicBotCore.BaseClasses;
using IronicBotCore.Models;

namespace IronicBotCore.Nodes;

public class MessageNode : NodeBase
{
    public string Body { get; set; }
    public bool IsFile { get; set; }
    public string FileName { get; set; }

    public override void Execute(BotDialog dialog, string userResponse)
    {
        base.Execute(dialog, userResponse);
        Console.WriteLine($"Bot: {Body.ReplaceInternalVariables(dialog)}");
    }

}
