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

        public BotDialog()
        {
            Id = Guid.NewGuid();    
        }
        public Guid Id { get; set; }   
        public Guid? ChanelId { get; set; }
        public Guid? CurrentTopicId { get; set; }   
        public Guid? CurrentNodeId { get; set; }
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();
        public bool WaitingAnswer { get; set; }

        public void WaitUser() => WaitingAnswer = true;
        public void NoWaitUser() => WaitingAnswer = false;

    }
}
