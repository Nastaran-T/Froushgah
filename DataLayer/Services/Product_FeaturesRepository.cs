using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_FeaturesRepository : IProduct_FeaturesRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_FeaturesRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }


        public Product_Features GetProduct_FeaturesById(int id)
        {
            return db.Product_Features.Find(id);
        }

        public List<Product_Features> GetProduct_FeaturesByProductId(int PId)
        {
            return db.Product_Features.Where(x => x.ProductID == PId).ToList();
        }

        public bool InsertProduct_Features(Product_Features P_Features)
        {
            try
            {
                db.Product_Features.Add(P_Features);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct_Features(Product_Features P_Features)
        {
            try
            {
                db.Entry(P_Features).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct_Features(int id)
        {
            try
            {
                var feature = GetProduct_FeaturesById(id);
                DeleteProduct_Features(feature);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        //public List<Product_Features> Get_FeaturesByPId(int PId)
        //{
            
        //  return  db.Product_Features.Where(x => x.ProductID == PId).ToList();
        //}
    }
}
