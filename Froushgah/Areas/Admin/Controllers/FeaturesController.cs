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
    public class FeaturesController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        // GET: Admin/Features
        public ActionResult Index()
        {
            return View(db.FeaturesRepository.GetAllFeatures());
        }

        // GET: Admin/Features/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Features features = db.Features.Find(id);
        //    if (features == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(features);
        //}

        // GET: Admin/Features/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Features/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeatureID,FeatureTitle")] Features features)
        {
            if (ModelState.IsValid)
            {
                db.FeaturesRepository.InsertFeatures(features);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(features);
        }

        // GET: Admin/Features/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Features features = db.FeaturesRepository.GetFeaturesById(id.Value);
            if (features == null)
            {
                return HttpNotFound();
            }
            return View(features);
        }

        // POST: Admin/Features/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeatureID,FeatureTitle")] Features features)
        {
            if (ModelState.IsValid)
            {
                db.FeaturesRepository.UpdateFeatures(features);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(features);
        }

        // GET: Admin/Features/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Features features = db.FeaturesRepository.GetFeaturesById(id.Value);
            if (features == null)
            {
                return HttpNotFound();
            }
            db.FeaturesRepository.DeleteFeatures(features);
            return View(features);
        }

        // POST: Admin/Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Features features = db.FeaturesRepository.GetFeaturesById(id);
            db.FeaturesRepository.DeleteFeatures(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
