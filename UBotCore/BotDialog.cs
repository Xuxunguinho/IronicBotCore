using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.Interfaces;

namespace UBotCore
{
    public class BotDialog
    {


        public Guid Id { get; set; }
        public Human Human { get; set; }
        public Guid ChanelId { get; set; }
        public Guid CurrentTopicId { get; set; }   
        public Guid CurrentNodeId { get; set; }
        public List<(Guid, Guid, string)> HumanMessage { get; set; }

    }
}
