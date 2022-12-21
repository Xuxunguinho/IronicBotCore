// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;
using System.Xml.Linq;
using UBotCore;
using UBotCore.Nodes;
using UBotCore.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var identityRepository = new IdentityRepository();

        var botId = Guid.NewGuid();
        var recrutamentoTopicId = Guid.NewGuid();
        var messageId = Guid.NewGuid();
        var Id1 = Guid.NewGuid();
        var Id2 = Guid.NewGuid();
        var Id3 = Guid.NewGuid();
        var Id4 = Guid.NewGuid();
        var Id5 = Guid.NewGuid();
        var Id6 = Guid.NewGuid();
        var Id7 = Guid.NewGuid();

        var bot = new Bot
        {

            Id = botId,
            Name = "Julio Bot"
            ,
            Topics = new List<Topic> {

        new Topic {
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

               ,UserAnswerOptionsType= identityRepository.Get("any")?? new UBotCore.Models.Identity(),

                UserAnswerOptionsValue=  new List<string>{ "Comercial", "Recrutamento", "Colaboradores", "Outros Assuntos" },
                VarToSaveResponse="@var1"
            ,   Conditions = new List<ConditionNode>{
                    new ConditionNode {  LeftOperand="@var1" ,Operator="=" ,RightOperand = "Recrutamento", NextNode = Id1}

            }
            }

            ,
             new ChangeTopicNode{ Id  = Id1,TopicId = recrutamentoTopicId},
      },

  },  new Topic {
      Id = recrutamentoTopicId,
      BotId = botId,
      Description="",
      Name ="Saudacao",
      TriggerPhrases= new List<string> { "recrutar","recruta","recrutamento","candidatura" ,"candidatar"},
      Nodes = new List<UBotCore.Interfaces.INode> {
           new QuestionNode { Id = Id2,
                Question= "Bem-vindo(a) à nossa Área de Recrutamento.\r\nPor favor, marque: \r\n\r\n " +
                " 1 - Candidatura para a função de Assistente de Contact Center.\r\n " +
                " 2 -  Regressar ao Menu Inicial\r\nPara outras oportunidades," +
                " deverá consultar o nosso site (link site) "
               ,UserAnswerOptionsType= identityRepository.Get("number") ?? new UBotCore.Models.Identity(),
                UserAnswerOptionsValue=  new List<string>{ "1", "2" }
               ,VarToSaveResponse="@var2"
            ,   Conditions = new List<ConditionNode>
            {
                    new ConditionNode {  LeftOperand="@var2" ,Operator="=" ,RightOperand = "1", NextNode = Id3}

            },
            },
           new QuestionNode {
               Id = Id3,
               Question ="Por favor indique seu nome completo",
               UserAnswerOptionsType = identityRepository.Get("any")?? new UBotCore.Models.Identity()
              ,VarToSaveResponse = "@name",
               NextNode = Id4
           },
           new QuestionNode {
               Id = Id4,
               Question ="Por favor indique seu número de Bilhete",
               UserAnswerOptionsType = identityRepository.Get("bilhete")?? new UBotCore.Models.Identity()
              ,VarToSaveResponse = "@bi",
               NextNode = Id5
           }
           , new QuestionNode {
               Id = Id5,
               Question ="Por favor indique seu Endereço de Email",
               UserAnswerOptionsType = identityRepository.Get("email")?? new UBotCore.Models.Identity()
              ,VarToSaveResponse = "@email",
               NextNode = Id6           }
           , new QuestionNode {
               Id = Id6,
               Question ="Por favor indique sua data de nasciento",
               UserAnswerOptionsType = identityRepository.Get("date")?? new UBotCore.Models.Identity()
              ,VarToSaveResponse = "@data_nascimento",
               NextNode = Id7
           }
           ,
            new MessageNode { Id= Id7,  Body= "Muito Obrigado Sr @name, assim que a sua candidatura for efectuada entraremos em contacto!"},
      },

  },
}
        };

        bot.Listem(null);
        Console.Read();
    }
}