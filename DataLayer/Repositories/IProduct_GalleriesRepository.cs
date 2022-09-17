using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_GalleriesRepository
    {
        bool InsertProduct_Galleries(Product_Galleries product_Galleries);
        IEnumerable<Product_Galleries> GetProduct_GalleriesByProductID(int productId);
        Product_Galleries GetGalleryById(int ProductId);
        bool DeleteProduct_Galleries(Product_Galleries product_Galleries);

    }
}
