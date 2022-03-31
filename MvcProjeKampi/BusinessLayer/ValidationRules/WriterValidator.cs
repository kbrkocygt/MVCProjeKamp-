using EntittyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {

        public WriterValidator()
        {
           
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan boş geçilmez.");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapın..");
            RuleFor(x => x.WriterAbout).Must(x=>x!=null && x.ToUpper().Contains("A")).WithMessage("Hakkımda kısmında en az bir a harbi içermelidir.");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen 50  karakterden fazla değer girişi yapmayınız.");
        }
    }
}
