using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_Selected_GroupsRepository:IProduct_Selected_GroupsRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_Selected_GroupsRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Product_Selected_Groups> GetAllproduct_Selected_Groups()
        {
            return db.Product_Selected_Groups;
        }

        public bool InsertProduct_Selected_Groups(Product_Selected_Groups product_Selected_Groups)
        {
            try
            {
                db.Product_Selected_Groups.Add(product_Selected_Groups);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool Addproduct_Selected_Groups( int productID, int groupID)
        {
            try
            {
                Product_Selected_Groups product_Selected_Groups = new Product_Selected_Groups {ProductID=productID,GroupID= groupID };
                db.Product_Selected_Groups.Add(product_Selected_Groups);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product_Selected_Groups> Getselected_GroupsByProductID(int productID)
        {
            var query = db.Product_Selected_Groups.Where(p => p.ProductID == productID);
            return query.ToList();
        }

        public IEnumerable<Product_Selected_Groups> DeleteProduct_Selected_Groups(IEnumerable<Product_Selected_Groups> product_Selected_Groups)
        {
           return db.Product_Selected_Groups.RemoveRange(product_Selected_Groups).ToList();

        }

        public bool DeleteProduct_Selected_Groups(int ProductId)
        {

            try
            {
                List<Product_Selected_Groups> selected = Getselected_GroupsByProductID(ProductId);
                DeleteProduct_Selected_Groups(selected.ToList());
                return true;

            }
            catch (Exception)
            {
                return false;
            };
        }
    }
}
