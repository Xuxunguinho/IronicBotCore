using IronicBotCore.Models;

namespace IronicBotCore.Interfaces;

public interface INode
    {
        public Guid Id { get; set; }
        public Guid? NextNode { get; set; }
        public string ToScript();
        public void Execute(BotDialog dialog, string userResponse);
    }

