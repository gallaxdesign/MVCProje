using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContentValidator : AbstractValidator<Content>
    {
        public ContentValidator()
        {
            RuleFor(X => X.ContentName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(X => X.ContentName).MinimumLength(3).WithMessage("Kategori Adına En Az 2 Karakter Yazınız");
            RuleFor(X => X.ContentName).MaximumLength(3).WithMessage("Kategori Adına En Fazla 50 Karakter Yazınız");
            RuleFor(X => X.ContentSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(X => X.ContentSurName).MinimumLength(3).WithMessage("Kategori Soyadına En Az 2 Karakter Yazınız");
            RuleFor(X => X.ContentSurName).MaximumLength(3).WithMessage("Kategori Soyadına En Fazla 50 Karakter Yazınız");
            //TODO yazarın hakkında a harfi geçsin
        }
    }
}
