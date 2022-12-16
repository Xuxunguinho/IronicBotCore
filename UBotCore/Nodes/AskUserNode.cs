using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;

namespace UBotCore.Nodes;

public  class AskUserNode:NodeBase
{
    public string Question { get; set; }
    public List<Identity> UserAnswerOptions { get; set; }
    public List<ConditionNode> Conditions { get; set; } 
    public string VarToSaveResponse { get; set; }

    public override void Execute()
    {
        Console.WriteLine($"Bot: {Question}");
        var answer = Console.ReadLine();
        Console.WriteLine($"Human: {answer}");
        foreach (var s in this.Conditions) {
            s?.Execute();
        }
    }

    public override string ToScript()
    {
        throw new NotImplementedException();
    }
}
