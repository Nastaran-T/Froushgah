using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
    public class ProductsMetaData
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350)]
        public string TitleProduct { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string ShortDescriptionProduct { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        
        public string TextProduct { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int PriceProduct { get; set; }

        [Display(Name = "تصویر")]
        public string ImageProduct { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/mm/dd}")]
        public System.DateTime CreateDateProduct { get; set; }
    }


    [MetadataType(typeof(ProductsMetaData))]
    public partial class Products
    { }



    
}
