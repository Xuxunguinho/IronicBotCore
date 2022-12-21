using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;
using UBotCore.Models;

namespace UBotCore.Nodes
{
    public class ChangeTopicNode : NodeBase
    {
        public Guid TopicId { get; set; }
        public override void Execute(Bot bot, BotDialog dialog, string userResponse)
        {
            base.Execute(bot, dialog, userResponse);
            dialog.SetCurrentTopic(TopicId);
            bot.Listem(dialog.Id);
        }


    }
}
