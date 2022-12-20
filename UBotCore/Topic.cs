using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBotCore.BaseClasses;
using UBotCore.Interfaces;
using UBotCore.Nodes;

public class Topic
{
    public Guid Id { get; set; }
    public Guid BotId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> TriggerPhrases { get; set; }   
    public List<INode> Nodes { get; set; }

}
