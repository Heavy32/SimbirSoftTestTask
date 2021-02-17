using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FilterDecorator
{
    public class OnlyWordsFilterDecorator : FilterDecorator, IFilter
    {
        public OnlyWordsFilterDecorator(IFilter filter) : base(filter) { }

        public override IEnumerable<string> Filter()
        {
            IEnumerable<string> words = base.Filter();
            return words.Where(word => word != "\0" && word != "" && !word.Any(char.IsDigit));
        }
    }
}
