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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _ımageFileDal;
        public ImageFileManager(IImageFileDal ımageFileDal)
        {
            _ımageFileDal = ımageFileDal;
        }

        public void Add(ImageFile imageFile)
        {
            _ımageFileDal.Insert(imageFile);
        }

        public List<ImageFile> GetList()
        {
            return _ımageFileDal.List();
        }
    }
}
