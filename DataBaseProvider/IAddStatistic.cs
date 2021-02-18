using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBaseProvider
{
    public interface IAddStatistic
    {
        public Task AddStatisticAsync(IDictionary<string, int> statistic, string siteName);
    }
}
