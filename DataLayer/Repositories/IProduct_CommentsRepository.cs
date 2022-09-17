using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProduct_CommentsRepository
    {
        IEnumerable<Product_Comments> GetProduct_CommentsByProductId(int id);
        bool InsertProduct_Comments(Product_Comments Product_Comments);
    }
}
