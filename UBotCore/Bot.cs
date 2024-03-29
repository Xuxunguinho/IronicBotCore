﻿using IronicBotCore.Interfaces;
using IronicBotCore.Models;
using kiki;
using System.Text.RegularExpressions;


namespace IronicBotCore;

public class Bot
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Topic> Topics { get; set; }

    public List<BotDialog> DialogMap { get; set; } = new List<BotDialog>();

    public Guid Listem(Guid? dialogId)
    {

        var dialog = new BotDialog(this);
        var topic = new Topic();
        var messageBody = string.Empty;
        if (dialogId.HasValue)
        {
            dialog = DialogMap.FirstOrDefault(x => x.Id == dialogId);

            // listening user if bot is waiting a user response
            if (dialog?.WaitingAnswer ?? false)
            {
                Console.WriteLine();
                Console.Write($"Human:");
                messageBody = Console.ReadLine() ?? string.Empty;
            }

            if (dialog?.CurrentTopicId.HasValue ?? false)
            {
                topic = Topics.FirstOrDefault(x => x.Id == dialog.CurrentTopicId.Value);

                if (topic is null) return dialog.Id;

                INode? node;

                if (dialog.CurrentNodeId.HasValue)
                    node = topic.Nodes.FirstOrDefault(s => s.Id == dialog.CurrentNodeId.Value);
                else
                    node = topic.Nodes[0];

                if (node is null && topic is not null)
                    node = topic.Nodes[0];

                node?.Execute(dialog, messageBody);

            }
            else
            {

                if (dialog is null) return Guid.Empty;

                topic = CheckTopic(messageBody);
                if (topic is null)
                    if (!Topics.IsNullOrEmpty())
                        // getting first topic if the system can't find related Tipic
                        topic = Topics[0];
                    else
                    {
                        Console.WriteLine("Topico nao foi encontrado");
                        return dialog.Id;
                    }

                dialog.CurrentTopicId = topic.Id;

                INode? node;

                if (dialog.CurrentNodeId.HasValue)
                    node = topic.Nodes.FirstOrDefault(s => s.Id == dialog.CurrentNodeId.Value);
                else
                    node = topic.Nodes[0];

                node?.Execute(dialog, messageBody);

            }


        }
        else
        {

            Console.Write($"Human:");
            messageBody = Console.ReadLine() ?? string.Empty;

            topic = CheckTopic(messageBody);

            if (topic is null)
                if (!Topics.IsNullOrEmpty())
                    // getting first topic if the system can't find related Tipic
                    topic = Topics[0];
                else
                {
                    Console.WriteLine("Topico nao foi encontrado");
                    return dialog.Id;
                }

            dialog.CurrentTopicId = topic.Id;

            INode? node;

            if (dialog.CurrentNodeId.HasValue)
                node = topic.Nodes.FirstOrDefault(s => s.Id == dialog.CurrentNodeId.Value);
            else
                node = topic.Nodes[0];
            node?.Execute(dialog, messageBody);
        }

        return dialog.Id;
    }
    public void Say(string message) => Console.WriteLine(message);
    private Topic CheckTopic(string message)
    {

        foreach (Topic topic in Topics)
        {
            foreach (string text in topic.TriggerPhrases)
            {

                var matches = Regex.Matches(message, text);

                if (matches.Count > 0) return topic;
                else continue;
            }
        }
        return null;
    }
}
