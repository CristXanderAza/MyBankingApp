using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MyBankingApp.NetStrategist
{
    public interface IStrategistFor<C, K> 
    {
        C GetStrategy(K key);
        IEnumerable<K> GetKeys();
    }
}
