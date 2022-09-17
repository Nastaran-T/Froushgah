using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SliderRepository : ISliderRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public SliderRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }

    

        public IEnumerable<Slider> GetAllSlider()
        {
            return db.Slider;
        }

        public Slider GetSliderById(int id)
        {
            return db.Slider.Find(id);
        }

        public bool InsertSlider(Slider slider)
        {
            try
            {
                db.Slider.Add(slider);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateSlider(Slider Slider)
        {
            try
            {
                db.Entry(Slider).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSlider(Slider Slider)
        {
            try
            {
                db.Entry(Slider).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSlider(int SliderId)
        {
            try
            {
                var slider =GetSliderById(SliderId);
                DeleteSlider(slider);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Slider> ShowSlider()
        {
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
           return db.Slider.Where(x => x.IsActive && x.StartDate <= dt && x.EndDate >= dt).ToList();
        }
    }
}
