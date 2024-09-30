using System;

namespace TestApp
{
    // Testing Strings

    // Markdown syntax
    // https://www.markdownguide.org/basic-syntax/

    public class MarkdownFormatter
    {
        public string FormatAsBold(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException();

            return $"**{content}**";
        }
    }
}
