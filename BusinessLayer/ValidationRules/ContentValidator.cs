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
            RuleFor(X => X.ContentValue).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
           
            //TODO yazarın hakkında a harfi geçsin
        }
    }
}
