using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicariOtomasyon.Models.Concrete;

namespace TicariOtomasyon.ValidationRules
{
    public class FaturalarValidator : AbstractValidator<Faturalar>
    {
        public FaturalarValidator()
        {
            RuleFor(x => x.FaturaSeriNO).NotEmpty().WithMessage("Seri No Boş Geçileemz!");
            RuleFor(x => x.FaturaSıraNo).NotEmpty().WithMessage("Sıra No Boş Geçileemz!");
            RuleFor(x => x.FaturaVergiDairesi).NotEmpty().WithMessage("Vergi Dairesi Geçileemz!");
            RuleFor(x => x.FaturKesen).NotEmpty().WithMessage("Bu Alan Boş Geçileemz!");
            RuleFor(x => x.FaturAlan).NotEmpty().WithMessage("Bu Alan Boş Geçileemz!");
            RuleFor(x => x.ToplamTutar).NotEmpty().WithMessage("Bu Alan Boş Geçileemz!");

        }
    }
}