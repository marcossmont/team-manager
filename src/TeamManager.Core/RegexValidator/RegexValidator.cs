using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TeamManager.Core.RegexValidator
{
    public static class RegexValidator
    {
        public static bool Match(string regexString, string textToMatch)
        {
            Regex regex = new Regex(regexString);
            Match match = regex.Match(textToMatch);
            return match.Success;
        }
    }
}
