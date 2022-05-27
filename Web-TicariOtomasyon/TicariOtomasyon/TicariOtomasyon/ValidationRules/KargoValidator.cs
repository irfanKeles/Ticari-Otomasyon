using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class KargoValidator : AbstractValidator<KargoDetay>
    {
        public KargoValidator()
        {
            RuleFor(x => x.TakipKodu).NotEmpty().WithMessage("* Bu Alan Boş Geçilemez");
            RuleFor(x => x.TakipKodu).NotEmpty().Length(10, 10).WithMessage("* Bu alan 10 karakter Uzub/Kısa Olamaz");
        }
    }
}