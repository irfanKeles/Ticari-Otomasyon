using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class LoginValidator : AbstractValidator<Musteriler>
    {
        public LoginValidator()
        {
            RuleFor(x => x.MusteriDT).NotEmpty().WithMessage(" * Boş Geçilemez.");
            //------------
            RuleFor(x => x.MusteriMail).NotEmpty().WithMessage(" * Boş Geçilemez.");
            RuleFor(x => x.MusteriMail).NotEmpty().EmailAddress().WithMessage(" ' test@gmail.com ' Şeklinde Olmalıdır.");
            //------------
            RuleFor(x => x.MusteriSifre).NotEmpty().WithMessage(" * Boş Geçilemez. ");
            RuleFor(x => x.MusteriSifre).NotEmpty().Length(4,11).WithMessage(" 4 ila 11 Karakter Aralığında Olmalıdır. ");
        }
    }
}