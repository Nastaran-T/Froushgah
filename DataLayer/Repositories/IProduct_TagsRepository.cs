using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_TagsRepository
    {
        // IList<Product_Tags> GetAllProduct_Tags();
        bool InsertProduct_Tags(Product_Tags Product_Tags);
        IEnumerable<Product_Tags> DeleteProduct_Tags(IEnumerable<Product_Tags> product_Tags);
        bool DeleteProduct_Tags(int ProductId);
        Product_Tags AddProduct_TagsByProductID(int productID, string tag);
        List<string> GetTagsByProductID(int productID);
        List<Product_Tags> GetTagsByID(int productID);
        List<Products> GetProductByTag(string tag);





    }
}
