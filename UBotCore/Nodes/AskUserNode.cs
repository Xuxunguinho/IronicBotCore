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
    public Identity UserAnswerOptionsType { get; set; }
    public List<object> UserAnswerOptionsValue { get; set; }
    public List<ConditionNode> Conditions { get; private set; } 
    public string VarToSaveResponse { get; set; }

    public override void Execute()
    {
        Console.WriteLine($"Bot: {Question}");
        Console.Write($"Human:");
        var answer = Console.ReadLine();   

        foreach (var s in this.Conditions) {
            s?.Execute();
        }
    }

    public override string ToScript()
    {
        throw new NotImplementedException();
    }
}
