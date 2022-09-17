using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_GroupsRepository
    {
        IEnumerable<Product_Groups> GetAllProduct_Group();
        Product_Groups GetProduct_GroupById(int Product_GroupId);
        IEnumerable<Product_Groups> GetSubGroupByGroupId(int GId);
        bool InsertProduct_Group(Product_Groups Product_Group);
        bool UpdateProduct_Group(Product_Groups Product_Group);
        bool DeleteProduct_Group(Product_Groups Product_Group);
        bool DeleteProduct_Group(int Product_GroupId);
        IEnumerable<Product_Groups> GetAllParentProduct_Group();


    }
}
