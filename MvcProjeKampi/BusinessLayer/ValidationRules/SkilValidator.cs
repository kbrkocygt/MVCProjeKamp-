using EntittyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class SkilValidator: AbstractValidator<Skil>
    {
        public SkilValidator()
        {
            RuleFor(x => x.Yetenek).NotEmpty().WithMessage("Yetenek Adını boş geçemezsiniz.");
            RuleFor(x => x.YetenekBaşarı).NotEmpty().WithMessage("Başarıyı boş geçemezsiniz.");
           
        }
    }
}
