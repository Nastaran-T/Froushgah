using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FeaturesRepository : IFeaturesRepository
    {
        //cunstractor Enjection
        private Froushgah_DBEntities db;
        public FeaturesRepository(Froushgah_DBEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Features> GetAllFeatures()
        {
            return db.Features;
        }

        public Features GetFeaturesById(int FeaturesId)
        {
            return db.Features.Find(FeaturesId);
        }

        public bool InsertFeatures(Features Features)
        {

            try
            {
                db.Features.Add(Features);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateFeatures(Features Features)
        {
            try
            {
                db.Entry(Features).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool DeleteFeatures(Features Features)
        {
            try
            {
                db.Entry(Features).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteFeatures(int FeaturesId)
        {
            try
            {
                var Features = GetFeaturesById(FeaturesId);
                DeleteFeatures(Features);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
