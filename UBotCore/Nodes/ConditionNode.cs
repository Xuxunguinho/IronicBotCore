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
        Children?.Execute();
    }

    public override string ToScript()
    {
        return Condition;
    }

}
