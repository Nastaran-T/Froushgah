using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFeaturesRepository
    {
        IEnumerable<Features> GetAllFeatures();
        Features GetFeaturesById(int FeaturesId);
        bool InsertFeatures(Features Features);
        bool UpdateFeatures(Features Features);
        bool DeleteFeatures(Features Features);
        bool DeleteFeatures(int FeaturesId);
    }
}
