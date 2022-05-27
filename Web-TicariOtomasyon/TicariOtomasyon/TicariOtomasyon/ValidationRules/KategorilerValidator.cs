using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class KategorilerValidator : AbstractValidator<Kategoriler>
    {
        public KategorilerValidator()
        {
            RuleFor(x => x.KategoriAd).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.KategoriAd).Length(3, 50).WithMessage("Kategori Adı 3 ile 50 karakter arasında olmalıdır.");
        }
    }
}