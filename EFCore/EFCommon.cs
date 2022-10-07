using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EFCore
{
    public static class EFCommon
    {
        public static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
