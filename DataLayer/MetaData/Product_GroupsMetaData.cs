using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Product_GroupsMetaData
    {
        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string GroupTitle { get; set; }
    }


    [MetadataType(typeof(Product_GroupsMetaData))]
    public partial class Product_Groups
    {

    }
}
