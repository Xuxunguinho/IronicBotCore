using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;
using UBotCore.Interfaces;

namespace UBotCore.Nodes;

public class ConditionNode : NodeBase
{
    public string Condition { get; set; }
    public INode Children { get; set; }

    public override void Execute()
    {
        var result =   kiki.lizzie.LambdaCompiler.Compile("eq(2,2)");
        var obj = (bool)result.Invoke();
        if (obj) 
        {
            Children?.Execute();
        }
        
    }

    public override string ToScript()
    {
        return Condition;
    }

}
