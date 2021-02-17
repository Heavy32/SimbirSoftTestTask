using System.Collections.Generic;

namespace Services.FilterDecorator
{
    public abstract class FilterDecorator : IFilter
    {
        private readonly IFilter filter;

        protected FilterDecorator(IFilter filter)
        {
            this.filter = filter;
        }

        public virtual IEnumerable<string> Filter()
        {
            return filter.Filter();
        }
    }
}
