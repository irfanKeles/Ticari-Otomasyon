using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class PersonelValidator : AbstractValidator<Personel>
    {
        public PersonelValidator()
        {
            RuleFor(x => x.PersonelAd).NotEmpty().WithMessage("Bu Alan boş geçileemz !");
            RuleFor(x => x.PersonelAd).Length(3, 25).WithMessage("Bu Alan 3 ila 25 Karakter Aralığında Olmalı.");
            RuleFor(x => x.PersonelAd).MaximumLength(25).WithMessage("Bu Alan 25 Karakterden Uzun Olamaz.");
            //-----
            RuleFor(x => x.PersonelSoyad).NotEmpty().WithMessage("Bu Alan boş geçileemz !");
            RuleFor(x => x.PersonelSoyad).Length(3, 25).WithMessage("Bu Alan 3 ila 25 Karakter Aralığında Olmalı.");
            RuleFor(x => x.PersonelSoyad).MaximumLength(25).WithMessage("Bu Alan 25 Karakterden Uzun Olamaz.");
            //-----
            RuleFor(x => x.PersonelMail).NotEmpty().WithMessage("Mail Kısmı Boş Geçilemez.");
            RuleFor(x => x.PersonelMail).NotEmpty().EmailAddress().WithMessage("Mail Adresiniz 'test@mail.com' Biçiminde Olmalıdır.");
            //-----
            RuleFor(x => x.PersonelTelNo).NotEmpty().WithMessage("Tel No Kısmı Boş Geçilemez.");
            RuleFor(x => x.PersonelTelNo).Length(11, 11).WithMessage("Tel No Kısmı 11 Karakterden Kısa/Uzun Olmalı.");
            RuleFor(x => x.PersonelTelNo).MaximumLength(11).WithMessage("Tel No Kısmı 11 Karakterden Uzun Olamaz.");
            //-----
            RuleFor(x => x.PersonelSifre).NotEmpty().WithMessage("Şifre Kısmı Boş Geçilemez.");
            RuleFor(x => x.PersonelSifre).Length(4, 11).WithMessage("Şifre Kısmı 4 ile 11 Karakter Aralığında Olmalı.");
            RuleFor(x => x.PersonelSifre).MaximumLength(11).WithMessage("Şifre Kısmı 11 Karakterden Uzun Olamaz.");
        }
    }
}