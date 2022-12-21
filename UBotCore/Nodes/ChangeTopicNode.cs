using IronicBotCore.BaseClasses;
using IronicBotCore.Models;

namespace IronicBotCore.Nodes
{
    public class ChangeTopicNode : NodeBase
    {
        public Guid TopicId { get; set; }
        public override void Execute(BotDialog dialog, string userResponse)
        {
            base.Execute(dialog, userResponse);
            dialog.SetCurrentTopic(TopicId);
            dialog.Bot.Listem(dialog.Id);
        }


    }
}
