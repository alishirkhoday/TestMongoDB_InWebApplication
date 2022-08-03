using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMongoDB_InWebApplication.DomainModel.Entity;
using TestMongoDB_InWebApplication.DomainModel.Validator;

namespace TestMongoDB_InWebApplication.DomainModel.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            //RuleFor(customer => customer.Id).NotEmpty();
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("لطفا نام مشتری را وارد کنید")
                ;
            
            //RuleFor(a => a.MobileNumbers).Must()
            //RuleFor(a => a.Name).test();
            //RuleFor(a=>a.Email).element
            //RuleFor(a => a.Age).element();

        }
    }
}
