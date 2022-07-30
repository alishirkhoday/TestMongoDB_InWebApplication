using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMongoDB_InWebApplication.DomainModel.Entity;

namespace TestMongoDB_InWebApplication.DomainModel.Validator
{
    public class MobileNumberValidator : AbstractValidator<MobileNumber>
    {
        public MobileNumberValidator()
        {
            RuleFor(m => m.Value)
                .NotEmpty().WithMessage("لطفا موبایل مشتری را وارد کنید")
                .Length(11).WithMessage("لطفا موبایل را صحیح وارد کنید");
        }
    }
}
