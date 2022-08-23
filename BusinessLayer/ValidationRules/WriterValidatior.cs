using EntityLayer.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
public    class WriterValidatior: AbstractValidator<Writer>
    {
        //ctor tab tab metot oluşturuyor
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakamazsın");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında kısmını Boş Bırakamazsın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısmını Boş Bırakamazsın");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En az 2 Karakter Giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
        }
    }
}
