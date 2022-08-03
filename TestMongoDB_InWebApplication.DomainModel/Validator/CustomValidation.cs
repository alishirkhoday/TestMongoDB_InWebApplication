using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMongoDB_InWebApplication.DomainModel.Validator
{
    public static class CustomValidation
    {
        public static IRuleBuilderOptions<T, IList<TElement>>
            ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
        }

        public static IRuleBuilderOptions<T, IList<TElement>> 
            ListMustContainFewerThan1<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must((rootObject, list, context) =>
            {
                context.MessageFormatter.AppendArgument("MaxElements", num);
                return list.Count < num;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
        }


        public static IRuleBuilderOptions<T, string> test<T, TElement>(this IRuleBuilder<T, string> ruleBuilder, int num)
        {
            return ruleBuilder.Must((rootObject, list, context) =>
            {
                context.MessageFormatter.AppendArgument("MaxElements", num);
                return list.Length >= 5;
            })
            .WithMessage("{PropertyName} must contain fewer than {MaxElements} items.");
        }
        //var a = string.IsNullOrEmpty("fmv") ? "nhf" : "";


    }
}