using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UBotCore
{
    public  class Bot
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public List<Topic> Topics { get; set; }


        public void Listem(string messageBody) 
        {
            Console.WriteLine($"Human: {messageBody}");
            var topic = CheckTopic(messageBody);
            if (topic is not null) Console.WriteLine($" ====>> Topico: {topic.Name}");
            else Console.WriteLine("Topico nao foi encontrado");

            topic.TriggerNode?.Execute();
        }

        private Topic CheckTopic(string message) {

            foreach (Topic topic in Topics) {
                foreach (string text in topic.TriggerPhrases) {

                    var matches = Regex.Matches(message, text);

                    if (matches.Count > 0) return topic;
                    else continue;
                }
            }
            return null;
        }
    }
}
