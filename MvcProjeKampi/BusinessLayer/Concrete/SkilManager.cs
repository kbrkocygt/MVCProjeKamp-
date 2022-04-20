using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkilManager : ISkilService
    {
        ISkilDal _skilDal;
        public SkilManager(ISkilDal skilDal)
        {
            _skilDal = skilDal;
        }

        public Skil GetByID(int id)
        {
            return _skilDal.Get(x => x.SkilID == id);
        }

        public List<Skil> GetSkils()
        {
            return _skilDal.List();
        }

        public void SkilAdd(Skil skil)
        {
            _skilDal.Insert(skil);
        }

        public void SkilDelete(Skil skil)
        {
            _skilDal.Delete(skil);
        }

        public void SkilUpdate(Skil skil)
        {
            _skilDal.Update(skil);
        }
    }
}
