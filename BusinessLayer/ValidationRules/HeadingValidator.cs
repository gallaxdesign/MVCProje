using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(X => X.HeadingName).NotEmpty().WithMessage("Başlık Adını Boş Geçemezsiniz");
            RuleFor(X => X.HeadingName).MinimumLength(3).WithMessage("Başlık Adına En Az 2 Karakter Yazınız");
            RuleFor(X => X.HeadingName).MaximumLength(3).WithMessage("Başlık Adına En Fazla 50 Karakter Yazınız");
            
           
        }
    }
}
