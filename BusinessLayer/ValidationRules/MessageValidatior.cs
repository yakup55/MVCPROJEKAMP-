using EntityLayer.Concerete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidatior : AbstractValidator<Message>
    {
        public MessageValidatior()
        {
            RuleFor(x=>x.ReceiverMail).NotEmpty().WithMessage("Mail adresiniz boş olamaz");
            RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu alanı boş olamaz");
            RuleFor(x=>x.MessageContent).MinimumLength(3).WithMessage("Mesaj en az 3 karakter olmalı");
            RuleFor(x=>x.MessageContent).MaximumLength(100).WithMessage("Mesaj en fazla 100 karakter olmalı");
        }

      
    }
}
