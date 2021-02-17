using System.Collections.Generic;

namespace Services
{
    public interface IStatisticProvider
    {
        public Dictionary<string, int> GetWordsCount(IEnumerable<string> words);
    }
}
