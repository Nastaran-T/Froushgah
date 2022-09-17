using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductsRepository : IProductsRepositry
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public ProductsRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }


        public IEnumerable<Products> GetAllProducts()
        {
            return db.Products;
        }

        public Products GetProductById(int ProductId)
        {
            return db.Products.Find(ProductId);
        }

        public bool InsertProduct(Products Product)
        {
            try
            {
                db.Products.Add(Product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateProduct(Products Product)
        {
            try
            {
                db.Entry(Product).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct(Products Product)
        {
            try
            {
                db.Entry(Product).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                var product = GetProductById(ProductId);
                DeleteProduct(product);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Products> GetLastProducts()
        {
            return db.Products.OrderByDescending(x => x.CreateDateProduct).Take(12);
        }

        public List<Products> GetProductBySearch(string text)
        {
            return db.Products.Where(x => x.TitleProduct.Contains(text) || x.ShortDescriptionProduct.Contains(text) || x.TextProduct.Contains(text)).ToList();
        }

        public IEnumerable<Products> LoadProductByFilter(int pageId = 1, string title = "", int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null)
        {
            List<Products> productList = new List<Products>();
            if (selectedGroups != null && selectedGroups.Any())
            {
                foreach (int item in selectedGroups)
                {
                    productList.AddRange ( db.Product_Selected_Groups.Where(g => g.GroupID == item).Select(g => g.Products).ToList());
                }
                productList = productList.Distinct().ToList();
            }
            else
            {
                productList.AddRange(db.Products.ToList());
            }

            if (!string.IsNullOrEmpty(title))
            {
                productList = productList.Where(p => p.TitleProduct.Contains(title)).ToList();
            }

            if (minPrice > 0)
            {
                productList = productList.Where(p => p.PriceProduct >= minPrice).ToList();
            }
            if (maxPrice > 0)
            {
                productList = productList.Where(p => p.PriceProduct <= maxPrice).ToList();
            }

           
            return productList;
        }
    }
}

            

