using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IDisposable
    {
        Froushgah_DBEntities db=new Froushgah_DBEntities();

        private IProduct_GroupsRepository _productGroupsRepository;
        public IProduct_GroupsRepository ProductGroupsRepository
        {
            get
            {
                if (_productGroupsRepository == null)
                {
                    _productGroupsRepository = new Product_GroupsRepository(db);
                }
                return _productGroupsRepository;
            }
        }


        private IProductsRepositry _productsRepository;
        public IProductsRepositry ProductsRepository
        {
            get
            {
                if (_productsRepository == null)
                {
                    _productsRepository = new ProductsRepository(db);
                }
                return _productsRepository;
            }
        }


        private IProduct_TagsRepository _product_TagsRepository;
        public IProduct_TagsRepository Product_TagsRepository
        {
            get
            {
                if (_product_TagsRepository == null)
                {
                    _product_TagsRepository = new Product_TagsRepository(db);
                }
                return _product_TagsRepository;
            }
        }


        private IProduct_Selected_GroupsRepository _product_Selected_GroupsRepository;
        public IProduct_Selected_GroupsRepository Product_Selected_GroupsRepository
        {
            get
            {
                if (_product_Selected_GroupsRepository == null)
                {
                    _product_Selected_GroupsRepository = new Product_Selected_GroupsRepository(db);
                }
                return _product_Selected_GroupsRepository;
            }
        }


        private IProduct_GalleriesRepository _productGalleriesRepository;
        public  IProduct_GalleriesRepository ProductGalleriesRepository
        {
            get
            {
                if (_productGalleriesRepository == null)
                {
                    _productGalleriesRepository = new Product_GalleriesRepository(db);
                }
                return _productGalleriesRepository;
            }
        }


        private IFeaturesRepository _featuresRepository;
        public IFeaturesRepository FeaturesRepository
        {
            get
            {
                if (_featuresRepository == null)
                {
                    _featuresRepository = new FeaturesRepository(db);
                }
                return _featuresRepository;
            }
        }



        private IProduct_FeaturesRepository _productFeaturesRepository;
        public IProduct_FeaturesRepository ProductFeaturesRepository
        {
            get
            {
                if (_productFeaturesRepository == null)
                {
                    _productFeaturesRepository = new Product_FeaturesRepository(db);
                }
                return _productFeaturesRepository;
            }
        }


        private IProduct_CommentsRepository _productCommentsRepository;
        public IProduct_CommentsRepository ProductCommentsRepository
        {
            get
            {
                if (_productCommentsRepository == null)
                {
                    _productCommentsRepository = new Product_CommentsRepository(db);
                }
                return _productCommentsRepository;
            }
        }


        private ISliderRepository _sliderRepository;
        public ISliderRepository SliderRepository
        {
            get
            {
                if (_sliderRepository == null)
                {
                    _sliderRepository = new SliderRepository(db);
                }
                return _sliderRepository;
            }
        }




        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
