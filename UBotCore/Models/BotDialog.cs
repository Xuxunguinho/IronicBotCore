namespace IronicBotCore.Models;

public class BotDialog
    {
        private Guid? _currentNodeId;
        public BotDialog(Bot bot)
        {
            Id = Guid.NewGuid();
            Bot = bot;
            AddOrVariableValue(Constants.BOT_NAME_VARIABLE, bot.Name);
        }

        public Bot Bot { get; set; }
        public Guid Id { get; set; }
        public Guid? ChanelId { get; set; }
        public Guid? CurrentTopicId { get; set; }
        public Guid? PreviousNodeId { get; set; }
        public Guid? CurrentNodeId
        {
            get => _currentNodeId; set
            {

                if (value.HasValue)
                {
                    PreviousNodeId = _currentNodeId;
                    _currentNodeId = value.Value;
                }
                else
                {
                    _currentNodeId = Guid.Empty;
                }
            }
        }
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();
        public void AddOrVariableValue(string name, object value)
        {

            if (!Variables.ContainsKey(name))
                Variables.Add(name, value);
            else
                Variables[name] = value;

        }
        public bool WaitingAnswer { get; set; }

        public void WaitUser() => WaitingAnswer = true;
        public void NoWaitUser() => WaitingAnswer = false;
        public void SetCurrentNode(Guid id) => CurrentNodeId = id;
        public void SetCurrentTopic(Guid id)
        {
            CurrentTopicId = id;
            CurrentNodeId = Guid.Empty;
        }

    }

