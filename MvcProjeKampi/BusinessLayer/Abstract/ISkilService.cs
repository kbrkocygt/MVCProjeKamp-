using EntittyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkilService
    {
        List<Skil> GetSkils();
        void SkilAdd(Skil skil);
        Skil GetByID(int id);
        void SkilDelete(Skil skil);
        void SkilUpdate(Skil skil);
    }
}
