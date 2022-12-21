using kiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;
using UBotCore.Interfaces;
using UBotCore.Models;

namespace UBotCore.Nodes;

public class ConditionNode : NodeBase
{
    public string LeftOperand { get; set; }
    public string RightOperand { get; set; }
    public string Operator { get; set; }

    private readonly List<string> Operators = new List<string> { "=", ">", "<", ">=", "<=" };

    public bool IsTrue { get; private set; }
    public override void Execute(Bot bot, BotDialog dialog, string userResponse)
    {
        base.Execute(bot, dialog, userResponse);

        if (!Operators.Contains(Operator))
            throw new Exception("Operador nao encontrado");

        var condition = string.Empty;

        //check if the operand is dialog variable
        var left = LeftOperand.Contains("@") ? dialog.Variables[LeftOperand] : LeftOperand;
        var right = RightOperand.Contains("@") ? dialog.Variables[LeftOperand] : RightOperand;

        //normalize string for best comparison
        left = left.ToString().Normalized().ToLower();
        right = right.ToString().Normalized().ToLower();

        if (Operator.Equals("="))
            condition = $"eq('{left}', '{right}')";

        if (Operator.Equals(">"))
            condition = $"mt('{left}', '{right}')";

        if (Operator.Equals(">="))
            condition = $"mte('{left}', '{right}')";

        if (Operator.Equals("<"))
            condition = $"lt('{left}', '{right}')";

        if (Operator.Equals("<="))
            condition = $"lte('{left}', '{right}')";

        var result = kiki.lizzie.LambdaCompiler.Compile(condition);
        var obj = (bool)result.Invoke();
        IsTrue = obj;
        if (obj)
        {
            dialog.CurrentNodeId = this.NextNode;
        }
    }


}
