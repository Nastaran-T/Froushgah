using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Froushgah.Controllers
{
    public class ProductController : Controller
    {
        //dbContext
        UnitOfWork db = new UnitOfWork();

        // GET: Product
        public ActionResult ShowGroups()
        {
            return PartialView(db.ProductGroupsRepository.GetAllProduct_Group());
        }

        public ActionResult ShowLastProduct()
        {
            return PartialView(db.ProductsRepository.GetLastProducts());
        }

        public ActionResult ShowProduct(int id)
        {
            var product = db.ProductsRepository.GetProductById(id);
            ViewBag.PFeature = db.ProductFeaturesRepository.GetProduct_FeaturesById(id);
            return View(product);
        }

        public ActionResult ShowComments(int id)
        {
            return PartialView(db.ProductCommentsRepository.GetProduct_CommentsByProductId(id));
        }

        public ActionResult CreateComment(int id)
        {
            return PartialView(new Product_Comments { ProductID=id});
        }

        [HttpPost]
        public ActionResult CreateComment(Product_Comments product_Comments)
        {
            if (ModelState.IsValid)
            {
                product_Comments.CreateDate = DateTime.Now;
                db.ProductCommentsRepository.InsertProduct_Comments(product_Comments);
                db.SaveChanges();
                return PartialView("ShowComments", db.ProductCommentsRepository.GetProduct_CommentsByProductId(product_Comments.ProductID));
            }
            return PartialView(product_Comments);
        }


        #region Archive
        [Route("Archive")]
        public ActionResult ProductArchive(int pageId = 1, string title = "", int minPrice = 0, int maxPrice = 0, List<int> selectedGroup = null)
        {
            ViewBag.ListGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();
            ViewBag.productTitle = title;
            ViewBag.minPrice = minPrice;
            ViewBag.maxPrice = maxPrice;
            ViewBag.pageId = pageId;
            ViewBag.selectGroup = selectedGroup;
            List<Products> list= db.ProductsRepository.LoadProductByFilter(pageId, title, minPrice, maxPrice, selectedGroup).ToList();
           
            //Pagging
            int take = 1;
            int skip = (pageId - 1) * take;
            ViewBag.PageCount = list.Count() / take;
            return View(list.OrderByDescending(p => p.CreateDateProduct).Skip(skip).Take(take).ToList());
         
        }

        #endregion
    }
}