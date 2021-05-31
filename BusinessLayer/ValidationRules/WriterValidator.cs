using EntityLayer.Concrete;
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
            RuleFor(X => X.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(X => X.WriterName).MinimumLength(3).WithMessage("Kategori Adına En Az 2 Karakter Yazınız");
            RuleFor(X => X.WriterName).MaximumLength(3).WithMessage("Kategori Adına En Fazla 50 Karakter Yazınız");
            RuleFor(X => X.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(X => X.WriterSurName).MinimumLength(3).WithMessage("Kategori Soyadına En Az 2 Karakter Yazınız");
            RuleFor(X => X.WriterSurName).MaximumLength(3).WithMessage("Kategori Soyadına En Fazla 50 Karakter Yazınız");
            //TODO yazarın hakkında a harfi geçsin
        }
    }
}
