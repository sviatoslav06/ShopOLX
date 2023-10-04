using DataAccess.Data.Entities;
using FluentValidation;
using System;

namespace ShopOLX.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(3, 20).WithMessage("Enter normal {PropertyName}!");
            RuleFor(x => x.Phone).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(10,10).WithMessage("{PropertyName} length must be 10!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Enter valid {PropertyName}!");
            RuleFor(x => x.Price).NotNull().WithMessage("Enter {PropertyName}!")
                .GreaterThan(0).WithMessage("{PropertyName} can not be less than 0!");
            RuleFor(x => x.ImageUrl).Must(ValidateUrl).WithMessage("{PropertyName} must contain valid URL address!");
            RuleFor(x => x.Discount).InclusiveBetween(0, 100).WithMessage("{PropertyName} must be from 0 to 100!");
            RuleFor(x => x.City).NotNull().WithMessage("Enter {PropertyName}!")
                .Length(3, 15).WithMessage("{PropertyName} must contain 3 - 15 symbols!");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Enter more than 10 symbols!");
        }
        public bool ValidateUrl(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
