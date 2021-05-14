using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(X => X.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("Kategori Adına En Az 3 Karakter Yazınız");
            RuleFor(X => X.CategoryName).MaximumLength(3).WithMessage("Kategori Adına En Fazla 20 Karakter Yazınız");
        }
    }
}
