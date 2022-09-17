using DataLayer;
using DataLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Froushgah.Controllers
{
    public class ShopCartController : Controller
    {
        UnitOfWork db = new UnitOfWork();

        #region Method
        List<ShopOrderViewModel> getListOrder()
        {
            List<ShopOrderViewModel> list = new List<ShopOrderViewModel>();
            if (Session["shopcart"] != null)
            {
                List<ShopeItem> cart = Session["shopcart"] as List<ShopeItem>;

                foreach (var item in cart)
                {
                    var product = db.ProductsRepository.GetProductById(item.ProductID);
                    list.Add(new ShopOrderViewModel()
                    {
                        ProductID = item.ProductID,
                        Count = item.Count,
                        Title = product.TitleProduct,
                        ImageName = product.ImageProduct,
                        Price = product.PriceProduct,
                        Sum = product.PriceProduct * item.Count

                    });

                }
            }
            return list;
        }

        #endregion

        // GET: ShopCart
        public ActionResult ShowCart()
        {
            List<ShopCartViewModel> list = new List<ShopCartViewModel>();
            if (Session["shopcart"]!=null)
            {
                List<ShopeItem> cart = Session["shopcart"] as List<ShopeItem>;
                foreach (var item in cart)
                {
                    var product = db.ProductsRepository.GetProductById(item.ProductID);

                    list.Add(new ShopCartViewModel()
                    {
                        ProductID=item.ProductID,
                        Count=item.Count,
                        Title=product.TitleProduct,
                        ImageName=product.ImageProduct

                    });
                }
            }

            return PartialView(list);
         }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Order()
        {
            return PartialView(getListOrder());
        }


        public int AddToCart(int id)
        {
            List<ShopeItem> cart = new List<ShopeItem>();

            if (Session["shopcart"]!=null)
            {
                cart = Session["shopcart"] as List<ShopeItem>;
            }
            if (cart.Any(x=>x.ProductID==id))
            {
                int index = cart.FindIndex(x => x.ProductID == id);
                cart[index].Count += 1;
            }
            else
            {
                cart.Add(new ShopeItem()
                {
                    ProductID = id,
                    Count = 1
                });
            }
            Session["shopcart"] = cart;

            return cart.Sum(c=>c.Count);
        }

        public ActionResult CommandOrder(int id, int count)
        {
            List<ShopeItem> listShop = Session["ShopCart"] as List<ShopeItem>;
            int index = listShop.FindIndex(p => p.ProductID == id);
            if (count == 0)
            {
                listShop.RemoveAt(index);
            }
            else
            {
                listShop[index].Count = count;
            }
            Session["ShopCart"] = listShop;

            return PartialView("Order", getListOrder());
        }
    }
}