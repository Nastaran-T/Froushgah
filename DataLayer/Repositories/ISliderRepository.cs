using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISliderRepository
    {
        IEnumerable<Slider> GetAllSlider();
        Slider GetSliderById(int id);
        List<Slider> ShowSlider();
        bool InsertSlider(Slider slider);
        bool UpdateSlider(Slider Slider);
        bool DeleteSlider(Slider Slider);
        bool DeleteSlider(int SliderId);
    }
}
