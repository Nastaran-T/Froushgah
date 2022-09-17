using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_FeaturesRepository
    {
        Product_Features GetProduct_FeaturesById(int id);
        List<Product_Features> GetProduct_FeaturesByProductId(int PId);
       // List<Product_Features> Get_FeaturesByPId(int PId);
        bool InsertProduct_Features(Product_Features P_Features);
        bool DeleteProduct_Features(Product_Features P_Features);
        bool DeleteProduct_Features(int id);
    }
}
