using DataBaseProvider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SaveStatisticToDataBase : ISaveStatisticToDataBase
    {
        private readonly IAddStatistic statisticRepository;

        public SaveStatisticToDataBase(IAddStatistic statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public async Task Save(IDictionary<string, int> statistic, string siteName)
        {
           await statisticRepository.AddStatisticAsync(statistic, siteName);
        }
    }
}
