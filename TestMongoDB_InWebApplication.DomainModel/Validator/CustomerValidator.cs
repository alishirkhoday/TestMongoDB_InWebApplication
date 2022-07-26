using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMongoDB_InWebApplication.DomainModel.Entity;

namespace TestMongoDB_InWebApplication.DomainModel.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            //RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.Name).NotEmpty().WithMessage("لطفا نام مشتری را وارد کنید");
            RuleFor(customer => customer.Family).NotEmpty().WithMessage("لطفا نام نام خانوادگی مشتری را وارد کنید");
            RuleFor(customer => customer.MobileNumber).SetValidator(new MobileNumberValidator());
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress().WithMessage("لطفا ایمیل مشتری را وارد کنید").MaximumLength(150);
            RuleFor(customer => customer.Address).MaximumLength(1000);
        }

    }
}
