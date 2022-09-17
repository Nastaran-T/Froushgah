using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Froushgah.Areas.Admin.Controllers
{
    public class Product_GroupsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/Product_Groups
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListGroups()
        {
            return PartialView(db.ProductGroupsRepository.GetAllParentProduct_Group());
        }

        //    // GET: Admin/Product_Groups/Details/5
        //    public ActionResult Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Product_Groups product_Groups = db.Product_Groups.Find(id);
        //        if (product_Groups == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(product_Groups);
        //    }

        // GET: Admin/Product_Groups/Create
        public ActionResult Create(int?Id)
        {
            return PartialView(new Product_Groups() { ParentID=Id});
        }

        // POST: Admin/Product_Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,ParentID")] Product_Groups product_Groups)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroupsRepository.InsertProduct_Group(product_Groups);
                db.SaveChanges();
                return PartialView("ListGroups", db.ProductGroupsRepository.GetAllParentProduct_Group());
            }

            ViewBag.ParentID = new SelectList(db.ProductGroupsRepository.GetAllProduct_Group(), "GroupID", "GroupTitle", product_Groups.ParentID);
            return View(product_Groups);
        }

        // GET: Admin/Product_Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups product_Groups = db.ProductGroupsRepository.GetProduct_GroupById(id.Value);
            if (product_Groups == null)
            {
                return HttpNotFound();
            }
            return PartialView(product_Groups);
        }

        // POST: Admin/Product_Groups/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle,ParentID")] Product_Groups product_Groups)
        {
            if (ModelState.IsValid)
            {
                db.ProductGroupsRepository.UpdateProduct_Group(product_Groups);
                db.SaveChanges();
                return PartialView("ListGroups", db.ProductGroupsRepository.GetAllParentProduct_Group());
            }
            ViewBag.ParentID = new SelectList(db.ProductGroupsRepository.GetAllProduct_Group(), "GroupID", "GroupTitle", product_Groups.ParentID);
            return View(product_Groups);
        }



        // GET: Admin/Product_Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Groups product_Groups = db.ProductGroupsRepository.GetProduct_GroupById(id.Value);
            if (product_Groups == null)
            {
                return HttpNotFound();
            }
            if (product_Groups.Product_Groups1.Any())
            {
                foreach (var subGroup in db.ProductGroupsRepository.GetSubGroupByGroupId(id.Value))
                {
                    db.ProductGroupsRepository.DeleteProduct_Group(subGroup);
                }
            }
            db.ProductGroupsRepository.DeleteProduct_Group(product_Groups);
            db.SaveChanges();
            
            return PartialView(product_Groups);
        }



        //// POST: Admin/Product_Groups/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Product_Groups product_Groups = db.ProductGroupsRepository.GetProduct_GroupById(id);
        //    db.ProductGroupsRepository.DeleteProduct_Group(product_Groups);
        //    db.SaveChanges();
        //    return PartialView("ListGroups", db.ProductGroupsRepository.GetAllParentProduct_Group());
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
