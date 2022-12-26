using IronicBotCore.BaseClasses;
using IronicBotCore.Models;
using kiki;
using System.Text;

namespace IronicBotCore.Nodes;

public class QuestionNode : NodeBase
{
    public string Question { get; set; }
    public Identity UserAnswerOptionsType { get; set; }
    public List<string> UserAnswerOptionsValue { get; set; }
    public List<ConditionNode> Conditions { get; set; }
    public string VarToSaveResponse { get; set; }
    public override void Execute(BotDialog dialog, string userResponse)
    {
        base.Execute(dialog, userResponse);

        Question = Question.ReplaceInternalVariables(dialog);

        if (!dialog.WaitingAnswer)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"Bot: {Question}");

            //if (!UserAnswerOptionsValue.IsNullOrEmpty())

            //    foreach (var s in UserAnswerOptionsValue)
            //        strBuilder.AppendLine(" " + s);

            dialog.Bot.Say(strBuilder.ToString());

            dialog.WaitUser();
            // only for contiue flux
            dialog.Bot.Listem(dialog.Id);

        }
        else
        {

            var matchRegx = UserAnswerOptionsType.IsValid(userResponse);

            if (!matchRegx)
            {
                dialog.Bot.Say(" ==> Os dados inseridos não estão no formato esperado <==");
                dialog.NoWaitUser();
                dialog.SetCurrentNode(Id);
                dialog.Bot.Listem(dialog.Id);
                return;
            }
           
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
                    dialog.Bot.Listem(dialog.Id);
                    return;
                }
                throw new Exception("Conditions node can not be null in QuestionNode");

            }

            foreach (var item in Conditions)
            {
                item.Execute(dialog, userResponse);
                resultList.Add(item.IsTrue);
            }

            if (!resultList.Contains(true))
            {
                var strBuilder = new StringBuilder();

                if (UserAnswerOptionsValue.Any(x => NLP.Equals(x,userResponse)))
                {
                    strBuilder.AppendLine($"Bot:Lamento,no momento não lhe posso ajudar quanto a esta questão!");
                    strBuilder.AppendLine("Posso lhe ajudar com mais alguma coisa ?");
                   
                    dialog.Bot.Say(strBuilder.ToString());
                    dialog.NoWaitUser();
                    dialog.SetCurrentNode(Id);
                    dialog.Bot.Listem(dialog.Id);
                    return;
                }
                else {
                    strBuilder.AppendLine($"Bot: Nao consigo perceber sua escolha, por favor selecione apenas uma destas opções:");
                }
                

                if (!UserAnswerOptionsValue.IsNullOrEmpty())

                    foreach (var s in UserAnswerOptionsValue)
                        strBuilder.AppendLine(" " + s);

                dialog.Bot.Say(strBuilder.ToString());
                dialog.WaitUser();
                dialog.SetCurrentNode(Id);
                dialog.Bot.Listem(dialog.Id);
            }
            else
            {
                dialog.NoWaitUser();
                dialog.Bot.Listem(dialog.Id);
            }


        }

    }
}
