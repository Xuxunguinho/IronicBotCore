using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UBotCore.Models;

namespace UBotCore
{
    internal static class Extensions
    {
        public static string ReplaceInternalVariables(this string source, BotDialog dialog)
        {

            var variablePattern = new Regex("@(?:[-a-z0-9]+)");
            var matchs = variablePattern.Matches(source);
            if (matchs.Count < 0) return source;
            foreach (var match in matchs)
            {
                var replacer = new Regex(Regex.Escape(match.ToString() ?? string.Empty));
                if (dialog.Variables.ContainsKey(match.ToString() ?? string.Empty))
                {
                    var value = dialog.Variables[match.ToString() ?? string.Empty];
                    source = replacer.Replace(source, value.ToString() ?? string.Empty);
                }

            }

            return source;
        }
    }
}
