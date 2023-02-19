using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail alanını boş geçemezsiniz!.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanını boş geçemezsiniz!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik veri girişi yapın!");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik veri girişi yapın!");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla veri girişi yapmayın!");

        }
    }
}
