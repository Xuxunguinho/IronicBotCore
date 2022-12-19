// See https://aka.ms/new-console-template for more information
using UBotCore;
using UBotCore.Nodes;

Console.WriteLine("Hello, World!");

var botId = Guid.NewGuid();
var bot = new Bot {

    Id = botId,
    Name = "Julio Bot"
   , Topics = new List<Topic> { new Topic {
      Id = Guid.NewGuid(),
      BotId = botId,
      Description="",
      Name ="Saudacao",
      TriggerPhrases= new List<string> { "ola","bom dia","boa noite" ,"boa Tarde"},
      TriggerNode =  new AskUserNode{
                  Id  = Guid.NewGuid(),
                  Question=$"Ola humano eu sou o Yuca Bot em que lhe posso ajudar ?",
                  UserAnswerOptions=new List<Identity>();
                  Conditions =  new List<ConditionNode>{ new ConditionNode {Id = Guid.NewGuid(),Condition="@idade=20" , Children = new MessageNode { Body="Parabens por chegar ate aqui" } } },
              }        
      }     
   
  },
};

bot.Listem("ola amado amigo como vc esta");
Console.Read();
