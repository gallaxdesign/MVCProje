using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konu Boş Geçemezsiniz");
            RuleFor(X => X.ReceiverMail).NotEmpty().WithMessage("Alıcıyı boş Geçemezsiniz");
            //TODO geçerli mail kontrolü
            
        }
    }
}
