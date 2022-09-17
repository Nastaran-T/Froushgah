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
    public class ProductsController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        #region Method
        private string SaveImage(HttpPostedFileBase FileImage)
        {
            if (FileImage!=null && FileImage.IsImage())
            {
                string ImageName = Guid.NewGuid() + Path.GetExtension(FileImage.FileName);
                string ImagePath = Server.MapPath("/images/ProductImage/" + ImageName);
                string ImageThumbPath = Server.MapPath("/images/ProductImage/Thumbnail/" + ImageName);
                FileImage.SaveAs(ImagePath);

                ImageResizer imageResizer = new ImageResizer();
                imageResizer.Resize(ImagePath, ImageThumbPath);

                return ImageName;

            }
            else
            {
                return "DefaultImages.jpg";
            }
        }

        private void DeleteOldImage(HttpPostedFileBase FileImage)
        {
            string ImagePath = Server.MapPath("/images/ProductImage/" + FileImage);
            string ImageThumbPath = Server.MapPath("/images/ProductImage/Thumbnail/" + FileImage);
            System.IO.File.Delete(ImagePath);
            System.IO.File.Delete(ImageThumbPath);


        }

        private void DeleteOldImage(string FileImage)
        {
            string ImagePath = Server.MapPath("/images/ProductImage/" + FileImage);
            string ImageThumbPath = Server.MapPath("/images/ProductImage/Thumbnail/" + FileImage);
            System.IO.File.Delete(ImagePath);
            System.IO.File.Delete(ImageThumbPath);


        }

        #endregion




        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(db.ProductsRepository.GetAllProducts().ToList());
        }

        // GET: Admin/Products/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Products products = db.Products.Find(id);
        //    if (products == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(products);
        //}

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();
            return View();
        }

        // POST: Admin/Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,TitleProduct,ShortDescriptionProduct,TextProduct,PriceProduct,ImageProduct,CreateDateProduct")] Products products, List<int> selectedGroups, HttpPostedFileBase imageProduct,string tags)
        {
            if (ModelState.IsValid)
            {
                if (selectedGroups==null)
                {
                    ViewBag.ErrorSelectedGroups = true;
                    ViewBag.ProductGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();

                    return View(products);
                }
                products.CreateDateProduct = DateTime.Now;
                products.ImageProduct = SaveImage(imageProduct);
                db.ProductsRepository.InsertProduct(products);
                foreach (int selectedGroup in selectedGroups)
                {
                    db.Product_Selected_GroupsRepository.Addproduct_Selected_Groups(products.ProductID, selectedGroup);
                }
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] ProductTags = tags.Split(',');
                    foreach (string Tag in ProductTags)
                    {
                        db.Product_TagsRepository.InsertProduct_Tags(db.Product_TagsRepository.AddProduct_TagsByProductID(products.ProductID, Tag.Trim()));
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            ViewBag.ProductGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();

            return View(products);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.ProductsRepository.GetProductById(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();
            ViewBag.SelectedGroups = db.Product_Selected_GroupsRepository.Getselected_GroupsByProductID(products.ProductID).ToList();
            ViewBag.Tags = string.Join(",", db.Product_TagsRepository.GetTagsByProductID(products.ProductID).ToString());
            return View(products);
        }

        // POST: Admin/Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,TitleProduct,ShortDescriptionProduct,TextProduct,PriceProduct,ImageProduct,CreateDateProduct")] Products products, List<int> selectedGroups, HttpPostedFileBase imageProduct, string tags)
        {
            //checkImage
            if (ModelState.IsValid)
            {
                if (imageProduct != null && imageProduct.IsImage())
                {
                    if (products.ImageProduct!= "DefaultImages.jpg")
                    {
                        DeleteOldImage(imageProduct);
                    }
                    SaveImage(imageProduct);

                }

                //checkTag
                db.Product_TagsRepository.DeleteProduct_Tags(products.ProductID);
                if (!string.IsNullOrEmpty(tags))
                {
                    string[] ProductTags = tags.Split(',');
                    foreach (string Tag in ProductTags)
                    {
                        db.Product_TagsRepository.InsertProduct_Tags(db.Product_TagsRepository.AddProduct_TagsByProductID(products.ProductID, Tag.Trim()));
                    }
                }

                //checkCheckBox
                db.Product_Selected_GroupsRepository.DeleteProduct_Selected_Groups(products.ProductID);
                foreach (int selectedGroup in selectedGroups)
                {
                    db.Product_Selected_GroupsRepository.Addproduct_Selected_Groups(products.ProductID, selectedGroup);
                }

                db.ProductsRepository.UpdateProduct(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductGroups = db.ProductGroupsRepository.GetAllProduct_Group().ToList();
            ViewBag.SelectedGroups = selectedGroups;
            ViewBag.Tags = tags;
            return View(products);
        }


        //// GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.ProductsRepository.GetProductById(id.Value);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        //// POST: Admin/Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Products products = db.Products.Find(id);
        //    db.Products.Remove(products);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        #region Gallery

        //Get:Gallery
        public ActionResult Gallary(int id)
        {

            ViewBag.ProductGallery = db.ProductGalleriesRepository.GetProduct_GalleriesByProductID(id);
            return View(new Product_Galleries { ProductID = id });
        }

        //Post:Gallery
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Gallary(Product_Galleries product_Galleries, HttpPostedFileBase ImageUp)
        {
            if (ModelState.IsValid)
            {
                product_Galleries.ImageGallery = SaveImage(ImageUp);
                db.ProductGalleriesRepository.InsertProduct_Galleries(product_Galleries);
                db.SaveChanges();

            }
            return RedirectToAction("Gallary", new { id = product_Galleries.ProductID });
        }

        public ActionResult DeleteGallery(int id)
        {
            var gallery = db.ProductGalleriesRepository.GetGalleryById(id);
            DeleteOldImage(gallery.ImageGallery);
            db.ProductGalleriesRepository.DeleteProduct_Galleries(gallery);
            db.SaveChanges();

            return RedirectToAction("Gallary", new { id = gallery.ProductID });
        }

        #endregion

        #region Features
        public ActionResult Feature(int id)
        {
            ViewBag.ProductFeature = db.ProductFeaturesRepository.GetProduct_FeaturesByProductId(id);
            ViewBag.FeatureID =new SelectList(db.FeaturesRepository.GetAllFeatures(), "FeatureID", "FeatureTitle");
            return View(new Product_Features {ProductID=id });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Feature(Product_Features ProductFeatures)
        {
            if (ModelState.IsValid)
            {
                db.ProductFeaturesRepository.InsertProduct_Features(ProductFeatures);
                db.SaveChanges();
            }
            return RedirectToAction("Feature", new { id = ProductFeatures.ProductID });

        }

        public void DeleteFeature(int id)
        {
            var Feature = db.ProductFeaturesRepository.GetProduct_FeaturesById(id);
            db.ProductFeaturesRepository.DeleteProduct_Features(Feature);
            db.SaveChanges();

          
        }
        #endregion


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
