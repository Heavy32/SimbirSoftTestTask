using System.Collections.Generic;

namespace Services.FilterDecorator
{
    public class SplitStringByPatternFilter : IFilter
    {
        private readonly string text;
        private readonly char[] pattern;

        public SplitStringByPatternFilter(string text, char[] pattern)
        {
            this.text = text;
            this.pattern = pattern;
        }

        public IEnumerable<string> Filter()
        {
            return text.Split(pattern);
        }
    }
}
