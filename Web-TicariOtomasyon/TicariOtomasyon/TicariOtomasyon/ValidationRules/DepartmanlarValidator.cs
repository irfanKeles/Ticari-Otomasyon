using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class DepartmanlarValidator : AbstractValidator<Departmanlar>
    {
        public DepartmanlarValidator()
        {
            RuleFor(x => x.DepartmanAd).NotEmpty().WithMessage("Departman Adı Boş Geçilemez.");
            RuleFor(x => x.DepartmanAd).Length(3, 50).WithMessage("Departman Adı 3 ile 50 Karakter Arasıdna Olmaldıır.");
        }
    }
}