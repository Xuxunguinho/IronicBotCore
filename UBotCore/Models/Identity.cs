using System.Text.RegularExpressions;

namespace IronicBotCore.Models;

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
