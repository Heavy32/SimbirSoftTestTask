using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ISaveStatisticToDataBase
    {
        public Task Save(IDictionary<string, int> statistic, string siteName);
    }
}
