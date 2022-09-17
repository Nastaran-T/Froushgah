using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_TagsRepository : IProduct_TagsRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_TagsRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }


        //public IList< Product_Tags> GetAllProduct_Tags()
        //{
        //    return db.Product_Tags.Select(x=>x.Tag).ToList();
        //}



        public bool InsertProduct_Tags(Product_Tags Product_Tags)
        {
            try
            {
                db.Product_Tags.Add(Product_Tags);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Product_Tags> DeleteProduct_Tags(IEnumerable<Product_Tags> product_Tags)
        {
           return db.Product_Tags.RemoveRange(product_Tags);
           
        }

        public bool DeleteProduct_Tags(int ProductId)
        {
            try
            {
                List<Product_Tags> tag = GetTagsByID(ProductId);

               // List<string> tags = GetTagsByProductID(ProductId);
                 DeleteProduct_Tags(tag.ToList());
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product_Tags AddProduct_TagsByProductID(int productID, string tag)
        {

            Product_Tags product_Tag = new Product_Tags { ProductID = productID, Tag = tag };
            return (db.Product_Tags.Add(product_Tag));

        }

        public List<string> GetTagsByProductID(int productID)
        {
            var query = db.Product_Tags.Where(p => p.ProductID == productID).Select(p => p.Tag.Trim());
            return query.ToList();
        }
        public List<Product_Tags> GetTagsByID(int productID)
        {
            var query = db.Product_Tags.Where(p => p.ProductID == productID);
            return query.Select(p=>p).ToList();
        }

        //product=>product_Tags
        public List<Products> GetProductByTag(string tag)
        {
            return db.Product_Tags.Where(x => x.Tag == tag).Select(x => x.Products).ToList();
        }
    }
}




