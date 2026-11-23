using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static XmlToList.Enums;

namespace XmlToList
{
    public class ContentTagValueHelper
    {
        public ContentTagValueHelper()
        {

        }

        public static List<string> GetMWVEmailTemplateTags(string content)
        {
            //var content = GetMWVTemplateBodyContent();
            var tags = GetTokens(content);
            tags = tags.Select(t => Regex.Replace(t, "e:", "", RegexOptions.IgnoreCase)).ToList();
            return tags.Select(t => Regex.Replace(t, "s:", "", RegexOptions.IgnoreCase)).ToList();
        }

        private static string GetMWVTemplateBodyContent()
        {
            var content = File.ReadAllText(CommonHelper.Append(@"D:\E\Experiments\XmlToList\Template.txt"), System.Text.Encoding.UTF8);
            var bodyStart = content.IndexOf("<body>", StringComparison.InvariantCultureIgnoreCase);
            var bodyEnd = content.IndexOf("</body>", StringComparison.InvariantCultureIgnoreCase);
            return content.Substring(bodyStart, bodyEnd - bodyStart);
        }

        private static List<String> GetTokens(String str)
        {
            Regex regex = new Regex(@"(?<=\{)[^}]*(?=\})", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(str);
            return matches.Cast<Match>().Select(m => m.Value).Distinct().ToList();
        }
    }
}
