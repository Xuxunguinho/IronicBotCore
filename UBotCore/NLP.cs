using IronicBotCore.Models;
using kiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IronicBotCore
{
    internal static class NLP
    {

        public static bool Equals(this string source, string source1 ) { 
        
            return source.Normalized().Equals( source1.Normalized() ,StringComparison.OrdinalIgnoreCase);
        }

        public static bool CheckPositiveInstent(string userResponse)
        { 
            var positiveIntents = new[] { "certo", "sim", "ok","sim aceito", "correcto", "certamente", "yes" };
            var normalizedUserResponse = userResponse.Normalized();
            foreach (string intent in positiveIntents)
            {
                var matches = Regex.Matches(normalizedUserResponse, intent);
                if (matches.Count > 0) return true;
                else continue;
            }
            return  false;
        }
    }
}
