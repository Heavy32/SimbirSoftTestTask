using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FilterDecorator
{
    public interface IFilter
    {
        public IEnumerable<string> Filter();
    }
}
