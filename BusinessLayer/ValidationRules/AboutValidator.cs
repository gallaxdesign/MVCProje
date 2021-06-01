using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(X => X.AboutDetails1).NotEmpty().WithMessage("Hakkımızda metnini Boş Geçemezsiniz");

            
            //TODO yazarın hakkında a harfi geçsin
        }
    }
}
