using Entities.Concrete;
using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class StaffModelValidator : AbstractValidator<StaffModel>
    {
        public StaffModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(30).WithMessage("isminiz boş veya 30 karakterden fazla olmamalıdır.");
            RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(30).WithMessage("soy isminiz boş veya 30 karakterden fazla olmamalıdır.");
            RuleFor(x => x.Email).NotEmpty().NotNull().MaximumLength(30).WithMessage("lütfen geçerli bir email girin");
            RuleFor(x => x.Phone).NotEmpty().NotNull().MaximumLength(30).WithMessage("lütfen geçerli bir telefon numarası girin");
            RuleFor(x => x.DateOfBirth).NotEmpty().NotNull().WithMessage("geçersiz tarih");
            RuleFor(x => x.AddressLine1).NotEmpty().NotNull().MaximumLength(30).WithMessage("geçersiz adres");
            RuleFor(x => x.City).NotEmpty().NotNull().MaximumLength(30).WithMessage("geçersiz şehir adı");
            RuleFor(x => x.Country).NotEmpty().NotNull().MaximumLength(30).WithMessage("geçersiz ülke adı");
            RuleFor(x => x.Province).NotEmpty().NotNull().MaximumLength(17).WithMessage("geçersiz ilçe adı");
            
        }
    }
}
