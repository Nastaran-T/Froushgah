using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Froushgah.Controllers
{
    public class SearchController : Controller
    {
        UnitOfWork db = new UnitOfWork();
        // GET: Search
        public ActionResult Index(string TextSearch)
        {
            List<Products> list = new List<Products>();
            list.AddRange ( db.Product_TagsRepository.GetProductByTag(TextSearch));
            list.AddRange(db.ProductsRepository.GetProductBySearch(TextSearch));

            ViewBag.Search = TextSearch;

            return View(list.Distinct());
        }
    }
}