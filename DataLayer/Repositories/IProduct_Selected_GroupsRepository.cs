using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_Selected_GroupsRepository
    {
        IEnumerable<Product_Selected_Groups> GetAllproduct_Selected_Groups();
        bool InsertProduct_Selected_Groups(Product_Selected_Groups product_Selected_Groups);
        bool Addproduct_Selected_Groups( int productID, int groupID);
        List<Product_Selected_Groups> Getselected_GroupsByProductID(int productID);
        IEnumerable<Product_Selected_Groups> DeleteProduct_Selected_Groups(IEnumerable<Product_Selected_Groups> product_Selected_Groups);
        bool DeleteProduct_Selected_Groups(int ProductId);

    }
}

