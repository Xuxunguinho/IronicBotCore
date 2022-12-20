// See https://aka.ms/new-console-template for more information
using UBotCore;
using UBotCore.Nodes;
using UBotCore.Repositories;

var identityRepository = new IdentityRepository();

var botId = Guid.NewGuid();
var messageId = Guid.NewGuid();
var Id1 = Guid.NewGuid();
var Id2 = Guid.NewGuid();
var Id3 = Guid.NewGuid();
var bot = new Bot
{

    Id = botId,
    Name = "Julio Bot"
    ,
    Topics = new List<Topic> { new Topic {
      Id = Guid.NewGuid(),
      BotId = botId,
      Description="",
      Name ="Saudacao",
      TriggerPhrases= new List<string> { "ola","oi","bom dia","boa noite" ,"boa Tarde"},
      Nodes = new List<UBotCore.Interfaces.INode> {
            new QuestionNode { Id=messageId,
                Question= "Olá, eu sou a Yuca, a Assistente Virtual da Ucall." +
                " Em que posso ajudar? \n \n Seleccione por favor  em que Área precisa " +
                "do meu Auxilio:\r\n  - Comercial \n  - Recrutamento\n  - Colaboradores " +
                " \n  - Outros Assuntos"
               ,UserAnswerOptionsType= identityRepository.Get("any"),
                UserAnswerOptionsValue=  new List<string>{ "Comercial", "Recrutamento", "Colaboradores", "Outros Assuntos" },               
                VarToSaveResponse="@var1"
            ,   Conditions = new List<ConditionNode>
            { 
                    new ConditionNode {  LeftOperand="@var1" ,Operator="=" ,RightOperand = "Recrutamento", NextNode = Id2}
             
            },
            },
           new QuestionNode { Id = Id2,
                Question= "Bem-vindo(a) à nossa Área de Recrutamento.\r\nPor favor, marque: \r\n\r\n " +
                " 1 - Candidatura para a função de Assistente de Contact Center.\r\n " +
                " 2 -  Regressar ao Menu Inicial\r\nPara outras oportunidades," +
                " deverá consultar o nosso site (link site) "
               ,UserAnswerOptionsType= identityRepository.Get("number"),
                UserAnswerOptionsValue=  new List<string>{ "1", "2" }               
               ,VarToSaveResponse="@var2"
            ,   Conditions = new List<ConditionNode>
            {
                    new ConditionNode {  LeftOperand="@var2" ,Operator="=" ,RightOperand = "1", NextNode = Id3}

            },
            },
            new MessageNode { Id= Id3,  Body= "Muito Obrigado por nos contactar amando", NextNode =Id1 },

      },

  },
}
};

//Console.Write($"Human:");
//var message = Console.ReadLine();
bot.Listem(null);
Console.Read();
