using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class SatislarValidator : AbstractValidator<Satislar>
    {
        public SatislarValidator()
        {
            RuleFor(x => x.SatisAdet).NotEmpty().WithMessage("Adet Kısmı Boş Geçilemez.");
            //RuleFor(x => x.SatisFiyat).NotEmpty().WithMessage("Fiyat Kısmı Boş Geçilemez.");
        }
    }
}