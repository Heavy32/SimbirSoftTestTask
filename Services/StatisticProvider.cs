using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class StatisticProvider : IStatisticProvider
    {
        public Dictionary<string, int> GetWordsCount(IEnumerable<string> words)
        {
            if(words == null || words.Count() == 0)
            {
                LoggerSingleton.instance.Value.WriteInLog("there are no words");
                return null;
            }
             return words.GroupBy(word => word)
                .ToDictionary(group => group.Key, group => group.Count());
        }

    }               
}
