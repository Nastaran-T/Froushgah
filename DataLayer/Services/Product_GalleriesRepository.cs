using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_GalleriesRepository : IProduct_GalleriesRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_GalleriesRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }

      

        public Product_Galleries GetGalleryById(int Id)
        {
           return db.Product_Galleries.Find(Id);
        }

        public IEnumerable<Product_Galleries> GetProduct_GalleriesByProductID(int productId)
        {
            return db.Product_Galleries.Where(x => x.ProductID == productId).ToList();
        }

        public bool InsertProduct_Galleries(Product_Galleries product_Galleries)
        {
            try
            {
                db.Product_Galleries.Add(product_Galleries);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct_Galleries(Product_Galleries product_Galleries)
        {
            try
            {
                db.Entry(product_Galleries).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
