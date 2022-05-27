using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class UrunlerimValidator : AbstractValidator<Urunlerim>
    {
        public UrunlerimValidator()
        {
            RuleFor(x => x.UrunAd).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");
            RuleFor(x => x.UrunAd).Length(3, 70).WithMessage("Bu Kısım 3 ile 70  Karakter Arasında Olmalıdır.");
            RuleFor(x => x.UrunAd).MaximumLength(70).WithMessage("Bu Kısım 70 Karakterden Uzun Olamaz.");
            //------
            RuleFor(x => x.UrunStok).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");
            //------
            RuleFor(x => x.UrunAlisFiyat).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");
            //------
            RuleFor(x => x.KategoriID).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");
            //------
            RuleFor(x => x.MarkaID).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");
            //------
            RuleFor(x => x.UrunBilgi).NotEmpty().WithMessage("Bu Kısım Boş Geçilemez.");

        }
    }
}