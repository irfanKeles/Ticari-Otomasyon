using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class MusterilerValidator : AbstractValidator<Musteriler>
    {
        public MusterilerValidator()
        {
            RuleFor(x => x.MusteriAD).NotEmpty().WithMessage("* Boş Geçilemez.");
            RuleFor(x => x.MusteriAD).Length(3, 25).WithMessage("3 ila 25 Karakter Aralığında Olmalıdır.");
            RuleFor(x => x.MusteriAD).MaximumLength(25).WithMessage("25 Karakter Uzun Olamaz.");
            //-----
            RuleFor(x => x.MusteriSoyad).NotEmpty().WithMessage("* Boş Geçilemez.");
            RuleFor(x => x.MusteriSoyad).Length(2, 25).WithMessage("2 ile 25 Karakter Aralığında Olmalıdır.");
            //-----
            RuleFor(x => x.MusteriSifre).NotEmpty().WithMessage("* Boş Geçilemez");
            RuleFor(x => x.MusteriSifre).Length(4, 11).WithMessage(" 4 ile 11 Karakter Uzunluğunda Olmalıdır.");
            //-----
            RuleFor(x => x.MusteriTelNo).NotEmpty().WithMessage("* Boş Geçilemez.");
            RuleFor(x => x.MusteriTelNo).Length(11, 11).WithMessage(" 11 Karakterden Kısa/uzun Olamaz.");
            //-----
            RuleFor(x => x.MusteriAdres).NotEmpty().WithMessage("* Boş Geçilemez.");
            RuleFor(x => x.MusteriAdres).MaximumLength(250).WithMessage(" 250 karakterden Uzun Olamaz.");
            //-----
            RuleFor(x => x.MusteriMail).NotEmpty().WithMessage("* Boş Geçilemez.");
            RuleFor(x => x.MusteriMail).NotEmpty().EmailAddress().WithMessage("' test@mail.com ' Biçiminde Olmalıdır.");
            //-----
            RuleFor(x => x.MusteriFoto).NotEmpty().WithMessage("Fotoğraf Kısmı Boş Geçilemez.");
        }
    }
}