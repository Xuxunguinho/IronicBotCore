using IronicBotCore.Interfaces;

namespace IronicBotCore.Models;
public class Topic
{
    public Guid Id { get; set; }
    public Guid BotId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> TriggerPhrases { get; set; }
    public List<INode> Nodes { get; set; }

}
