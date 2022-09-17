using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_GroupsRepository : IProduct_GroupsRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_GroupsRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Product_Groups> GetAllProduct_Group()
        {
            return db.Product_Groups;
        }

        public Product_Groups GetProduct_GroupById(int Product_GroupId)
        {
            return db.Product_Groups.Find( Product_GroupId);
        }

        public bool InsertProduct_Group(Product_Groups Product_Group)
        {
            try
            {
                db.Product_Groups.Add(Product_Group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateProduct_Group(Product_Groups Product_Group)
        {
            try
            {
                db.Entry(Product_Group).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteProduct_Group(Product_Groups Product_Group)
        {
            try
            {
                db.Entry(Product_Group).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct_Group(int Product_GroupId)
        {
            try
            {
                var product= GetProduct_GroupById(Product_GroupId);
                DeleteProduct_Group(product);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Product_Groups> GetAllParentProduct_Group()
        {
            return db.Product_Groups.Where(c=>c.ParentID==null);
        }

        public IEnumerable<Product_Groups> GetSubGroupByGroupId(int GId)
        {
            return db.Product_Groups.Where(x => x.ParentID == GId);
        }
    }
}
