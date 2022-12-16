using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UBotCore;

public class Identity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Regex Pattern { get; set; }
    public bool IsValid(string value)
    {
        return Pattern.IsMatch(value);
    }

}
