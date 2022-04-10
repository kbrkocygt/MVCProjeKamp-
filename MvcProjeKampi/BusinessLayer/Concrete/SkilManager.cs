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
        public List<Skil> GetSkils()
        {
            return _skilDal.List();
        }
    }
}
