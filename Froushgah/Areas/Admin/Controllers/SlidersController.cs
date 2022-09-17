using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using InsertShowImage;
using KooyWebApp_MVC.Classes;

namespace Froushgah.Areas.Admin.Controllers
{
    public class SlidersController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        #region Method
        private string SaveImage(HttpPostedFileBase FileImage)
        {
            if (FileImage != null && FileImage.IsImage())
            {
                string ImageName = Guid.NewGuid() + Path.GetExtension(FileImage.FileName);
                string ImagePath = Server.MapPath("/images/slider/" + ImageName);
               // string ImageThumbPath = Server.MapPath("/images/slider/Thumbnail/" + ImageName);
                FileImage.SaveAs(ImagePath);

               // ImageResizer imageResizer = new ImageResizer();
                //imageResizer.Resize(ImagePath, ImageThumbPath);

                return ImageName;

            }
            else
            {
                return null;
            }
        }
        private void DeleteOldImage(string FileImage)
        {
            string ImagePath = Server.MapPath("/images/slider/" + FileImage);
            //string ImageThumbPath = Server.MapPath("/images/slider/Thumbnail/" + FileImage);
            System.IO.File.Delete(ImagePath);
           // System.IO.File.Delete(ImageThumbPath);


        }
        #endregion


        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(db.SliderRepository.GetAllSlider().ToList());
        }

        // GET: Admin/Sliders/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Slider slider = db.Slider.Find(id);
        //    if (slider == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(slider);
        //}

        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlideID,Title,Url,ImageName,StartDate,EndDate,IsActive")] Slider slider,HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp==null)
                {
                    ModelState.AddModelError("ImageName","لطفا تصویر را انتخاب کنید");
                    return View(slider);
                }
                slider.ImageName = SaveImage(imgUp);
                db.SliderRepository.InsertSlider(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetSliderById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlideID,Title,Url,ImageName,StartDate,EndDate,IsActive")] Slider slider, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp!=null)
                {
                    DeleteOldImage(slider.ImageName);
                    SaveImage(imgUp);
                }
                db.SliderRepository.UpdateSlider(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.SliderRepository.GetSliderById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.SliderRepository.GetSliderById(id);
            DeleteOldImage(slider.ImageName);
            db.SliderRepository.DeleteSlider(slider);
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
