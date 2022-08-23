using EntityLayer.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior : AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Boş Olamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj Boş Olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı  Boş Olamaz");
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(3).WithMessage("Kullanıcı Adı  En az 3 Karakter Yapın");
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(50).WithMessage("Konuyu  En Fazla 50 Karakter Yapın");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesaj Boş Olamaz");
        }
    }
}
