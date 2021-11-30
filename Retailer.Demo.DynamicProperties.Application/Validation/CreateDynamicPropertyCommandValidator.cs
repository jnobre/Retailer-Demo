using FluentValidation;
using Retailer.Demo.DynamicProperties.Application.DTOs;
using Retailer.Demo.DynamicProperties.Domain.Entities;

namespace Retailer.Demo.DynamicProperties.Application.Validation
{
    public class CreateDynamicPropertyCommandValidator : AbstractValidator<DynamicPropertyDTO>
    {
        public CreateDynamicPropertyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name.");
            RuleFor(x => x.Scope).NotEmpty()
                .WithMessage("Please specify a scope.")
                .IsInEnum()
                .WithMessage("Scope must have one of the following values: Account, Catalog, Order, Pricing, Stock, Basket, Marketing or Payment.");
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("Please specify a display name.");
            RuleFor(x => x.Required).NotEmpty().WithMessage("Please specify if it is required.");
            RuleFor(x => x.Searchable).NotEmpty().WithMessage("Please specify if it is searchable.");
            RuleFor(x => x.LocaleCode).NotEmpty().WithMessage("Please specify a locale code.");
            RuleFor(x => x.LocaleCode).NotEmpty().WithMessage("Please specify a locale code.");
            RuleFor(x => x.Type).NotNull().SetValidator(new TypeValidator());
        }

        class TypeValidator : AbstractValidator<Type>
        {
            public TypeValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("Please specify a Name.")
                    .IsInEnum()
                    .WithMessage("Name must have one of the following values: Date, File, Image, Metric, MultiSelect, Number, Price, Reference, ReferenceSimple, Text, TextArea, Boolean, Eamil");
                RuleFor(x => x.Validation)
                    .NotEmpty()
                    .WithMessage("Please specify a Validation.");
            }
        }
    }
}
