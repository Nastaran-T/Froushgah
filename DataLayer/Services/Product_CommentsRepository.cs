using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_CommentsRepository : IProduct_CommentsRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public Product_CommentsRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }


        public IEnumerable<Product_Comments> GetProduct_CommentsByProductId(int id)
        {
            return db.Product_Comments.Where(x => x.ProductID == id).ToList(); 
        }

        public bool InsertProduct_Comments(Product_Comments Product_Comments)
        {
            try
            {
                db.Product_Comments.Add(Product_Comments);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
