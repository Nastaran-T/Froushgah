using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProductsRepositry
    {

        IEnumerable<Products> GetAllProducts();
        IEnumerable<Products> LoadProductByFilter(int pageId = 1, string title = "", int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null);
        Products GetProductById(int ProductId);
        bool InsertProduct(Products Product);
        bool UpdateProduct(Products Product);
        bool DeleteProduct(Products Product);
        bool DeleteProduct(int ProductId);
        IEnumerable<Products> GetLastProducts();
        List<Products> GetProductBySearch(string text);


    }
}
