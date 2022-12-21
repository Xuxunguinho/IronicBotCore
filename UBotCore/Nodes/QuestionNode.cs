using kiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UBotCore.BaseClasses;
using UBotCore.Models;

namespace UBotCore.Nodes;

public class QuestionNode : NodeBase
{
    public string Question { get; set; }
    public Identity UserAnswerOptionsType { get; set; }
    public List<string> UserAnswerOptionsValue { get; set; }
    public List<ConditionNode> Conditions { get; set; }
    public string VarToSaveResponse { get; set; }

    public Guid? NextNode { get; set; }
    public QuestionNode()
    {
        this.NextNode = null;
    }

    public override void Execute(Bot bot, BotDialog dialog, string userResponse)
    {
        base.Execute(bot, dialog, userResponse);


        if (!dialog.WaitingAnswer)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"Bot: {Question}");

            //if (!UserAnswerOptionsValue.IsNullOrEmpty())

            //    foreach (var s in UserAnswerOptionsValue)
            //        strBuilder.AppendLine(" " + s);

            Console.Write(strBuilder.ToString());

            dialog.WaitUser();
            // only for contiue flux
            bot.Listem(dialog.Id);

        }
        else
        {
            var normalizedResponse = userResponse;
            var matchRegx = UserAnswerOptionsType.IsValid(userResponse);

            if (!matchRegx)
            {
                Console.WriteLine(" ==> Os dados inseridos não estão no formato esperado <==");
                dialog.NoWaitUser();
                dialog.SetCurrentNode(this.Id);
                bot.Listem(dialog.Id);
                return;
            }

            if (UserAnswerOptionsType.Name.Equals("any"))
                normalizedResponse = userResponse.Normalized();

            if (VarToSaveResponse.IsNullOrEmpty())
            {
                VarToSaveResponse = $"@var{dialog.Variables.Count + 1}";
                dialog.Variables.Add(VarToSaveResponse, userResponse);
            }
            else
            {
                if (!VarToSaveResponse.Contains("@"))
                    throw new Exception($"A variavel {VarToSaveResponse} não se encontra no formato correto");

                if (!dialog.Variables.ContainsKey(VarToSaveResponse))
                    dialog.Variables.Add(VarToSaveResponse, userResponse);
                else
                    dialog.Variables[VarToSaveResponse] = userResponse;
            }

            var resultList = new List<bool>();

            if (Conditions.IsNullOrEmpty())
            {
                if (NextNode.HasValue)
                {

                    dialog.NoWaitUser();
                    dialog.SetCurrentNode(NextNode.Value);
                    bot.Listem(dialog.Id);
                    return;
                }
                throw new Exception("Conditions node can not be null in QuestionNode");

            }

            foreach (var item in Conditions)
            {
                item.Execute(bot, dialog, userResponse);
                resultList.Add(item.IsTrue);
            }

            if (!resultList.Contains(true))
            {
                var strBuilder = new StringBuilder();

                strBuilder.AppendLine($"Bot: Nao consigo perceber sua escolha, por favor selecione apenas uma destas opções:");

                if (!UserAnswerOptionsValue.IsNullOrEmpty())

                    foreach (var s in UserAnswerOptionsValue)
                        strBuilder.AppendLine(" " + s);

                Console.Write(strBuilder.ToString());
                dialog.WaitUser();
                dialog.SetCurrentNode(this.Id);
                bot.Listem(dialog.Id);
            }
            else
            {
                dialog.NoWaitUser();
                bot.Listem(dialog.Id);
            }


        }

    }
}
